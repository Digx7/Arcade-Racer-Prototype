using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class lift_force : force
{
    public float min_height;
    public float max_height;

    private float height;
    public float current_height{get{return height;}}

    public void setToMinHeight(){height=min_height;}
    public void setToMaxHeight(){height=max_height;}

    public void setUp(){setToMaxHeight();}
}
