using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)) {
			Debug.Log ("右");
//			transform.position = new Vector3(0f, transform.position.y + 0.1f, 0f);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			Debug.Log ("左");
//			transform.position = new Vector3(0f, transform.position.y - 0.1f, 0f);
		}
		
	}
}
