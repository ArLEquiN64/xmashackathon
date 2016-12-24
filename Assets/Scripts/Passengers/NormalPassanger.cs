using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPassenger : PassengerBase {

	public float TimeLimit = 5f;

	private bool _isPlayerEnter=false;
	private float _totalTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this._isPlayerEnter){
			this._totalTime = Time.deltaTime;
		}
		if(this._totalTime>this.TimeLimit){
			GameManager.Instance.GameFinish ();//TODO:finishの理由もほしい。。。
		}
	}

	public override void EnterPlayer(){
		this._isPlayerEnter = true;
	}

	public override void LeavePlayer(){
		this._isPlayerEnter = false;
	}
}
