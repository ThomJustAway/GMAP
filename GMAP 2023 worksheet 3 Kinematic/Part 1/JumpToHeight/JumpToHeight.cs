// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class JumpToHeight : MonoBehaviour
// {
//     public float Height = 1f;
//     Rigidbody rb;

//     private void Start()
//     {
//         rb = /*your code here*/;
//     }

//     void Jump()
//     {
//         // v*v = u*u + 2as
//         // u*u = v*v - 2as
//         // u = sqrt(v*v - 2as)
//         // v = 0, u = ?, a = Physics.gravity, s = Height

//         float u = Mathf.Sqrt(/*your code here*/);
//         rb.velocity = new Vector3(/*your code here*/);

//         //float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
//         //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
//     }

//     private void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Space))
//         {
//             /*your code here*/();
//         }
//     }
// }

