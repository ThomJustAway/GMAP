using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    [SerializeField] private Vector3 rotation;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //get rigid body component
    }

    void FixedUpdate()
    {
        gravityDir =  planet.transform.position - transform.position ;
        moveDir = new Vector3(-gravityDir.y,gravityDir.x, 0f);
        // this is to get the vector perpendicular to the gravity 

        moveDir = moveDir.normalized;//change the directions (dont need to change the direction)

        rb.AddForce(moveDir * force); //add force to the moveDir to move mario

        gravityNorm = gravityDir.normalized; //normalize the gravity vector to ensure uniform gravity on mario
        rb.AddForce(gravityNorm * gravityStrength); //scale the vector to the gravity strength and apply the force on mario

        float angle = Vector3.SignedAngle(gravityNorm, Vector2.down, Vector3.forward);
        //get the angle of the mario needs to rotate base of the gravity direction

        rb.MoveRotation(Quaternion.Euler(0,0,-angle )); //rotate mario using the angle found

        DebugExtension.DebugArrow(transform.position,
            gravityNorm * gravityStrength, Color.red);
        DebugExtension.DebugArrow(transform.position,
                    moveDir * force, Color.blue);
        //for visual aid to see where the force is being applied on mario.
    }
}


