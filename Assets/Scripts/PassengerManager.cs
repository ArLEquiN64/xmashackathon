using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour {

    public float PassengerTimeSpan;//通行人が生成される間隔
    public GameObject Passenger;
    public float PassengerTimeSpanMin;
    public float PassengerTimeSpanMax;

    // Use this for initialization
    void Start () {

        PassengerTimeSpan = Random.Range(PassengerTimeSpanMin, PassengerTimeSpanMax);
        StartCoroutine(genPassenger());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator genPassenger()
    {
        // ループ
        while (true)
        {
            // 1秒毎にループします
            yield return new WaitForSeconds(this.PassengerTimeSpan);
            this.generatepassenger();
            this.PassengerTimeSpan = Random.Range(PassengerTimeSpanMin, PassengerTimeSpanMax);
        }
    }

    private void generatepassenger()
    {
        if(passengerdirection())
        {
            var Passenger1= Instantiate(this.Passenger, new Vector3(GameManager.LeftLimit,GameManager.Y, GameManager.Z),
            Quaternion.identity, this.transform);
        }
        else
        {
            var Passenger1= Instantiate(this.Passenger, new Vector3(GameManager.RightLimit,GameManager.Y, GameManager.Z),
            Quaternion.identity, this.transform);
        }
    }

    public bool passengerdirection()
    {
        float a = Random.Range(0f, 1f);
        if (a > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
