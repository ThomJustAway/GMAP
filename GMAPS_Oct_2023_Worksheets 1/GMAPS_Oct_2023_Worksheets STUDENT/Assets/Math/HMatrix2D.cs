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
        entries = multiArray;
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
        if(left.entries.GetLength(0) != right.entries.GetLength(0) && left.entries.GetLength(1) != right.entries.GetLength(1))
        {
            throw new InvalidOperationException("cant do operation with different length type");
        }

        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0) , left.entries.GetLength(1)]);
        
        for(int i = 0; i < left.entries.GetLength(0); i++)
        {
            for(int j = 0; j <left.entries.GetLength(1); j++)
            {
                dummy.entries[i,j] = left.entries[i,j] + right.entries[i,j];
            }
        }

        return dummy;

    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        if (left.entries.GetLength(0) != right.entries.GetLength(0) && left.entries.GetLength(1) != right.entries.GetLength(1))
        {
            throw new InvalidOperationException("cant do operation with different length type");
        }

        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0), left.entries.GetLength(1)]);

        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                dummy.entries[i, j] = left.entries[i, j] - right.entries[i, j];
            }
        }

        return dummy;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D dummy = new HMatrix2D(new float[left.entries.GetLength(0), left.entries.GetLength(1)]);

        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                dummy.entries[i, j] = left.entries[i, j] * scalar;
            }
        }

        return dummy;
    }

    //// Note that the second argument is a HVector2D object
    ////
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        if (left.entries.GetLength(1) != 2 || left.entries.GetLength(0) != 2 )
        {
            throw new InvalidOperationException("The column of the 2D matrix is not the same as the vector");
        }

        return new HVector2D(
                ((left.entries[0, 0] * right.x) + (left.entries[0, 1] * right.y)) ,
                ((left.entries[1, 0] * right.x) + (left.entries[1, 1] * right.y))
                );

        

    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        if (left.entries.GetLength(1) != right.entries.GetLength(0)) throw new InvalidOperationException("left column must be the same as right row");
        //making sure that the col of left is the same as the right row
        
        HMatrix2D dummyMatrix = new HMatrix2D(new float[left.entries.GetLength(0), right.entries.GetLength(1)]);
        //init matrix

        for(int i = 0; i < left.entries.GetLength(0);i++)
        {//when multiply, use the row
            for(int j = 0; j < right.entries.GetLength(1); j++)
            { //would require the col of the right to multiply them together
                float sum = 0;
                for(int k = 0;  k < left.entries.GetLength(1); k++) //need to iterate over all the values in selected left row to multiply and add them together
                {//as the left col == right row, we can sum them up
                    sum += left.entries[i, k] * right.entries[k, j]; //multiply the two values together and add them to the total sum of the left col and right row
                }
                dummyMatrix.entries[i, j] = sum; //adding it in the matrix
            }
        }

        return dummyMatrix;
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        if (left.entries.GetLength(0) != right.entries.GetLength(0) && left.entries.GetLength(1) != right.entries.GetLength(1))
        {
            //made sure that the left and right values are the same. else return false
            return false;
        }

        //big(o) of n^2

        //for(int i = 0; i < left.entries.GetLength(0);i++)
        //{
        //    for(int j = 0; j < left.entries.GetLength(1); j++)
        //    {
        //        if (left.entries[i, j] != right.entries[i, j]) return false;
        //    }
        //}
        //return true;

        for (int i = 0; i < left.entries.GetLength(0); i++)
            for (int j = 0; j < right.entries.GetLength(1); j++)
                if (left.entries[i, j] != right.entries[i, j]) return false;
        return true;

        
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        if (left.entries.GetLength(0) != right.entries.GetLength(0) && left.entries.GetLength(1) != right.entries.GetLength(1))
        {
            //made sure that the left and right values are the same. else return false
            return true;
        }

        //big(o) of n^2
        //reverse of ==
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                if (left.entries[i, j] == right.entries[i, j]) return true;
            }
        }
        return false;
    }

    //public override bool equals(object obj)
    //{

    //    // your code here
    //}5

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    public HMatrix2D transpose()
    {
        HMatrix2D result = new HMatrix2D(new float[entries.GetLength(1), entries.GetLength(0)]);

        for(int row = 0; row < entries.GetLength(0); row++)
        {
            for(int col = 0; col < entries.GetLength(1); col++)
            {
                result.entries[col, row ] = entries[row, col];
            }
        }

        return result;
    }

    public float getDeterminant()
    {
        //ad - bc
        if(entries.GetLength(0) != 2 && entries.GetLength(1) != 2)
        {
            throw new InvalidOperationException("Require 2 by 2 matrix");
        }
        return entries[0,0] * entries[1,1] - entries[0,1] * entries[1,0];
    }

    public void setIdentity()
    {
        if(entries.GetLength(0) != entries.GetLength(1))
        {
            throw new InvalidOperationException("matrix must have the same column and row");
        }

        //for (int i = 0; i < entries.GetLength(0); i++)
        //{
        //    for (int j = 0; j < entries.GetLength(1); j++)
        //    {
        //        if (i == j)
        //        {
        //            entries[i, j] = 1;
        //        }
        //        else
        //        {
        //            entries[i, j] = 0;
        //        }
        //    }
        //}
        //normal version

        for (int i = 0; i < entries.GetLength(0); i++)
            for (int j = 0; j < entries.GetLength(1); j++)
                entries[i , j] = i == j ? 1 : 0;
        //ternary operator
    }

    //public void setTranslationMat(float transX, float transY)
    //{
    //    // your code here
    //}

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //convert to rad

        // your code here
    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

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
