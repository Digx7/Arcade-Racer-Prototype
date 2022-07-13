using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public Rigidbody rb;

    public float flyHeight;

    public force thrust_force;
    public force break_force;
    public force spinRight_force;
    public force spinLeft_force;
    public List<lift_force> lift_forces;

    public force antiFly_force;

    public void Awake(){
      lift_forces.ForEach(setUpLiftForce);
    }

    public void FixedUpdate(){
      adjustLiftForceHeights();
      for(int i=0; i < lift_forces.Count; ++i){
        applyLiftForce(lift_forces[i]);
      }

      if(Input.GetKey("space")) applyForce(thrust_force);
      if(Input.GetKey("b")) applyForce(break_force);
      if(Input.GetKey("a")) applyForce(spinLeft_force);
      if(Input.GetKey("d")) applyForce(spinRight_force);

      Vector3 pos = GetForcePositon(antiFly_force);
      Vector3 dir = GetForceDirection(antiFly_force);
      if (!Physics.Raycast(pos, dir, flyHeight)){
        rb.AddForceAtPosition(antiFly_force.direction, antiFly_force.origin + transform.position);
        Debug.Log("Applying AntiFly Force");
      }
      Debug.DrawRay(pos, dir, Color.green, 0.0f, true);
    }

    private void setUpLiftForce(lift_force input){
      input.setUp();
    }

    private void applyLiftForce(lift_force input){
        Vector3 pos = GetForcePositon(input);
        Vector3 dir = GetForceDirection(input);

        if (Physics.Raycast(pos, -dir, input.current_height)){
          rb.AddForceAtPosition(dir, pos);
        }
        Debug.DrawRay(pos, -dir, Color.red, 0.0f, true);
    }

    private void adjustLiftForceHeights(){
      lift_forces.ForEach(setUpLiftForce);
      if(Input.GetKey("w")){
        lift_forces[0].setToMinHeight();
        lift_forces[1].setToMinHeight();
      }
      if(Input.GetKey("s")){
        lift_forces[2].setToMinHeight();
        lift_forces[3].setToMinHeight();
      }
      if(Input.GetKey("a")){
        lift_forces[0].setToMinHeight();
        lift_forces[2].setToMinHeight();
      }
      if(Input.GetKey("d")){
        lift_forces[1].setToMinHeight();
        lift_forces[3].setToMinHeight();
      }
    }

    private void applyForce(force input){
      Vector3 pos = GetForcePositon(input);
      Vector3 dir = GetForceDirection(input);

      rb.AddForceAtPosition(dir, pos);

      Debug.DrawRay(pos, -dir, Color.blue, 0.0f, true);
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
