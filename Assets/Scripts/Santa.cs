using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    public float PresentTimeSpan;
    public GameObject PresentBox;
    public float PresentTimeSpanMin = 0.5f;
    public float PresentTimeSpanMax = 2.0f;

	private float _center;
	private float _amplitude;

	// Use this for initialization
	void Start () {
		this._center = (GameManager.LeftLimit + GameManager.RightLimit) / 2;
		this._amplitude = (GameManager.RightLimit - GameManager.LeftLimit) / 2;
        PresentTimeSpan= Random.Range(PresentTimeSpanMin, PresentTimeSpanMax);
        StartCoroutine(genPresent());
	}
	
	// Update is called once per frame
	void Update () {
		var sin = Mathf.Sin (Time.time)*this._amplitude;
		this.transform.position = new Vector3(sin+this._center,this.transform.position.y,GameManager.Z);
	}

    private IEnumerator genPresent()
    {
        // ループ
        while (true)
        {
            // 1秒毎にループします
            yield return new WaitForSeconds(this.PresentTimeSpan);
            this.generatePresent();
            this.PresentTimeSpan = Random.Range(PresentTimeSpanMin, PresentTimeSpanMax);
        }
    }


    public void generatePresent(){//プレゼント生成
		Instantiate (this.PresentBox, this.transform.position,Quaternion.identity);
	}

}
