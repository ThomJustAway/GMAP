//// Uncomment this whole file.

//using Mono.Cecil.Cil;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TransformMesh : MonoBehaviour
//{
//    [HideInInspector]
//    public Vector3[] vertices { get; private set; }

//    private HMatrix2D transformMatrix = new HMatrix2D();
//    HMatrix2D toOriginMatrix = new HMatrix2D();
//    HMatrix2D fromOriginMatrix = new HMatrix2D();
//    HMatrix2D rotateMatrix = new HMatrix2D();

//    private MeshManager meshManager;
//    HVector2D pos = new HVector2D();

//    void Start()
//    {
//        meshManager = GetComponent<MeshManager>();
//        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

//        // Your code here
//    }


//    void Translate(float x, float y)
//    {
//        // Your code here
//    }

//    void Rotate(float angle)
//    {
//        transformMatrix.SetIdentity();

//        // Your code here

//        transformMatrix = fromOriginMatrix * // Your code here;

//        Transform();
//    }

//    private void Transform()
//    {
        //vertices = meshManager.clonedMesh.vertices;

        //for (int i = 0; i < vertices.Length; i++)
        //{
        //    // Your code here
        //}

        //meshManager.clonedMesh.vertices = vertices;
//    }
//}
