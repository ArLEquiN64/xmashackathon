using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static float LeftLimit = -10;//画面端
	public static float RightLimit = 10;
	public static float UpLimit = 7.232172f;
	public static float Z=-26.64f;//基本のZ座標

	public Canvas Title;
	public GameObject Container;//プレイヤーとか。

	private float _startTime = -1;

	public void GameStart(){
		//ゲーム開始
		this._startTime = Time.time;
		this.Title.enabled = false;
		this.Container.SetActive (true);

	}

	public void GameFinish(){
		//ゲーム終了
		this.Container.SetActive (false);
		this.Title.enabled = true;
		this._startTime = -1;
	}
	public float PlayTime{
		get{
			return Time.time-this._startTime;//ゲーム開始からの時間TODO:実装
		}
	}
	public bool isPlaying{
		get{
			return this._startTime > 0;
		}
	}

	public void HitSnow(){//雪が当たったら呼ぶ
		
	}

}

