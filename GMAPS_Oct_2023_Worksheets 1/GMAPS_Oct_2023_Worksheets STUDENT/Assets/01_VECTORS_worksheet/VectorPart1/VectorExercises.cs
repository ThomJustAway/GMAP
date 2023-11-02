using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;

    }

    void Question2a()
    {
        startPt = Vector2.zero;
        endPt = new Vector2(2,3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        //finding the vector from endpt to startpt

        //printing the magnitude of the vector
        Debug.Log("Magnititude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        for(int i = 0 ; i < n; i++) //repeating this for n number of times
        {
            startPt = new Vector2(
                Random.Range(minX,maxX),
                Random.Range(minY,maxY));

            endPt = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY));
            //select a random point in the -5, 5 (represented in miny and minx) in the x and y space.
            //Create two vectors based of the random values created called start and end pt.

            //this is combined with question 2C if you remove the CalculateGameDimensions function at the start function.

            drawnLine = lineFactory.GetLine(startPt, endPt , 0.02f , Color.black);
            //draw the line based of the random pt.

            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0,0,0),
            new Vector3(5,5,0),
            Color.red,
            60f
            );
        //2d is just a copy - paste code so nothing to see here
    }
     
    void Question2e(int n)
    {
        int minZ = -20;
        int maxZ = -minZ; //setting up random value for the z axis (for 3 dimension view)

        for (int i = 0; i < n; i++)
        {
            Vector3 endpoint = new Vector3(Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY),
                Random.Range(minZ, maxZ));

            /*same as 2b where this time round, select random values
             * for the x, y and z coordinate based of the min and max range 
             * for said coordinate. Afterwards, use this random values
             * to create a vector 3 endpt.
             */


            DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
                endpoint,
                Color.white,
                60f); 
            //use the end point to draw the arrow using vector.zero as the start point.
    }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b; //creating the vectors for a, b and c respectively

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        //creating the vectors form vector.zero to a, b and c respectively. Using the respective colors 

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f );
        //drawing the vector b with a head as the starting point.

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("0.00"));
        Debug.Log("Magnitude of a = " + b.Magnitude().ToString("0.00"));
        Debug.Log("Magnitude of a = " + c.Magnitude().ToString("0.00"));
        //printing the values of the magnitude
        //remodified code for 3a

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3() , Color.green , 60f);
        //drawing -b vector from a head
        DebugExtension.DebugArrow(Vector3.zero, (a - b).ToUnityVector3(), Color.white, 60f);
        //drawing the resulting vector a-b from vector zero
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a * 2; //scaling a by 2 to form b

        HVector2D newA = a / 2; //scaling a by half to form the modified vector


        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.left, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.right, newA.ToUnityVector3(), Color.green, 60f);
        //drawing out the vectors created with one offset
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //drawing a at the origin
        a.Normalize();
        //normalize the value of a
        DebugExtension.DebugArrow(Vector3.left, a.ToUnityVector3(), Color.red, 60f);
        //draw normalize vector a
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("0.00"));
        //show that the magnitude of a is 1.
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0); 
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a; //bruh the same thing. v1 is still b

        HVector2D proj = c.Projection(v1); //get the projected vector of c on v1 (b).


        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);

        //draw the arrows.

    }
}
