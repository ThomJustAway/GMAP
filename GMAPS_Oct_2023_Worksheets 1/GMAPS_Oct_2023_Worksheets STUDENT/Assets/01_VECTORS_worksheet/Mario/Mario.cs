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
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir =  planet.transform.position - transform.position ;
        moveDir = new Vector3(-gravityDir.y,gravityDir.x, 0f);
        // this is to get the vector perpendicular to the gravity

        moveDir = moveDir.normalized;//change the directions

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(gravityNorm, Vector2.down, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0,0,-angle ));

        DebugExtension.DebugArrow(transform.position,
            gravityNorm * gravityStrength, Color.red);
        DebugExtension.DebugArrow(transform.position,
                    moveDir * force, Color.blue);
    }
}


