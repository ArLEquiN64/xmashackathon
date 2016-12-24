using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed = 0.1f;//速度
    // Use this for initialization
    void Start () {
        if (Direction.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0,90,0);
        }
        else
        {
            this.transform.rotation=Quaternion.Euler(0,-90,0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        this.Direction.Normalize();
        this.transform.position += this.Direction * this.Speed;
    }

	public void EnterPlayer(){//プレイヤーが入る。
		
	}

	public void LeavePlayer(){//でていく。
		
	}
}
