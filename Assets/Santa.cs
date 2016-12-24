using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour {

	public GameObject PresentBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void generatePresent(){//プレゼント生成
		Instantiate (this.PresentBox, this.transform.position,Quaternion.identity);
	}

}
