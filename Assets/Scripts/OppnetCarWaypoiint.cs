using UnityEngine;

public class OppnetCarWaypoiint : MonoBehaviour
{
    [Header("Opponet Car")]
    private OpponetCar opponetCar;
    [SerializeField] public  WayPoint currentWaypoint;

    private void Awake()
    {
        opponetCar = GetComponent<OpponetCar>();
    }
    private void Start()
    {
            opponetCar.LocateDestination(currentWaypoint.GetPosition());
    }
    private void FixedUpdate()
    {
        if(opponetCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.NextWaypoint;
            opponetCar.LocateDestination(currentWaypoint.GetPosition());
        }
    }
}
