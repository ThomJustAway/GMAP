using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0); //storing the position and velocity through
    public HVector2D Velocity = new HVector2D(0, 0); //custom made vector 2 component

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x; //storing the x and y coordinate to the position vector
        Position.y = transform.position.y;

        //get the sprite component and get the radius of the sprite
        Sprite sprite = GetComponent<SpriteRenderer>().sprite; 
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;


        //testing
        //HVector2D a = new HVector2D(5, 0);
        //HVector2D b = new HVector2D(0, 0);
        //print(Util.FindDistance(a, b));

    }

    public bool IsCollidingWith(float x, float y)
    {
        /*get the distance between the ball position and a specified postion in space
        check if the distance is less or equal to the radius
        if true, it means that the specified space is within the ball
        */
        float distance = Util.FindDistance(Position, new HVector2D(x,y)); 
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        updateball2dphysics(Time.deltaTime);
    }

    private void updateball2dphysics(float deltatime)
    {
        //find the displacement travelled by the ball through the velocity
        //inputted by the pool cue. using the formula: S = V * T
        // s = displacement, V = velocity and T = time
        float displacementx = Velocity.x * deltatime;
        float displacementy = Velocity.y * deltatime;

        //after finding the displacement for x and y, add it to the current 
        //position to show the movement
        Position.x += displacementx;
        Position.y += displacementy;
        
        //applying the final position on to Unity.
        transform.position = new Vector2(Position.x , Position.y);
    }
}

