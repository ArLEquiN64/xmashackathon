using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBox :FallObj {
    // Use this for initialization
    void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
    }
    void Destroy()
    {
        Santa.Presents.Remove(this.gameObject);
    }
}
