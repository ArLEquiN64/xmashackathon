using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static float LeftLimit = -4.65f;//画面端
	public static float RightLimit = 6.7f;
	public static float UpLimit = 7.232172f;
	public static float Z=-26.64f;//基本のZ座標
    public static float Y = 3.1f;


    public static GameManager Instance;

	public Canvas Title;
	public GameObject Container;//プレイヤーとか。
	public Text ScoreText;
	public Text PlayingScoreText;
	public Player Player;
	public AudioSource AudioSource;
	public AudioClip BGM;
	public AudioClip Opening;
	public AudioClip GameOver;
	public AudioClip Extend;
	public AudioClip HitSnowAudio;

	public Text HPText;
	public Text PresentText;

	private float _startTime = -1;
	private float _hiScore = 0;

	void Start(){
		GameManager.Instance = this;
	}
	void Update(){
		this.PlayingScoreText.text = string.Format("score: {0}",this.PlayTime);
		this.HPText.text = string.Format("Life: {0}",this.Player.Life);
		this.PresentText.text = string.Format("Presents: {0}",this.Player.HasPresents);
	}

	public void GameStart(){
		//ゲーム開始
		this._startTime = Time.time;
		this.Title.enabled = false;
		this.Container.SetActive (true);
		this.AudioSource.clip = this.BGM;
		this.AudioSource.Play ();

	}

	public void GameFinish(){
		this.GameFinish ("");
	}
	public void GameFinish(string message){
		//ゲーム終了
		SnowGenerator.ClearSnowCores ();
        ItemGenerator.ClearItems();
        Santa.ClearPresents();
		this.Player.ResetState ();
		var score = this.PlayTime;
		this._hiScore = Mathf.Max (this._hiScore, score);
		this.Container.SetActive (false);
		this.Title.enabled = true;

		this.ScoreText.text = string.Format("HiScore:{0}\nScore:{1}",this._hiScore,score);
		this._startTime = -1;
		this.AudioSource.PlayOneShot (GameOver);
	}
	public float PlayTime{
		get{
			return Time.time-this._startTime;
		}
	}
	public bool isPlaying{
		get{
			return this._startTime > 0;
		}
	}

	public void HitSnow(){//雪が当たったら呼ぶ
		this.AudioSource.PlayOneShot (HitSnowAudio);
	}
	public void PlayExtendSound(){
		this.AudioSource.PlayOneShot (Extend);
	}

}

