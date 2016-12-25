using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGenerator : MonoBehaviour {

	public static SnowGenerator Instance;

	public static List<GameObject> SnowCores=new List<GameObject>();

	public float SnowTimeSpan=0.3f;//雪が生成される間隔
	public GameObject Snow;
	public GameObject SmallSnow;

	public static void ClearSnowCores(){
		SnowGenerator.SnowCores.ForEach(core=>{
			Destroy(core);
		});
	}

	// Use this for initialization
	void Start () {
		Instance = this;
		StartCoroutine (genSnow ());
	}

	private IEnumerator genSnow() {
		// ループ
		while (true) {
			// 1秒毎にループします
			yield return new WaitForSeconds(this.SnowTimeSpan);
			if(GameManager.Instance.isPlaying){
				this.generateSnow ();
			}
			this.generateSmallSnow ();
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
	private void generateSmallSnow(){
		for (int i = 0; i < 25; i++) {
			var sx = Random.Range (GameManager.LeftLimit-10, GameManager.RightLimit+10);
			var sz = Random.Range (-20, GameManager.Z+1);
			Instantiate (SmallSnow, new Vector3 (sx, GameManager.UpLimit+10f,sz),Quaternion.identity,this.transform);
		}
		for (int i = 0; i < 10; i++) {
			var sx = Random.Range (GameManager.LeftLimit-10, GameManager.RightLimit+10);
			var sz = Random.Range (GameManager.Z-1, GameManager.Z-10);
			Instantiate (SmallSnow, new Vector3 (sx, GameManager.UpLimit+10f,sz),Quaternion.identity,this.transform);
		}
	}
	private void generateSnow(){
		var x1 = Random.Range (GameManager.LeftLimit, GameManager.RightLimit);
		var snow1 = Instantiate (this.Snow, new Vector3 (x1, GameManager.UpLimit+10f,GameManager.Z),Quaternion.identity,this.transform);
		var x2 = Random.Range (GameManager.LeftLimit, GameManager.RightLimit);
		var snow2 = Instantiate (this.Snow, new Vector3 (x2, GameManager.UpLimit+10.25f,GameManager.Z),Quaternion.identity,this.transform);
		snow1.GetComponent<FallObj> ().Speed = 0.05f + Mathf.Max (0, GameManager.Instance.PlayTime / 10 - 1) * 0.05f;
		snow2.GetComponent<FallObj> ().Speed = 0.05f + Mathf.Max (0, GameManager.Instance.PlayTime / 10 - 1) * 0.05f;
		SnowGenerator.SnowCores.Add (snow1);
		SnowGenerator.SnowCores.Add (snow2);
	}
}
