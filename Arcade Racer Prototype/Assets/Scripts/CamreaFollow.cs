using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaFollow : MonoBehaviour
{
    public Vector3 offset;
    public float smoothTime;
    public Vector3 velocity;

    public Transform follow_target;
    public Transform lookAt_target;

    public void FixedUpdate(){
      Vector3 targetPos = follow_target.position + offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

      Vector3 relativePos = lookAt_target.position - transform.position;

       // the second argument, upwards, defaults to Vector3.up
       Quaternion goal_rotation = Quaternion.LookRotation(relativePos, Vector3.up);
       transform.rotation = goal_rotation;
    }
}
