using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float followSpeed;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (target)
        {
            targetPos = target.transform.position;
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, followSpeed);

        }
    }
}
