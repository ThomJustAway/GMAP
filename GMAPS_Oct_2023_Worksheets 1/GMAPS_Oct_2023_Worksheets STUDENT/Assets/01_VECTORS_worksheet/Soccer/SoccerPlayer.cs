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
        //linq method where it get all the gameobject with the soccer player component and filtering out the instance that call it.
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

        for(int i = 0; i < OtherPlayers.Length; i++) //go through all the players in the array
        {
            float dot = Dot(transform.forward, OtherPlayers[i].transform.position.normalized);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
            //find the angle of the player 
            if(angle < minAngle)
            {//check if the angle found is the closest
                minAngle = angle;
                closest = OtherPlayers[i];
                //if it is, then the player is closer than previous closer player. replace the closest player and angle 
            }
        }
        //after going through this loop, it means that we have found the closest player from the captain

        return closest;
    }

    void DrawVectors()
    {
        //this function is to draw the direction form transform to all the other players
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Vector3 direction = other.transform.position - transform.position;
            DebugExtension.DebugArrow(transform.position, direction, Color.red);
        }
    }

    void Update()
    {
        //DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        //DrawVectors();

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up); //rotate the captain

            //show the transform forward and the angle it is looking.
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(player => player != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;

            }
        }



    }



}


