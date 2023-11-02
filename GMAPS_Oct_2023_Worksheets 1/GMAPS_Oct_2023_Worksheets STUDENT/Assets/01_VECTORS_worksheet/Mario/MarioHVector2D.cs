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
        gravityDir = new HVector2D(planet.position - transform.position);  //get the gravity vector from player to planet
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x); //find the movement vector which is perpendicular to the player

        moveDir.Normalize(); //normalize the value movedirection to scale it later

        moveDir *= -1f; //reverse the direction of movedirection

        gravityDir.Normalize(); //normalize the value of the gravity direction to scale it later

        rb.AddForce(moveDir.ToUnityVector2() * force); //applying the movement force on the player 
        rb.AddForce(gravityDir.ToUnityVector2() * gravityStrength); //applying the gravity force on the player

        float angle = gravityDir.findangle(new HVector2D(0, -1)); //finding the angle require to rotate to show that it is facing the gravity direction

        rb.MoveRotation(Quaternion.Euler(0, 0, -angle)); //rotate mario based on that rotation

        DebugExtension.DebugArrow(transform.position,
            gravityDir.ToUnityVector3() * gravityStrength, Color.red);

        DebugExtension.DebugArrow(transform.position,
                    moveDir.ToUnityVector3() * force, Color.blue);
        //show the force acting on the player.
    }
}
