using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;
    float a = Physics.gravity.y;
    float v = 0; //final velocity is 0

    private void Start()
    {
        //retrieve rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
     
        // v = 0, u = ?, a = Physics.gravity, s = Height

        // using the formula to calculate the final velocity u = sqrt(v*v - 2as)
        //where u is initial velocity, a is accleration and s is displacement
        float u = Mathf.Sqrt(v*v - 2 * a * Height); //finding the initial velocity to cover the height of 1f
        rb.velocity = new Vector3(0, u, 0); //apply the velociy of the RB

        //float jumpForce = Mathf.Sqrt(-2 * a * Height);
        //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

