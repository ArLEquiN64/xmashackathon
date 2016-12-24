using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {
	/*
	 * 移動管理。当たり判定はプレイヤーで実装。
	 * 
	*/

	public Vector3 Direction;//移動方向
	public float Speed;//速度

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.Direction.Normalize ();
		this.transform.position += this.Direction * this.Speed;
	}
}
