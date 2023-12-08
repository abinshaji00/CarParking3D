using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSponer : MonoBehaviour
{
    [SerializeField] private Collectable prefab;
    [SerializeField] private Transform car;
    [SerializeField] private LineRenderer path;
    [SerializeField] private float pathHeightOffSet = 1.25f;
    [SerializeField] private float spawnHeightOffSet = 1.5f;
    [SerializeField] private float pathUpdateSpeed = 0.25f;
    private Collectable ActiveInstence;
    private NavMeshTriangulation triangulation;
    private Coroutine DrowPathCoroutine;

    private void Awake()
    {
        triangulation=NavMesh.CalculateTriangulation();
    }
    private void Start()
    {
        spawnNewObject();
    }
    public void spawnNewObject()
    {
        ActiveInstence = Instantiate(prefab, triangulation.vertices[Random.Range(0,triangulation.vertices.Length)]+Vector3.up*spawnHeightOffSet,Quaternion.Euler(90,0,0));
        ActiveInstence.Sponer=this; 
        if(DrowPathCoroutine != null)
        {
            StopCoroutine(DrowPathCoroutine);
        }
        DrowPathCoroutine = StartCoroutine(DrowPathTOCollectable());
    }
    private IEnumerator DrowPathTOCollectable()
    {
        WaitForSeconds wait = new WaitForSeconds(pathUpdateSpeed);
        NavMeshPath navMeshPath = new NavMeshPath();
        while (ActiveInstence != null)
        {
            if (NavMesh.CalculatePath(car.position, ActiveInstence.transform.position, NavMesh.AllAreas, navMeshPath))
            {
                path.positionCount= navMeshPath.corners.Length;
                for(int i = 0; i < navMeshPath.corners.Length; i++)
                {
                    path.SetPosition(i, navMeshPath.corners[i]+Vector3.up*pathHeightOffSet);
                }
            }
            else
            {
                Debug.LogError($"Unable to calclulate a path on the NaveMesh between{car.position}and {ActiveInstence.transform.position}!");
            }
            yield return wait;
        }
    }
}