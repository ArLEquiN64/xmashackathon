using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GameStart(){
		//ゲーム開始
	}

	public void GameFinish(){
		//ゲーム終了
	}
	public float PlayTime{
		get{
			return Time.deltaTime;//ゲーム開始からの時間TODO:実装
		}
	}

	public void HitSnow(){//雪が当たったら呼ぶ
		
	}

}

