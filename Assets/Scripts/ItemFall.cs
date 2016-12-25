using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFall :FallObj {

	// Use this for initialization
	void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

    void destroy(){
        ItemGenerator.Items.Remove(this.gameObject);
    }
}
