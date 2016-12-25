using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{

	public static PassengerManager Instance;

    public static List<GameObject> PassengerList = new List<GameObject>();

    public PassengerBase[] Passengers;
    public float PassengerTimeSpanMin = 2;
    public float PassengerTimeSpanMax = 5;

    public float PassengerTimeSpan
    {
        get
        {
            return Random.Range(PassengerTimeSpanMin, PassengerTimeSpanMax);
        }
    }

    // Use this for initialization
    void Start()
    {
		Instance = this;
        StartCoroutine(genPassenger());
    }

    public static void ClearPassenger()
    {
        PassengerList.ForEach(p =>
        {
            Destroy(p);
        });
        PassengerList.Clear();
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
        if (!GameManager.Instance.isPlaying)
        {
            return;
        }

        if (passengerdirection())
        {
            var passanger = this.Passengers[Random.Range(0, this.Passengers.Length)];
            var inst = Instantiate(passanger, new Vector3(GameManager.LeftLimit, GameManager.Y, GameManager.Z), Quaternion.identity, this.transform);
            PassengerList.Add(inst.gameObject);
            inst.Speed = 0.1f;
        }
        else
        {
            var passanger = this.Passengers[Random.Range(0, this.Passengers.Length)];
            var inst = Instantiate(passanger, new Vector3(GameManager.RightLimit, GameManager.Y, GameManager.Z), Quaternion.identity, this.transform);
            PassengerList.Add(inst.gameObject);
            inst.Speed = -0.1f;
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
