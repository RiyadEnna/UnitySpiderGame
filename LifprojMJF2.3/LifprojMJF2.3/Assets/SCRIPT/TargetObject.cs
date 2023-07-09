using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        //Vector3 targetPosition = new Vector3(target.transform.position.x, 0, target.transform.position.x);
        transform.LookAt(target);
    }
}