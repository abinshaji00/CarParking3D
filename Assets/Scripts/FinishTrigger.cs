using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    TrigerActive triger;
    public GameObject win;
    public GameObject parking;
    private bool isFinished = false;
    public GameObject front;
    public GameObject back;
    private void Start()
    {
        triger = GetComponentInChildren<TrigerActive>();
    }
    private void Update()
    {
        if (front.GetComponent<TrigerActive>().count&&back.GetComponent<TrigerActive>().count==true)
        {
            isFinished = true;
        }
        else
            isFinished = false;

        if (isFinished == true)
        {
            parking.SetActive(true);
            if (Input.GetKey(KeyCode.P))
                parked();
        }
        else
            parking.SetActive(false);
        
    }
    public void parked()
    {
        win.SetActive(true);
        Time.timeScale = 0f;
    }
}

