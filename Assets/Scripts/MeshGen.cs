using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{

	//	public GameObject prefab;

	//	public Vector3 pos1;
	//	public Vector3 pos2;
	//
	public GameObject clusterUnit;

	//	MyMesh mm;
	InputHandler ih;

	float duration = 5.0F;
	float startTime;

	bool isAnimationStart;

	const float MIN_DIS = 0.1f;

	// Use this for initialization
	void Start ()
	{
		// which does not work because too many objects
//		for (int i = 0; i < 10000; i++) {
//			GameObject.Instantiate (prefab, new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10)),Quaternion.identity);
//		}
//		mm = new MyMesh();
//		// 65000 vertices at most
//		for (int i = 0; i < 4000; i++) {
//			mm.addOneObj (pos1);
//			mm.addOneObj (pos2);
//		}

		ih = new InputHandler ();
		ih.Initialize ();
		generateMeshForEachCluster ();
		isAnimationStart = false;

	}

	void generateMeshForEachCluster ()
	{
		for (int i = 0; i < ih.clusters.Length; i++) {
			ih.clusters [i].go = GameObject.Instantiate (clusterUnit);
			for (int j = 0; j < ih.clusters [i].indicesOfPoints.Count; j++) {
				print ("clusters[i].indicesOfPoints:" + j + "point:" + ih.points [ih.clusters [i].indicesOfPoints [j]]);
				ih.clusters [i].mm.addOneObj (ih.points [ih.clusters [i].indicesOfPoints [j]].pos);
			}
			Mesh mesh = ih.clusters [i].go.GetComponent<MeshFilter> ().mesh;
			mesh.vertices = ih.clusters [i].mm.vertices;
			mesh.uv = ih.clusters [i].mm.uvs;
			mesh.triangles = ih.clusters [i].mm.triangles;
			mesh.normals = ih.clusters [i].mm.norms;
		}
	}

	int slickIndex = 0;
	float t4animation = 0;
	void animatePointCloud ()
	{
		if (isAnimationStart) {
			// let us do one cluster every frame
//			if (slickIndex == 0)
//				t4animation = (Time.time - startTime) / duration;
			t4animation += 0.05f;
			print ("animated:" + startTime + " t:" + t4animation);
			animateEachSlice (slickIndex * 100, (slickIndex + 1) * 100, t4animation);
			++slickIndex;
			if (slickIndex >= 8)
				slickIndex -= 8;
		}
	}

	void animateEachSlice (int startIdx, int endIdx, float t)
	{
		for (int i = startIdx; i < Mathf.Min( endIdx,ih.clusters.Length); i++) {
			for (int j = 0; j < ih.clusters [i].indicesOfPoints.Count; j++) {
				Vector3 updatedPos = Vector3.Lerp (ih.points [ih.clusters [i].indicesOfPoints [j]].pos,
					                     ih.clusters [i].pos,
					                     Mathf.SmoothStep (0.0f, 1.0f, t));
				ih.clusters [i].mm.updateOneObj (updatedPos, j);
				if (t > 1.5f)
					isAnimationStart = false;
			}
			Mesh mesh = ih.clusters [i].go.GetComponent<MeshFilter> ().mesh;
			mesh.vertices = ih.clusters [i].mm.vertices;
			//			mesh.uv = ih.clusters [i].mm.uvs;
			//			mesh.triangles = ih.clusters [i].mm.triangles;
			//			mesh.normals = ih.clusters [i].mm.norms;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.M)) {
			startTime = Time.time;
			isAnimationStart = true;
		}
		animatePointCloud ();
//		 = GetComponent<MeshFilter>().mesh;
//		mesh.vertices = mm.vertices;
//		mesh.uv = mm.uvs;
//		mesh.triangles = mm.triangles;
//		mesh.normals = mm.norms;
	}
}
