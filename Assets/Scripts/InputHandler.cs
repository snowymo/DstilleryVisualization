//#define MYDEBUG

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Cluster
{
	public Vector3 pos;
//	public int[] indicesOfPoints;
	public List<int> indicesOfPoints;
	public MyMesh mm;
	public GameObject go;

//	const int POINT_SIZE_EACH_CLUSTER = 63;

	public Cluster(){
		pos = new Vector3 ();
//		indicesOfPoints = new int[POINT_SIZE_EACH_CLUSTER];
		indicesOfPoints = new List<int>();
		mm = new MyMesh ();

	}
}

public class Point{
	public Vector3 pos;
	public string label;
	public int cluster_group;
	public Point(){
		pos = new Vector3 ();
		label = "";
		cluster_group = -1;
	}
}



// load necessary files and parse it here
public class InputHandler
{
	#if MYDEBUG
	const int POINT_SIZE = 5000;//10;
	public const  int CLUSTER_SIZE = 80;//3;
	const string file_3dembedding = "Data/3d_embedding-mid.txt";
	const string file_clusterlabel = "Data/clusters_C800-mid.txt";
	const string file_clusterpos = "Data/cluster_centers_C800-mid.txt";
	#else
	const int POINT_SIZE = 50000;
	public const  int CLUSTER_SIZE = 800;
	const string file_3dembedding = "Data/3d_embedding.txt";
	const string file_clusterlabel = "Data/clusters_C800.txt";
	const string file_clusterpos = "Data/cluster_centers_C800.txt";
	#endif


	public Point[] points;
	public Cluster[] clusters;

	int pointIdx4Start;
	int clusterIdx4Start;

	delegate void call4load (string[] entry);

	call4load loadHandler;

	private void addPointItem (string[] stPoint)
	{
		if (stPoint.Length == 3) {
			float x = float.Parse (stPoint [0], System.Globalization.NumberStyles.Float);
			float y = float.Parse (stPoint [1], System.Globalization.NumberStyles.Float);
			float z = float.Parse (stPoint [2], System.Globalization.NumberStyles.Float);
			if(points [pointIdx4Start] == null)
				points [pointIdx4Start] = new Point ();
			points [pointIdx4Start++].pos = new Vector3 (x, y, z);
		}
	}

	private void addClusterPos (string[] stCluster)
	{
		if (stCluster.Length == 4) {
			float x = float.Parse (stCluster [0], System.Globalization.NumberStyles.Float);
			float y = float.Parse (stCluster [1], System.Globalization.NumberStyles.Float);
			float z = float.Parse (stCluster [2], System.Globalization.NumberStyles.Float);
			if(clusters [clusterIdx4Start] == null)
				clusters [clusterIdx4Start] = new Cluster ();
			clusters [clusterIdx4Start++].pos = new Vector3 (x, y, z);
		}
	}

	private void addClusterLabel (string[] stLabel)
	{
		if (stLabel.Length == 2) {
			string l = stLabel [0];
			float idx = float.Parse (stLabel [1], System.Globalization.NumberStyles.Float);
			if(points [pointIdx4Start] == null)
				points [pointIdx4Start] = new Point ();
//			clusters [clusterIdx4Start++].label = l;
			points[pointIdx4Start].label = l;
			points [pointIdx4Start].cluster_group = (int)idx % CLUSTER_SIZE;
			clusters[(int)(idx) % CLUSTER_SIZE].indicesOfPoints.Add(pointIdx4Start++);
		}
	}

	private bool loadFromFile (string fileName, char[] splitter)
	{
		// Handle any problems that might arise when reading the text
		try {
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file was saved as
			StreamReader theReader = new StreamReader (fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the beginning of a class!)
			using (theReader) {
				// While there's lines left in the text file, do this:
				do {
					line = theReader.ReadLine ();

					if (line != null) {
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split (splitter);
						if (entries.Length > 0)
//							addPointItem(entries);
							loadHandler (entries);
					}
				} while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close ();
				return true;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (System.Exception e) {
			Debug.Log (e.Message);
//			print (e.Message);
			return false;
		}
	}


	// Use this for initialization
	public void Initialize ()
	{
		pointIdx4Start = 0;
		loadHandler = addPointItem;
		loadFromFile (file_3dembedding, new char[]{ ' ' });
		Debug.Log ("finish points loading");

		clusterIdx4Start = 0;
		loadHandler = addClusterPos;
		loadFromFile (file_clusterpos, new char[]{ ',' });
		Debug.Log ("finish cluster loading");

		// I guess the second column is the index of the cluster for each point
//		clusterIdx4Start = 0;
		pointIdx4Start = 0;
		loadHandler = addClusterLabel;
		loadFromFile (file_clusterlabel, new char[]{ ',' });
		Debug.Log ("finish cluster label loading");
	}

	public InputHandler(){
		points = new Point[POINT_SIZE];
		clusters = new Cluster[CLUSTER_SIZE];
	}
}
