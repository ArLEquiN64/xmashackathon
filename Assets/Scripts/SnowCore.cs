using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCore : MonoBehaviour {
	/*
	 * 移動管理。当たり判定はプレイヤーで実装。
	 * 
	*/

	public Vector3 Direction=new Vector3(0,-1,0);//移動方向
	public float Speed=0.05f;//速度

	private float _d;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5);
		this._d = Random.Range (0f, 10f);
	}

	// Update is called once per frame
	void Update () {

		this.Direction.Normalize ();
		this.transform.position += this.Direction * this.Speed;
		this.transform.rotation = Quaternion.AngleAxis (Mathf.Sin(Time.time*Mathf.PI/3+this._d)*100, new Vector3 (0, 0, 1));
	}
}
