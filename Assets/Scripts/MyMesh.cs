using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyMesh {

	public Vector3[] vertices;
	public Vector2[] uvs;
	public int[] triangles;
	public Vector3[] norms;

	public void addOneObj(Vector3 originalPos){
		initialize (originalPos, vertices.Length / 8);
	}

	public void updateOneObj(Vector3 pos, int index){
		initialize (pos, index);
	}

	void initialize(Vector3 startPoint, int index){
//		vertices = new Vector3[8];
		Array.Resize(ref vertices, vertices.Length + 8);
		vertices [index * 8 + 0] = startPoint + new Vector3 (- 0.5f,  - 0.5f,  - 0.5f);
		vertices [index * 8 + 1] = startPoint + new Vector3 ( - 0.5f,  - 0.5f,  + 0.5f);
		vertices [index * 8 + 2] = startPoint + new Vector3 ( + 0.5f,  - 0.5f,  + 0.5f);
		vertices [index * 8 + 3] = startPoint + new Vector3 ( + 0.5f,  - 0.5f,  - 0.5f);
		vertices [index * 8 + 4] = startPoint + new Vector3 ( - 0.5f,  + 0.5f,  - 0.5f);
		vertices [index * 8 + 5] = startPoint + new Vector3 ( - 0.5f,  + 0.5f,  + 0.5f);
		vertices [index * 8 + 6] = startPoint + new Vector3 ( + 0.5f,  + 0.5f,  + 0.5f);
		vertices [index * 8 + 7] = startPoint + new Vector3 ( + 0.5f,  + 0.5f,  - 0.5f);

//		uvs = new Vector2[8];
		Array.Resize(ref uvs, uvs.Length + 8);
		uvs [index * 8 + 0] = new Vector2 (0, 0);
		uvs [index * 8 + 1] = new Vector2 (0, 1);
		uvs [index * 8 + 2] = new Vector2 (1, 1);
		uvs [index * 8 + 3] = new Vector2 (1, 0);
		uvs [index * 8 + 4] = new Vector2 (0, 0);
		uvs [index * 8 + 5] = new Vector2 (0, 1);
		uvs [index * 8 + 6] = new Vector2 (1, 1);
		uvs [index * 8 + 7] = new Vector2 (1, 0);

//		triangles = new int[36];
		Array.Resize(ref triangles, triangles.Length + 36);
		int iter = 0;
		triangles [index * 36 + iter*12+0] = index * 8 + 3;triangles [index * 36 + iter*12+1] = index * 8 + 2;triangles [index * 36 + iter*12+2] = index * 8 + 1;
		triangles [index * 36 + iter*12+3] = index * 8 + 3;triangles [index * 36 + iter*12+4] = index * 8 + 1;triangles [index * 36 + iter*12+5] = index * 8 + 0;
		triangles [index * 36 + iter*12+6] = index * 8 + 4;triangles [index * 36 + iter*12+7] = index * 8 + 5;triangles [index * 36 + iter*12+8] = index * 8 + 6;
		triangles [index * 36 + iter*12+9] = index * 8 + 4;triangles [index * 36 + iter*12+10] = index * 8 + 6;triangles [index * 36 + iter*12+11] = index * 8 + 7;
		++iter;
		triangles [index * 36 + iter*12+0] = index * 8 + 0;triangles [index * 36 + iter*12+1] = index * 8 + 1;triangles [index * 36 + iter*12+2] = index * 8 + 5;
		triangles [index * 36 + iter*12+3] = index * 8 + 0;triangles [index * 36 + iter*12+4] = index * 8 + 5;triangles [index * 36 + iter*12+5] = index * 8 + 4;
		triangles [index * 36 + iter*12+6] = index * 8 + 7;triangles [index * 36 + iter*12+7] = index * 8 + 6;triangles [index * 36 + iter*12+8] = index * 8 + 2;
		triangles [index * 36 + iter*12+9] = index * 8 + 7;triangles [index * 36 + iter*12+10] = index * 8 + 2;triangles [index * 36 + iter*12+11] = index * 8 + 3;
		++iter;
		triangles [index * 36 + iter*12+0] = index * 8 + 0;triangles [index * 36 + iter*12+1] = index * 8 + 4;triangles [index * 36 + iter*12+2] = index * 8 + 7;
		triangles [index * 36 + iter*12+3] = index * 8 + 0;triangles [index * 36 + iter*12+4] = index * 8 + 7;triangles [index * 36 + iter*12+5] = index * 8 + 3;
		triangles [index * 36 + iter*12+6] = index * 8 + 5;triangles [index * 36 + iter*12+7] = index * 8 + 1;triangles [index * 36 + iter*12+8] = index * 8 + 2;
		triangles [index * 36 + iter*12+9] = index * 8 + 5;triangles [index * 36 + iter*12+10] =index * 8 + 2;triangles [index * 36 + iter*12+11] = index * 8 + 6;

//		norms = new Vector3[8];
		Array.Resize(ref norms, norms.Length + 8);
		norms [index * 8 + 0] = new Vector3 (- 0.5f,  - 0.5f,  - 0.5f);
		norms [index * 8 + 1] = new Vector3 ( - 0.5f,  - 0.5f,  + 0.5f);
		norms [index * 8 + 2] = new Vector3 ( + 0.5f,  - 0.5f,  + 0.5f);
		norms [index * 8 + 3] = new Vector3 ( + 0.5f,  - 0.5f,  - 0.5f);
		norms [index * 8 + 4] = new Vector3 ( - 0.5f,  + 0.5f,  - 0.5f);
		norms [index * 8 + 5] = new Vector3 ( - 0.5f,  + 0.5f,  + 0.5f);
		norms [index * 8 + 6] = new Vector3 ( + 0.5f,  + 0.5f,  + 0.5f);
		norms [index * 8 + 7] = new Vector3 ( + 0.5f,  + 0.5f,  - 0.5f);
		for (int i = 0; i < 8; i++) {
			norms [index * 8 + i].Normalize ();
		}
	}

	public MyMesh(){
		vertices = new Vector3[0];
		uvs = new Vector2[0];
		triangles = new int[0];
		norms = new Vector3[0];
	}
//
//	public MyMesh(Vector3 startPoint){
//		initialize (startPoint);
//	}
}
