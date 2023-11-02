using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        return vector / Magnitude(vector);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x) + (vectorA.y * vectorB.y) + (vectorA.z * vectorB.z); 
    }

    float AngleToPlayer(Vector3 a , Vector3 b)
    {
        a = Normalise(a);
        b = Normalise(b);
        //formula
        return Mathf.Acos(Dot(a , b)) * Mathf.Rad2Deg;
    }

    void Update()
    {
        Vector3 direction = OtherPlayer.transform.position - transform.position;
        //find the vector from the transform to the other player. call this the direction
        if (IsCaptain)
        {
            DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);
            DebugExtension.DebugArrow(transform.position, direction, Color.red);
            //show the direction of the captain forward and the vector of the other player in the scene view.
        }
        //calculate the angle of the player from the transform forward to the direction
        float angle = AngleToPlayer(transform.forward, direction);
        Debug.Log($"{name} --> {OtherPlayer.name}: angle {angle}");
        //show the angle through the debugger
    }
}
