// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    public Vector3[] vertices { get; private set; }
    private MeshManager meshManager;
    private HMatrix2D transformMatrix = new HMatrix2D();
    HVector2D pos = new HVector2D();

    public bool Question5D = false;
    public bool Question5E = false;

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); //getting the position of the pos

        if(Question5D)
        {
            Translate(1, 1);
        }
        else if(Question5E)
        {
            Rotate(30);
        }

    }


    void Translate(float x, float y)
    {
        //dont have to set identity matrix as the set translation matrix has already done it :)
        transformMatrix.SetTranslationMat(x, y);
        Transform(); //move the vertices

        pos = transformMatrix * pos; //apply current transformation to the current position of the mesh.
    }

    void Rotate(float angle)
    {
        toOriginMatrix.SetTranslationMat(-pos.x , -pos.y); //apply a translation to the origin 
        fromOriginMatrix.SetTranslationMat(pos.x,pos.y); //apply a translation back to original positon
        rotateMatrix.SetRotationMat(angle); //add a rotation matrix
        //setting all the translate and rotation matrix;

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;
        //use matrix concentation to apply a translation back to origin,
        //rotation and then back to original position in that order.
        Transform();
    }

    private void Transform()
    {
        //use the cloned mesh vertices to not affect the original mesh
        vertices = meshManager.clonedMesh.vertices; 
        for (int i = 0; i < vertices.Length; i++)
        { //go through each vertices and 
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert; //apply the transformation matrix to the verticles

            //applying the values found to the actuale values.
            vertices[i].x = vert.x; 
            vertices[i].y = vert.y;
        }

        //add the updated information of the new position of the vertices to the clone mesh to make the changes
        meshManager.clonedMesh.vertices = vertices;
    }
}
