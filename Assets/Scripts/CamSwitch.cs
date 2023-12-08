using Cinemachine;
using System.Collections;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform InsideFollowTarget;
    public Transform OutsideFollowTarget;
    private bool isSwitching = false;
    public float switchCooldown = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isSwitching)
        {
            if (vcam.LookAt == OutsideFollowTarget)
            {
                vcam.LookAt = InsideFollowTarget;
                vcam.Follow = InsideFollowTarget;
            }
            else
            {
                vcam.LookAt = OutsideFollowTarget;
                vcam.Follow = OutsideFollowTarget;
            }

            isSwitching = true;
            StartCoroutine(EnableSwitchingAfterCooldown());
        }
    }

    private IEnumerator EnableSwitchingAfterCooldown()
    {
        yield return new WaitForSeconds(switchCooldown);
        isSwitching = false;
    }
}
