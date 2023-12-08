using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform navigation;
    public Transform target;
    void Update()
    { 
        navigation.LookAt(target);
    }
}
