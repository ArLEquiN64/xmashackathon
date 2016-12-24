using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {

	public float SnowTimeSpan=0.3f;//雪が生成される間隔
	public GameObject Snow;
	public GameObject SmallSnow;

	// Use this for initialization
	void Start () {
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

//			// snowing秒降ってnotSnowing秒やむ
//			int snowing = 30, notSnowing = 5;
//			for (int i = 0; i < snowing; i++) {
//				yield return new WaitForSeconds(this.SnowTimeSpan);
//				this.generateSnow ();
//			}
//			for (int i = 0; i < notSnowing; i++) {
//				yield return new WaitForSeconds(this.SnowTimeSpan);
//			}
		}
	}
	private void generateSnow(){
		var x1 = Random.Range (GameManager.LeftLimit, GameManager.RightLimit);
		var snow1 = Instantiate (this.Snow, new Vector3 (x1, GameManager.UpLimit+10f,GameManager.Z),Quaternion.identity,this.transform);
		var x2 = Random.Range (GameManager.LeftLimit, GameManager.RightLimit);
		var snow2 = Instantiate (this.Snow, new Vector3 (x2, GameManager.UpLimit+10.25f,GameManager.Z),Quaternion.identity,this.transform);
		for (int i = 0; i < 25; i++) {
			var sx = Random.Range (GameManager.LeftLimit-10, GameManager.RightLimit+10);
			var sz = Random.Range (-20, GameManager.Z-5);
			var ssnow =  Instantiate (SmallSnow, new Vector3 (sx, GameManager.UpLimit+10f,sz),Quaternion.identity,this.transform);
		}
	}
}
