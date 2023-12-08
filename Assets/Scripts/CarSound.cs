using UnityEngine;

public class CarSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;
    private Rigidbody carRb;
    public AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    void Start()
    {
        carAudio = GetComponent<AudioSource>();
        carRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        EngineSound();   
    }
    void EngineSound()
    {
        currentSpeed=carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / 50f;
        if (currentSpeed < minSpeed)
        {
            carAudio.pitch = minPitch;
        }
        if(currentSpeed> minSpeed&&currentSpeed<maxSpeed)
        {
            carAudio.pitch = minPitch + pitchFromCar;
        }
        if(currentSpeed> maxSpeed)
        {
            carAudio.pitch=maxPitch;
        }
    }
}
