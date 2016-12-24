using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {

	public float SnowTimeSpan=0.3f;//雪が生成される間隔
	public GameObject Snow;
	private Random _r;

	// Use this for initialization
	void Start () {
		this._r = new Random ();
		StartCoroutine (genSnow ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator genSnow() {
		// ループ
		while (true) {
			// 1秒毎にループします
			yield return new WaitForSeconds(this.SnowTimeSpan);
			this.generateSnow ();
		}
	}
	private void generateSnow(){
		var x = Random.Range (GameManager.LeftLimit, GameManager.RightLimit);
		var snow = Instantiate (this.Snow, new Vector3 (x, this.transform.position.y, this.transform.position.z),Quaternion.identity);

	}
}
