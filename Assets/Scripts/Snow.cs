﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {
	/*
	 * 移動管理。当たり判定はプレイヤーで実装。
	 * 
	*/

	public Vector3 Direction=new Vector3(0,-1,0);//移動方向
	public float Speed=0.1f;//速度

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		this.Direction.Normalize ();
		this.transform.position += this.Direction * this.Speed;
	}
}