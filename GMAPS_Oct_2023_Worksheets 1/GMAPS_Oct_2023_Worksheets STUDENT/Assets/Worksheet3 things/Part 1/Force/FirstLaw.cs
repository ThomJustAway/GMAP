using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // getting the rigidbody
        rb.AddForce(force , ForceMode.Impulse); //add a sudden force on the rigidbody
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

