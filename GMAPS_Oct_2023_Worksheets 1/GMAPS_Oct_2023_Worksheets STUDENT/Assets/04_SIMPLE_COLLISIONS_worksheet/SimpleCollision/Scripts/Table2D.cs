// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Collision
// {
//     public class Table2D : MonoBehaviour
//     {
//         // A very simple demo class that requires the two balls to be set in the Inspector.
//         //
//         public GameObject white;
//         public Wall2D[] walls;

//         // References to the Ball script attached to each ball gameobject.
//         //
//         Ball2D whiteBall;

//         // For drawing the vectors, to show students.
//         bool paused = false;

//         void Start()
//         {
//             whiteBall = white.GetComponent<Ball2D>();
//         }

//         void Update()
//         {
//             // For pausing the scene to visualise the vectors involved.
//             // This isn't in your worksheet, but it just causes the ball
//             // to stop moving once a collision with the wall is detected.
//             // Look at the code below to figure out how it works.
//             //
//             // if (paused)
//             // {
//             //     return;
//             // }

//             foreach (Wall2D wall in walls)
//             {
//                 if (whiteBall.IsCollidingWith(wall))
//                 {
//                     /*Your code here*/

//                     // The code below is just for debugging. If the ball collides
//                     // with the wall, the ball will stop, the wall will be set to
//                     // red, and the -projectionVec and vf vectors will be drawn
//                     // (only in the Scene view - make sure the camera is in a 
//                     // position to see them).
//                     //
//                     // wall.GetComponent<SpriteRenderer>().material.color = Color.red;

//                     // DrawVector(white.transform.position, -projectionVec, Color.red);
//                     // DrawVector(white.transform.position, vf, Color.blue);

//                     // whiteBall.Velocity = Vector3.zero;
//                     // paused = true;
//                 }
//                 else
//                 {
//                     wall.GetComponent<SpriteRenderer>().material.color = Color.white;
//                 }
//             }
//         }


//         // A somewhat clunky function to draw all the vectors. This is really just to demo to students
//         // so that they can see it all drawn out in real time, and not just in powerpoint.
//         //
//         void DrawVector(Vector2 pos, Vector2 vec, Color col)
//         {
//             DebugExtension.DebugArrow(pos, vec, col, 100f);
//         }
//     }
// }
