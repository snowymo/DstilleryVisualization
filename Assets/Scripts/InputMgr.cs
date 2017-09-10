using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// check the collider
public class InputMgr : MonoBehaviour {

	public GameObject cursor;
	Vector3 oriCursorPos;
	GameObject lastSelection;
	Vector3 oriObjScale;
	public Material oriObjMat;
	public Material selectedMat;
	public GameObject tooltipPrefab;
	public MeshGen mg;
	InputHandler ih;

	// Use this for initialization
	void Start () {
		oriCursorPos = cursor.transform.localPosition;
		oriObjScale = new Vector3 (0.1f, 0.1f, 0.1f);
		ih = mg.ih;
	}
	
	// Update is called once per frame
	void Update () {
		
		cursor.transform.localPosition = oriCursorPos;

		if (lastSelection != null) {
			lastSelection.transform.localScale = oriObjScale;
			lastSelection.GetComponent<Renderer> ().material = oriObjMat;
			lastSelection.transform.Find("tooltip").gameObject.SetActive(false);
		}

		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, out hit)) {
			print ("Found an object - distance: " + hit.distance + " name:" + hit.collider.name);
			hit.collider.gameObject.transform.localScale = oriObjScale * 1.1f;
			hit.collider.gameObject.GetComponent<Renderer> ().material = selectedMat;
			Transform tooltiptf = hit.collider.gameObject.transform.Find ("tooltip");
			if (tooltiptf == null) {
				GameObject tooltip = GameObject.Instantiate (tooltipPrefab, hit.collider.gameObject.transform);
				tooltip.transform.localPosition = new Vector3 (0.5f, 0.5f, 0);
				tooltip.name = "tooltip";
				tooltiptf = tooltip.transform;
			}
			tooltiptf.gameObject.SetActive (true);
			// clusterXXX
			int clusterIdx = int.Parse(hit.collider.gameObject.name.Substring(7));
			tooltiptf.GetComponent<TextMesh> ().text = ih.clusters [clusterIdx].keywords [0].kw;


			cursor.transform.localPosition = new Vector3 (0,0, hit.distance);

			lastSelection = hit.collider.gameObject;
		}
	}
}
