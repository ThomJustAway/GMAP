using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return (p2 - p1).Magnitude();
        //find the vector from p2 to p1 (other way also works) and getting the magnitude of that vector
        //using the formula: magnitude of vector = sqrt(A^2 + b^2)
    }
}

