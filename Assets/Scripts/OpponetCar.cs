using UnityEngine;

public class OpponetCar : MonoBehaviour
{
    [Header("Car Engine")]
    [SerializeField] private float movingSpeed;
    [SerializeField] private float turningSpeed=50f;
    [SerializeField] private float breakSpeed=12f;

    [Header("Destination Variable")]
    private Vector3 destination;
    public bool destinationReached;

    private void FixedUpdate()
    {
        Drive();
    }
    private void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection =  destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance =destinationDirection.magnitude;

            if(destinationDistance >= breakSpeed)
            {
                destinationReached = false;
                Quaternion targetrotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, turningSpeed*Time.deltaTime);

                transform.Translate(Vector3.forward*movingSpeed*Time.deltaTime);
            }
            else
            {
                destinationReached=true;
            }
        }
    }
    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

}
