using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime; //rate of change in time

        float dx = Velocity.x *dt; //distance travel during a set velocity in the X axis
        float dy = Velocity.y *dt; //distance travel during a set velocity in the y axis
        float dz = Velocity.z *dt; //distance travel during a set velocity in the Z axis

        transform.Translate(new Vector3(dx,dy,dz));
        //add the distance traveled in the x y and z position to the transform. That way, it simulate movement
    }
}
