using Unity.VisualScripting;
using UnityEngine;

public class TrigerActive : MonoBehaviour
{
    FinishTrigger finish;
    public bool count;
    private void Start()
    {
        finish = GetComponent<FinishTrigger>();
        count = false;
    }
    private void OnTriggerEnter()
    {
        count = true;
    }
    private void OnTriggerExit()
    {
       count= false;
    }
}
