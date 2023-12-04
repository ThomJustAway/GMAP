using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[,]
        {
            {1, 0 , 0 },
            {0, 1 , 0 },
            {0 , 0 , 1}
        } ;
    }

    public HMatrix2D(float[,] multiArray)
    {
        //does not use reference of the 
        for(int row = 0; row < multiArray.GetLength(0); row++) //for each row
            for(int col = 0; col < multiArray.GetLength(1); col++) //for each col
                entries[row,col] = multiArray[row,col]; //set the value of the multiarray value to the entries
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {

        entries = new float[,] 
        { {m00, m01, m02 }, 
            {m10, m11, m12 }, 
            {m20, m21, m22 } };
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //make a new instance so as to prevent reference
        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0) , left.entries.GetLength(1)]);

        for(int i = 0; i < left.entries.GetLength(0); i++) //for each row
            for(int j = 0; j <left.entries.GetLength(1); j++) //for each col
                dummy.entries[i,j] = left.entries[i,j] + right.entries[i,j]; 
        //set the dummy value of that specific row and column to the sum of the left and right matrix specifc row/col

        return dummy;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        //make a new instance so as to prevent reference
        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0), left.entries.GetLength(1)]);

        for (int i = 0; i < left.entries.GetLength(0); i++) //for each row
            for (int j = 0; j < left.entries.GetLength(1); j++) //for each col
                dummy.entries[i, j] = left.entries[i, j] - right.entries[i, j];
        //set the dummy value of target row and column of the resulting value of the substraction of left and right of the row and col.

        return dummy;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //make a new instance so as to prevent reference
        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0), left.entries.GetLength(1)]);

        for (int i = 0; i < left.entries.GetLength(0); i++) //for each row
            for (int j = 0; j < left.entries.GetLength(1); j++) //for each col
                dummy.entries[i, j] = left.entries[i, j] * scalar;
        //set the dummy value of target row and column to the resulting value of the left and right multiplication specific row and col
        
        return dummy;
    }

    //// Note that the second argument is a HVector2D object
    ////
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //the result value for a 3x3 matrix * 1x3 matrix (vector) is 1x3 matrix (vector)
        return new HVector2D(
        //the dot product of the left matrix first col with the vector row
        ((left.entries[0, 0] * right.x) + (left.entries[0, 1] * right.y) + (left.entries[0, 2] * right.h)) , 
        //the dot product of the left matrix second col with the vector row
        ((left.entries[1, 0] * right.x) + (left.entries[1, 1] * right.y) + (left.entries[1, 2] * right.h))
        );

    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {        
        HMatrix2D dummyMatrix = new HMatrix2D(new float[left.entries.GetLength(0), right.entries.GetLength(1)]);
        //use a dummy matrix so as to not make any changes to the left and right matrix.

        for(int i = 0; i < left.entries.GetLength(0);i++)
        {//Go through each row of the left matrix
            for(int j = 0; j < right.entries.GetLength(1); j++)
            { //would go through each col of the right matrix to add them up together
                float sum = 0; //start initialising the a int variable
                for(int k = 0;  k < left.entries.GetLength(1); k++) 
                //need to iterate over all the values in selected row and col to multiply them together. Afterward add it to the sum
                { //as the left col == right row, we can sum them up
                    sum += left.entries[i, k] * right.entries[k, j]; //multiply the two values together and add them to the total sum of the left col and right row
                }
                dummyMatrix.entries[i, j] = sum; //adding it in the matrix
            }
        }

        return dummyMatrix;
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.entries.GetLength(0); i++) //for each row
            for (int j = 0; j < right.entries.GetLength(1); j++) //for each col
                if (left.entries[i, j] != right.entries[i, j]) return false; 
        //check if the each value from both end are equal. if not then return false
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        //if not both equal, then return false else return true
        return !(left == right);
    }

    //public override bool equals(object obj)
    //{

    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    public HMatrix2D Transpose()
    {
        //make a copy of it so that it does not change the actually data
        //the copy rows will be the this matrix columns and vice versa. to make it transpose
        HMatrix2D result = new HMatrix2D(new float[entries.GetLength(1), entries.GetLength(0)]);

        for(int row = 0; row < entries.GetLength(0); row++) //for each row
            for(int col = 0; col < entries.GetLength(1); col++) //for each col
                result.entries[col, row ] = entries[row, col];
        // the entries row col would be the column row of the copy.
        return result;
    }

    public float GetDeterminant()
    {
        //ad - bc
        if(entries.GetLength(0) != 2 && entries.GetLength(1) != 2)
        {
            throw new InvalidOperationException("Require 2 by 2 matrix");
        }
        return entries[0,0] * entries[1,1] - entries[0,1] * entries[1,0];
    }

    public void SetIdentity()
    {
        //if the matrix is not 3*3 Ignore this 
        if(entries.GetLength(0) != entries.GetLength(1))
        {
            throw new InvalidOperationException("matrix must have the same column and row");
        }

        //for (int i = 0; i < entries.GetLength(0); i++) //for each row
        //{
        //    for (int j = 0; j < entries.GetLength(1); j++) //for each column
        //    {//the purpose of this problem is to set all the values in the diagonal 1 and anything else 0.
        //        if (i == j)
        //        {
        //            entries[i, j] = 1; //if row and column is the same, it mean it is diagonal so set it to 1
        //        }
        //        else
        //        {
        //            entries[i, j] = 0; //else set it to zero
        //        }
        //    }
        //}
        //normal version

        for (int i = 0; i < entries.GetLength(0); i++)
            for (int j = 0; j < entries.GetLength(1); j++)
                entries[i , j] = i == j ? 1 : 0; //three liner
        //ternary operator
    }

    public void SetTranslationMat(float transX, float transY)
    {
        //reset the matrix to become an identity matrix
        SetIdentity(); 
        entries[0,2] = transX; //the x and y translation in homogenous coordinate
        entries[1,2] = transY;  
        
    }

    public void SetRotationMat(float rotDeg)
    {
        float rad = rotDeg * Mathf.Deg2Rad; //convert to rad
        SetIdentity(); //reset the matrix to a identity matrix

        //[ [cos a , -sin a] , [ sin a , cos a]] following the formula afterwards

        entries[0,0] = MathF.Cos(rad);
        entries[0, 1] = -MathF.Sin(rad);
        entries[1, 0] = MathF.Sin(rad);
        entries[1, 1] = MathF.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        SetIdentity(); //reset the matrix
        //scaling matrix [[scaleX, 0], [0, scaleY]]
        //follow the scaling matrix
        entries[0,0] = scaleX; 
        entries[1,1] = scaleY;
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < entries.GetLength(0); r++)
        {
            for (int c = 0; c < entries.GetLength(1); c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
