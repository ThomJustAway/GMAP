using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        // Your code here
        // ...

        moveDir.Normalize();

        moveDir *= -1f;

        gravityDir.Normalize();

        rb.AddForce(moveDir.ToUnityVector2() * force);
        gravityDir.Normalize();
        rb.AddForce(gravityDir.ToUnityVector2() * gravityStrength);

        float angle = gravityDir.findangle(new HVector2D(0, -1));

        //Debug.Log(-angle);

        //first half needs to be negative
        //next half will start with positive;

        rb.MoveRotation(Quaternion.Euler(0, 0, -angle));


        DebugExtension.DebugArrow(transform.position,
            gravityDir.ToUnityVector3() * gravityStrength, Color.red);

        DebugExtension.DebugArrow(transform.position,
                    moveDir.ToUnityVector3() * force, Color.blue);

    }
}
