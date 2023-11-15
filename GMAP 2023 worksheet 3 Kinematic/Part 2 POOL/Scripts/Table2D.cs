using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls;

    private void Start()
    {

    }

    bool CheckBallCollision(Ball2D toCheck)
    {
        //for (int i = 0; i < balls.Count; i++)
        {
            Ball2D ball = balls[1];

            if (ball.IsCollidingWith(toCheck) && toCheck != ball)
            {
                return true;
            }
        }

        return false;
    }

    private void FixedUpdate()
    {
        if (CheckBallCollision(balls[0]))
        {
            Debug.Log("COLLISION!");
        }
    }
}
