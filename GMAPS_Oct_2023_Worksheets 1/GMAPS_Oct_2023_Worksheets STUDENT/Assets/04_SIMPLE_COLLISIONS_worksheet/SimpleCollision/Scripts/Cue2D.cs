using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collision
{
    // Cue2D uses the LineDraw component to draw a line indicating the direction 
    // and magnitude to move the white ball.

    public class Cue2D : MonoBehaviour
    {
        // A better way is to check for a mousedown on any ball, so that any ball can
        // be "hit" by the cue. But this is just a simple demo, so the ball to hit is 
        // set in the Inspector (in thos demo, the white ball).
        //
        public GameObject ballGO;
        public LineFactory lineFactory;

        // Just to speed up the ball, or a very long line needs to be drawn.
        //
        public float speedFactor = 5f;

        private Line drawnLine;
        private Vector2 pos;

        // The Ball script
        //
        Ball2D ball;

        //void Start()
        //{
        //    ball = ballGO.GetComponent<Ball2D>();
        //}

        //void Update()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        float distance = ((Vector2)ball.transform.position - pos).magnitude;

        //        if (distance > ball.Radius)
        //        {
        //            return;
        //        }

        //        if (ball != null)
        //        {
        //            drawnLine = lineFactory.GetLine(pos, pos, 0.1f, Color.black);
        //            drawnLine.EnableDrawing(true);
        //        }
        //    }
        //    else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        //    {
        //        drawnLine.EnableDrawing(false);
        //        Vector2 velocity = new Vector2(drawnLine.start.x - drawnLine.end.x, drawnLine.start.y - drawnLine.end.y);

        //        // This is the physics part.
        //        //
        //        ball.Velocity = velocity * speedFactor;
        //        drawnLine = null;
        //    }

        //    if (drawnLine != null)
        //    {
        //        drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    }
        //}

        //public void Clear()
        //{
        //    var activeLines = lineFactory.GetActive();

        //    foreach (var line in activeLines)
        //    {
        //        line.gameObject.SetActive(false);
        //    }
        //}
    }
}
