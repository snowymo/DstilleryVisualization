using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTutorial1 : MonoBehaviour {

	public Vector3[] newVertices;
	public Vector2[] newUV;
	public int[] newTriangles;
	public Vector3[] newNormals;

	// Use this for initialization
	void Start() {
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

//		mesh.Clear();

		newVertices = new Vector3[8];
		newVertices [0] = new Vector3 (0, 0, 0);
		newVertices [1] = new Vector3 (0, 0, 1);
		newVertices [2] = new Vector3 (1, 0, 1);
		newVertices [3] = new Vector3 (1, 0, 0);
		newVertices [4] = new Vector3 (0, 1, 0);
		newVertices [5] = new Vector3 (0, 1, 1);
		newVertices [6] = new Vector3 (1, 1, 1);
		newVertices [7] = new Vector3 (1, 1, 0);

		newUV = new Vector2[8];
		newUV [0] = new Vector2 (0, 0);
		newUV [1] = new Vector2 (0, 1);
		newUV [2] = new Vector2 (1, 1);
		newUV [3] = new Vector2 (1, 0);
		newUV [4] = new Vector2 (0, 0);
		newUV [5] = new Vector2 (0, 1);
		newUV [6] = new Vector2 (1, 1);
		newUV [7] = new Vector2 (1, 0);

		newTriangles = new int[36];
		int iter = 0;
		newTriangles [iter*12+0] = 3;newTriangles [iter*12+1] = 2;newTriangles [iter*12+2] = 1;
		newTriangles [iter*12+3] = 3;newTriangles [iter*12+4] = 1;newTriangles [iter*12+5] = 0;
		newTriangles [iter*12+6] = 4;newTriangles [iter*12+7] = 5;newTriangles [iter*12+8] = 6;
		newTriangles [iter*12+9] = 4;newTriangles [iter*12+10] = 6;newTriangles [iter*12+11] = 7;
		++iter;
		newTriangles [iter*12+0] = 0;newTriangles [iter*12+1] = 1;newTriangles [iter*12+2] = 5;
		newTriangles [iter*12+3] = 0;newTriangles [iter*12+4] = 5;newTriangles [iter*12+5] = 4;
		newTriangles [iter*12+6] = 7;newTriangles [iter*12+7] = 6;newTriangles [iter*12+8] = 2;
		newTriangles [iter*12+9] = 7;newTriangles [iter*12+10] = 2;newTriangles [iter*12+11] = 3;
		++iter;
		newTriangles [iter*12+0] = 0;newTriangles [iter*12+1] = 4;newTriangles [iter*12+2] = 7;
		newTriangles [iter*12+3] = 0;newTriangles [iter*12+4] = 7;newTriangles [iter*12+5] = 3;
		newTriangles [iter*12+6] = 5;newTriangles [iter*12+7] = 1;newTriangles [iter*12+8] = 2;
		newTriangles [iter*12+9] = 5;newTriangles [iter*12+10] =2;newTriangles [iter*12+11] = 6;

		newNormals = new Vector3[8];
		newNormals [0] = Vector3.forward;
		newNormals [1] = Vector3.forward;
		newNormals [2] = Vector3.forward;
		newNormals [3] = Vector3.forward;
		newNormals [4] = Vector3.forward;
		newNormals [5] = Vector3.forward;
		newNormals [6] = Vector3.forward;
		newNormals [7] = Vector3.forward;

		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;
		mesh.normals = newNormals;
	}
	
	// Update is called once per frame
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
//		int i = 0;
//		while (i < vertices.Length) {
//			vertices[i] += normals[i] * Mathf.Sin(Time.time);
//			i++;
//		}
		mesh.vertices = vertices;
	}
}
