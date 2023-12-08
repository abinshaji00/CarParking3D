using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoandmCars : MonoBehaviour
{
    public GameObject carBody1;
    public GameObject carBody2;
    public GameObject carBody3;
    public GameObject carBody4;
    public GameObject carBody5;
    private void Start()
    {
        selectRandom();
    }

    void selectRandom()
    {
        int carCount = 6;
        int selectedCar = Random.Range(1, carCount);
        SelectedCar(selectedCar);
    }
    void SelectedCar(int count)
    {
        if(count==1)
        {
            carBody1.SetActive(true);
            carBody2.SetActive(false);
            carBody3.SetActive(false);
            carBody4.SetActive(false);
            carBody5.SetActive(false);
        }
        else if(count==2)
        {
            carBody1.SetActive(false);
            carBody2.SetActive(true);
            carBody3.SetActive(false);
            carBody4.SetActive(false);
            carBody5.SetActive(false);
        }
        else if(count==3)
        {
            carBody1.SetActive(false);
            carBody2.SetActive(false);
            carBody3.SetActive(true);
            carBody4.SetActive(false);
            carBody5.SetActive(false);
        }
        else if(count==4)
        {
            carBody1.SetActive(false);
            carBody2.SetActive(false);
            carBody3.SetActive(false);
            carBody4.SetActive(true);
            carBody5.SetActive(false);
        }
        else
        {
            carBody1.SetActive(false);
            carBody2.SetActive(false);
            carBody3.SetActive(false);
            carBody4.SetActive(false);
            carBody5.SetActive(true);
        }
    }
}
