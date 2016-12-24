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
		var sin = Mathf.Sin (Time.time)*10;
		this.transform.position = new Vector3(sin,this.transform.position.y,0);
	}

	public void generatePresent(){//プレゼント生成
		Instantiate (this.PresentBox, this.transform.position,Quaternion.identity);
	}

}
