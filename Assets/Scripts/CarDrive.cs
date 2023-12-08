using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CarDrive;

public class CarDrive : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject WheelModel;
        public WheelCollider WheelCollider;
        public GameObject wheelEffectObj;
        public Axel axel;
    }
    public float maxAccesleration = 30f;
    public float breakAcceleration = 50f;
    public float maxSpeed = 60f;

    public float SteerSensityvity = 1f;
    public float MaxTurningAngle = 30f;
    float SteerInput;
    public ParticleSystem SmokePartile;

    public List<Wheel> Wheels;
    float MoveInput;
    private Rigidbody CarRB;
    public Vector3 _centerOfMass;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI Timer;
    public float Sec;
    public GameObject lostWindow;
    public GameObject Speedmeter;
    public GameObject WinScene;
    public GameObject MainScene;
    bool play = true;
    
    void Start()
    {
        CarRB = GetComponentInParent<Rigidbody>();
        CarRB.centerOfMass = _centerOfMass;
        Speedmeter.SetActive(true);        
    }
    void GetInputs()
    {
        MoveInput = Input.GetAxis("Vertical");
        SteerInput = Input.GetAxis("Horizontal");
    }
    void Update()
    {
        GetInputs();
        AnimationWheels();
        WheelEffect();
        timer();
        win();
    }
    void LateUpdate()
    {
        move();
        steer();
    }
    void move()
    {
        float currentSpeed = CarRB.velocity.magnitude * 2.23694f; // Convert m/s to mph
        if (currentSpeed < maxSpeed)
        {
            //Debug.Log((int)currentSpeed);
            speed.text = "SPEED = " + ((int)currentSpeed).ToString();
            foreach (var wheel in Wheels)
            {
                wheel.WheelCollider.motorTorque = maxAccesleration * MoveInput * 600 * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in Wheels)
            {
                wheel.WheelCollider.motorTorque = 0f; // Stop accelerating if max speed is reached
            }
        }
    }
    void steer()
    {
        foreach (var wheel in Wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = SteerInput * SteerSensityvity * MaxTurningAngle;
                wheel.WheelCollider.steerAngle = Mathf.Lerp(wheel.WheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }
    void AnimationWheels()
    {
        foreach (var wheel in Wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.WheelCollider.GetWorldPose(out pos, out rot);
            wheel.WheelModel.transform.position = pos;
            wheel.WheelModel.transform.rotation = rot;
        }
    }
    void WheelEffect()
    {
        foreach (var wheel in Wheels)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                wheel.WheelCollider.brakeTorque = breakAcceleration;
                if (wheel.axel == Axel.Rear)
                    wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
            }
            else
            {
                wheel.WheelCollider.brakeTorque = 0;
                if (wheel.axel == Axel.Rear)
                    wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Speedmeter.SetActive(false);
        Time.timeScale = 0f;
        lostWindow.SetActive(true);
    }
    void timer()
    {
        Sec -=Time.deltaTime;
        Timer.text = "Time Remaining = " + (int)Sec + "s";
        if (Sec < 0)
        {
            lostWindow.SetActive (true);
        }
    }
    public void win()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the visibility of MainScene
            MainScene.SetActive(!MainScene.activeSelf);
            Speedmeter.SetActive(!Speedmeter.activeSelf);

            // Adjust Time.timeScale based on visibility
            Time.timeScale = MainScene.activeSelf ? 0f : 1f;
        }


    }

}
