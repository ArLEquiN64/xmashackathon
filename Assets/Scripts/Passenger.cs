using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed = 0.1f;//速度
    // Use this for initialization
    void Start ()
    {
        Direction = this.transform.position;
        if (Direction.x < 0)
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
	    if (Direction.x<0)
	    {
	        this.transform.position +=new Vector3(this.Speed,0,0);
	    }
	    else
	    {
	        this.transform.position +=new Vector3(-1*this.Speed,0,0);
	    }
        
    }

	public void EnterPlayer(){//プレイヤーが入る。
		
	}

	public void LeavePlayer(){//でていく。
		
	}
}
