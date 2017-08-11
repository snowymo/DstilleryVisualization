using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour {

	public GameObject prefab;

	public Vector3 pos1;
	public Vector3 pos2;

	MyMesh mm;

	// Use this for initialization
	void Start () {
		// which does not work because too many objects
//		for (int i = 0; i < 10000; i++) {
//			GameObject.Instantiate (prefab, new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10)),Quaternion.identity);
//		}
		mm = new MyMesh();
		// 65000 vertices at most
		for (int i = 0; i < 4000; i++) {
			mm.addOneObj (pos1);
			mm.addOneObj (pos2);
		}

	}
	
	// Update is called once per frame
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.vertices = mm.vertices;
		mesh.uv = mm.uvs;
		mesh.triangles = mm.triangles;
		mesh.normals = mm.norms;
	}
}
