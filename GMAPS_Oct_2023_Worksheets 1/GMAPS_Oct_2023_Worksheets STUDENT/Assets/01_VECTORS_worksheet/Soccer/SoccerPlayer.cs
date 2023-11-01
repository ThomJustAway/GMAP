using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(player => (player != this)).ToArray();
    }

    float Magnitude(Vector3 vector) //finding the vector 2
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
    }

    Vector3 Normalise(Vector3 vector)
    {
        return vector / Magnitude(vector);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x) + (vectorA.z * vectorB.z);
    }

    //SoccerPlayer FindClosestPlayerDot()
    //{
    //    SoccerPlayer closest = null;

    //    return closest;
    //}

    private SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for(int i = 0; i < OtherPlayers.Length; i++)
        {
            float dot = Dot(transform.forward, OtherPlayers[i].transform.position.normalized);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if(angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }
        }

        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Vector3 direction = other.transform.position - transform.position;
            DebugExtension.DebugArrow(transform.position, direction, Color.red);
            //Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red);
        }
    }

    void Update()
    {
        //DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        //DrawVectors();

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(player => player != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;

            }
        }

        //Part1();


    }

    private void Part1()
    {
        CaptainsMove();
        foreach (var other in OtherPlayers)
        {
            GetAngles(other.transform.position);
        }
    }

    private void GetAngles( Vector3 b)
    {
        float dotProduct = Dot(transform.forward, b);
        float ratio = dotProduct / (Magnitude(transform.forward) * Magnitude(b));
        float radian = Mathf.Acos(ratio);
        float angle = radian * Mathf.Rad2Deg;
        print(angle);
    }

    private void CaptainsMove()
    {
        if (IsCaptain)
        {
            DrawVectors();
            DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);
        }
    }
}


