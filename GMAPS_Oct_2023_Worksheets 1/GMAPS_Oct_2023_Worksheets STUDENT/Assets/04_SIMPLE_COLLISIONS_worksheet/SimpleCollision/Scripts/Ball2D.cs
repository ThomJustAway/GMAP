// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Collision
// {
//     public class Ball2D : MonoBehaviour
//     {
//         [Range(0f, 1f)]
//         public float CoeffRestitution = 1f;
//         public float Mass = 1f;
//         public float Radius { get; private set; }

//         // Let the ball have an initial velocity set in the Inspector.
//         //
//         public Vector2 Velocity = Vector3.zero;

//         void Start()
//         {
//             Radius = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
//         }

//         public bool IsCollidingWith(float x, float y)
//         {
//             return IsCollidingWith(new Vector2(x, y));
//         }

//         public bool IsCollidingWith(Vector2 other)
//         {
//             float distance = Vector2.Distance(transform.position, other);
//             return distance <= Radius;
//         }

//         // For collision between two balls. You aren't required to do this
//         // in the worksheet.
//         //
//         public bool IsCollidingWith(Ball2D other)
//         {
//             Vector3 dirVec = transform.position - other.transform.position;

//             // OPTIMISE -- Can be optimised using sqrMagnitude
//             //
//             return dirVec.magnitude < Radius + other.Radius;
//         }

//         public bool IsCollidingWith(Wall2D other)
//         {
//             // If either end of the wall is inside the ball, then a collision
//             // has occured. See page 6 of the worksheet for an explanation of
//             // what the top and bottom ganme objects are used for. (Basically,
//             // if either the top or bottom game objects are colliding with the
//             // ball, then we consider this a collision.)
//             //
//             if (IsCollidingWith(other.top.transform.position) || IsCollidingWith(other.bottom.position))
//             {
//                 return true;
//             }

//             // VectorA in the lecture slides.
//             //
//             Vector2 lineToPointVec = /*Your code here*/;

//             // VectorB.
//             //
//             float proj = /*Your code here*/;

//             // If the projection is -ve (before the start of the line segment) or
//             // greater than the length of the line , then there's no collision.
//             // Can you figure out why we have this here? Draw a diagram to explain
//             // the concept.
//             //
//             if (proj < 0 || proj > other.wallVec.magnitude)
//             {
//                 return false;
//             }

//             // Calculate perpendicular distance using Pythagoras Theorem
//             //
//             float distanceFromLine = /*Your code here*/;

//             //DebugExtension.DebugArrow(other.center, -other.normalVec * 5, Color.red);
//             //DebugExtension.DebugArrow(other.bottom.transform.position, proj * other.vec.normalized, Color.red, 100f);

//             return distanceFromLine /*Your code here*/ Radius * 1.25f;
//         }

//         // Moving the ball.
//         //
//         void Update()
//         {
//             float displacementX = Velocity.x * Time.deltaTime;
//             float displacementY = Velocity.y * Time.deltaTime;

//             transform.Translate(new Vector2(displacementX, displacementY));
//         }
//     }
// }
