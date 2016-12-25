using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCore : FallObj {
	private float _d;

	// Use this for initialization
	protected virtual void Start () {
		base.Start ();
		this._d = Random.Range (0f, 10f);
	}

	// Update is called once per frame
	protected virtual void Update () {
		base.Update ();
		this.transform.rotation = Quaternion.AngleAxis (Mathf.Sin(Time.time*Mathf.PI/3+this._d)*100, new Vector3 (0, 0, 1));
	}

	void Destroy(){
		SnowGenerator.SnowCores.Remove (this.gameObject);
	}
}
