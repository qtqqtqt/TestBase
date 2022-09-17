using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float dampTime = 0.15f;


    Vector3 offset;
    Vector3 velocity = Vector3.zero;


    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, dampTime);
    }

    

   
}
