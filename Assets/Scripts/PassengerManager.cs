using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour {
	
	public PassengerBase[] Passengers;
    public float PassengerTimeSpanMin = 2;
    public float PassengerTimeSpanMax = 5;

	public float PassengerTimeSpan{
		get{
			return Random.Range(PassengerTimeSpanMin, PassengerTimeSpanMax);
		}
	}

    // Use this for initialization
    void Start () {
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
        }
    }

    private void generatepassenger()
    {
		var passanger = this.Passengers [Random.Range (0, this.Passengers.Length)];
        if(passengerdirection())
        {
			var passenger1= Instantiate(passanger, new Vector3(GameManager.LeftLimit,GameManager.Y, GameManager.Z),Quaternion.identity, this.transform);
            passenger1.Speed = 0.1f;

        }
        else
        {
			var passenger1= Instantiate(passanger, new Vector3(GameManager.RightLimit,GameManager.Y, GameManager.Z),Quaternion.identity, this.transform);
            passenger1.Speed = -0.1f;
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
