using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public Rigidbody rb;

    public float hoverHight;

    public force thrust_force;
    public force break_force;
    public force spinRight_force;
    public force spinLeft_force;
    public List<force> lift_forces;

    public void FixedUpdate(){
      for(int i=0; i < lift_forces.Count; ++i){
        Vector3 pos = GetForcePositon(lift_forces[i]);
        Vector3 dir = GetForceDirection(lift_forces[i]);

        if (Physics.Raycast(pos, -dir, hoverHight)){
          rb.AddForceAtPosition(dir, pos);
          Debug.Log("Adding Lift");
        }

        Vector3 debugRay = new Vector3(0, -hoverHight, 0);
        Debug.DrawRay(pos, -dir, Color.red, 0.0f, true);
      }

      if(Input.GetKey("w")){
        Vector3 pos = GetForcePositon(thrust_force);
        Vector3 dir = GetForceDirection(thrust_force);

        rb.AddForceAtPosition(dir, pos);

        Debug.DrawRay(pos, -dir, Color.blue, 0.0f, true);
      }

      if(Input.GetKey("s")){
        Vector3 pos = GetForcePositon(break_force);
        Vector3 dir = GetForceDirection(break_force);

        rb.AddForceAtPosition(dir, pos);

        Debug.DrawRay(pos, -dir, Color.blue, 0.0f, true);
      }

      if(Input.GetKey("d")){
        Vector3 pos = GetForcePositon(spinRight_force);
        Vector3 dir = GetForceDirection(spinRight_force);

        rb.AddForceAtPosition(dir, pos);

        Debug.DrawRay(pos, -dir, Color.blue, 0.0f, true);
      }

      if(Input.GetKey("a")){
        Vector3 pos = GetForcePositon(spinLeft_force);
        Vector3 dir = GetForceDirection(spinLeft_force);

        rb.AddForceAtPosition(dir, pos);

        Debug.DrawRay(pos, -dir, Color.blue, 0.0f, true);
      }
    }

    private Vector3 GetForcePositon(force input){
      //return rb.transform.position + input.origin;

      return transform.TransformPoint(input.origin);
    }

    private Vector3 GetForceDirection(force input){
      return transform.TransformVector(input.direction);
    }

    //private void DrawRay(Vector3 origin, )
}
