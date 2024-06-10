using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float smoothTime = 0.3f; 

    private Vector3 velocity = Vector3.zero;
    switching switchings;
    private void Start()
    {
        switchings = FindObjectOfType<switching>();
    }

    void LateUpdate()
    {
        if (target1 != null && switchings.playerWithSword.activeSelf)
        {
            Vector3 targetPosition = new Vector3(target1.position.x, target1.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (target2 != null && switchings.playerWithBow.activeSelf)
        {
            Vector3 targetPosition = new Vector3(target2.position.x, target2.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
