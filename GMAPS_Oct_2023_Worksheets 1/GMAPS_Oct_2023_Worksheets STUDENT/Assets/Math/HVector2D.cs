using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Drawing.Printing;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x , a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);

    }

    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a , float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public float Magnitude()
    {
        return math.sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float mag = Magnitude();
        x /= mag;
        y /= mag;
    }

    public float DotProduct(HVector2D nextVector)
    {
        //does not matter the position of it
        return (x * nextVector.x) + (y * nextVector.y);
    }

    public HVector2D Projection(HVector2D projectedVector)
    {
        // suppose to do a projection from this vector to the projected vector
        //this will get the scale of the current vector on the projected vector and then scale down the current vector
        HVector2D dummyProjectedVector = new HVector2D(projectedVector.x, projectedVector.y);
        dummyProjectedVector.Normalize();
        return dummyProjectedVector * dummyProjectedVector.DotProduct(this);

        //there is still another formula to use but that is fine.

        //thought was that dot product is projectlength * magnitude of the length. 

    }

    public float CrossProduct(HVector2D projectedVector , float angle)
    {
        return projectedVector.Magnitude() * this.Magnitude() * math.sin(angle) ;
    }

    public float findangle(HVector2D vectorToMeasuredAgainst)
    {
        float dotproduct = this.DotProduct(vectorToMeasuredAgainst);
        float ratio = dotproduct / (this.Magnitude() * vectorToMeasuredAgainst.Magnitude());
        //normalize both vector to measure the dot product.
        float angle = math.acos(ratio) * (180/math.PI); 
        //find the angle using the formula 

        //found the resource here https://stackoverflow.com/questions/2150050/finding-signed-angle-between-vectors

        if ((this.x * vectorToMeasuredAgainst.y - this.y * vectorToMeasuredAgainst.x ) < 0)
        {//figure out if the angle is clockwise or not.
            angle = -angle;
        }

        return angle;
    }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0);
    }

    public void Print()
    {
        Debug.Log($"x: {x} y: {y}");
    }
}
