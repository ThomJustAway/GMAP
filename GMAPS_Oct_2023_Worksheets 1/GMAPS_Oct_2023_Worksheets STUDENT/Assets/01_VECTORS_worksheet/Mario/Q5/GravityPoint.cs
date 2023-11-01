using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale = 12f, //force of gravity
        planetRadius = 2f, //overall planet radius?
        gravityMinRange = 1f, //?
        gravityMaxRange = 2f; //?

    public GameObject planet,
        minRS, 
        maxRS;

    // Start is called before the first frame update
    void Update()
    {
        minRS.transform.localScale = 
            new Vector3((planetRadius + gravityMinRange) * 2, 
            (planetRadius + gravityMinRange) * 2, 1);
        //changing the scale of the gravity


        maxRS.transform.localScale = 
            new Vector3((planetRadius + gravityMinRange + gravityMaxRange) * 2,
            (planetRadius + gravityMinRange + gravityMaxRange) * 2, 1);
        //changing the scale of max local scale
        GetComponent<CircleCollider2D>().radius = planetRadius + gravityMinRange + gravityMaxRange;
        //this piece of code is kind of useless since it expands the radius


        planet.transform.localScale = new Vector3(1f, 1f, 1f) * planetRadius * 2;
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        float gravitationalPower = gravityScale / planetRadius; //the further the players is away from the planet, the lesser the gravitational Power
        //negative value
        float dist = Vector2.Distance(obj.transform.position, transform.position); //finding the gravitation vector of the planet

        //if (dist > (planetRadius + gravityMinRange)) // check if the distance of the players out of distance from the minrange of the gravity
        //{
        //    float min = planetRadius + gravityMinRange + 0.5f; //this is the radius of both the planet and the min gravity range

        //    float ratio = ((min + gravityMaxRange) - dist) / gravityMaxRange;
        //    gravitationalPower *= ratio; //get the ratio to reduce the gravitational power
        //}


        Vector3 dir = (transform.position - obj.transform.position) * gravitationalPower;

        DebugExtension.DebugArrow(obj.transform.position, dir, Color.red);

        obj.GetComponent<Rigidbody2D>().AddForce(dir);


        if (obj.CompareTag("Player"))
        {
            //changing the obj up position to make sure it looks like it is on the planet
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravitationalPower * Time.deltaTime * 5f);
        }
    }
}
