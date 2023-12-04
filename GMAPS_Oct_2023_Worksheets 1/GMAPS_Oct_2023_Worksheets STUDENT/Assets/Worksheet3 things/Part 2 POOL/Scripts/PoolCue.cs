using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position

            if (ball != null && ball.IsCollidingWith(startLinePos.x , startLinePos.y))
            { //check if the ball exist and check if the mouse is within the ball

                //if condition is true, start creating the line and show in the screen
                drawnLine = lineFactory.GetLine(startLinePos, startLinePos, 1f, Color.black);
                drawnLine.EnableDrawing(true);

            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //stop showing the line on the screen
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            //getting the direction from the start (end of the line) to the end of the line (the start of the line)
            HVector2D v = new HVector2D(drawnLine.start - drawnLine.end); 
            
            ball.Velocity = v; //setting that direction vector to the ball for it to start moving

            drawnLine = null; // stop referring to the line to prepare for the next input
        }

        if (drawnLine != null)
        {
            //this code is to draw the line such that players can see where the ball is hitting.
            //drawnLine.end = drawnLine.start * 2 - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            
            //But due to assignment constrant I use the original version
            //the line here is to set the line end to the mouse position. that way, 
            //the line will follow wherever the mouse is moving.
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
