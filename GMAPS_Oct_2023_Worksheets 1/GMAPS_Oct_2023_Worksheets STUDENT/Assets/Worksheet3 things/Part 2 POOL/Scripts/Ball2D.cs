using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

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
        float distance = Util.FindDistance(Position, new HVector2D(x,y)); //get distance
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
        float displacementx = Velocity.x * deltatime;
        float displacementy = Velocity.y * deltatime;

        Position.x += displacementx;
        Position.y += displacementy;

        transform.position = new Vector2(Position.x , Position.y);
    }
}

