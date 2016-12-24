using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right")) {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (transform.position.x < GameManager.RightLimit) {
                transform.position += new Vector3(speed, 0, 0);
            }
        }
        if (Input.GetKey("left")) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (transform.position.x > GameManager.LeftLimit) {
                transform.position += new Vector3(-speed, 0, 0);
            }
        }
    }

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("jahgsfkasf");
		if(collision.gameObject.GetComponent<Snow>()!=null){
			Debug.Log ("hit!!!!");
		}
	}
}
