using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelect : MonoBehaviour
{
    public GameObject carRed;
    public GameObject carPurple;
    public GameObject carBlue;
    public GameObject carWhite;
    public GameObject carYellow;

    public void Red()
    {
        carRed.SetActive(true);
        carPurple.SetActive(false);
        carBlue.SetActive(false);
        carWhite.SetActive(false);
        carYellow.SetActive(false);
    }
    public void Purple()
    {
        carPurple.SetActive(true);
        carBlue.SetActive(false);
        carWhite.SetActive(false);
        carYellow.SetActive(false);
        carRed.SetActive(false);
    }
    public void Blue()
    {
        carBlue.SetActive(true);
        carWhite.SetActive(false);
        carYellow.SetActive(false);
        carRed.SetActive(false);
        carPurple.SetActive(false);
    }
    public void White()
    {
        carWhite.SetActive(true);
        carYellow.SetActive(false);
        carRed.SetActive(false);
        carPurple.SetActive(false);
        carBlue.SetActive(false);
    }
    public void Yellow()
    {
        carYellow.SetActive(true);
        carRed.SetActive(false);
        carPurple.SetActive(false);
        carBlue.SetActive(false);
        carWhite.SetActive(false);
    }
}
