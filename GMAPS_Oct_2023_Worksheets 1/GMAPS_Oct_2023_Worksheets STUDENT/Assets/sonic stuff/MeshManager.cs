using UnityEngine;

public class MeshManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    [HideInInspector]
    public Mesh originalMesh, clonedMesh;

    public Vector3[] vertices { get; private set; }
    public int[] triangles { get; private set; }

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.sharedMesh;
        clonedMesh = new Mesh();
        clonedMesh.name = "clone";
        clonedMesh.vertices = (Vector3[])originalMesh.vertices.Clone();
        clonedMesh.triangles = (int[])originalMesh.triangles.Clone();
        clonedMesh.normals = (Vector3[])originalMesh.normals.Clone();
        clonedMesh.uv = (Vector2[])originalMesh.uv.Clone();

        meshFilter.mesh = clonedMesh;
        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
    }
}
