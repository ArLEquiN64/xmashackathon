using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LateInvoke : MonoBehaviour {

	public Action Action;
	public float Time; 

	// Use this for initialization
	void Start () {
		Invoke ("Func", Time);
	}

	void Func(){
		this.Action ();
		Destroy (this.gameObject);
	}
}
