using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    public float PresentTimeSpan=0.3f;
    public GameObject PresentBox;
    public float PresentTimeSpanMin = 0.5f;
    public float PresentTimeSpanMax = 2.0f;

	// Use this for initialization
	void Start () {
	    StartCoroutine(genPresent());
	}
	
	// Update is called once per frame
	void Update () {
		var sin = Mathf.Sin (Time.time)*10;
		this.transform.position = new Vector3(sin,this.transform.position.y,GameManager.Z);
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
