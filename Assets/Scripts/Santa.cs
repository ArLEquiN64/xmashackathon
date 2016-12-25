using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Santa : MonoBehaviour
{
    public static List<GameObject> Presents = new List<GameObject>();
    private float PresentTimeSpan;
    public GameObject PresentBox;
    public float PresentTimeSpanMin = 0.5f;
    public float PresentTimeSpanMax = 2.0f;

	private float _center;
	private float _amplitude;
	private IEnumerator _routine;

	void OnEnable()
	{
		if (this._routine != null)
		{
			StartCoroutine(this._routine);
		}
	}
    public static void ClearPresents()
    {
        Santa.Presents.ForEach(present => {
            Destroy(present);
        });
    }

    // Use this for initialization
    void Start () {
		this._center = (GameManager.LeftLimit + GameManager.RightLimit) / 2;
		this._amplitude = (GameManager.RightLimit - GameManager.LeftLimit) / 2;
		StartCoroutine(this._routine = this.genPresent());
	}
	
	// Update is called once per frame
	void Update () {
		var sin = Mathf.Sin (Time.time)*this._amplitude;
        if (sin + this._center - this.transform.position.x > 0) {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        this.transform.position = new Vector3(sin+this._center, GameManager.UpLimit + Mathf.Sin(GameManager.Instance.PlayTime * 1.2f) * 0.6f, GameManager.Z);
       
	}

    private IEnumerator genPresent()
    {
        // ループ
        while (true)
        {
            // 1秒毎にループします
            this.PresentTimeSpan = Random.Range(PresentTimeSpanMin, PresentTimeSpanMax);
            yield return new WaitForSeconds(this.PresentTimeSpan);
            this.generatePresent();    
        }
    }


    public void generatePresent(){//プレゼント生成
		var present=Instantiate (this.PresentBox, this.transform.position,Quaternion.identity);
        Santa.Presents.Add(present.gameObject);
	}

}
