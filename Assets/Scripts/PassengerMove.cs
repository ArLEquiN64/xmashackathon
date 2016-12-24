﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerMove: MonoBehaviour
{
    public float Speed = 0.1f;//速度
    // Use this for initialization
    void Start ()
    {
		if (this.Speed > 0)
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
		if (this.Speed<0)
	    {
	        this.transform.position +=new Vector3(this.Speed,0,0);
	    }
	    else
	    {
	        this.transform.position +=new Vector3(this.Speed,0,0);
	    }
        
    }
}