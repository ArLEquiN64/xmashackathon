using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;
    public bool IsUnderUmbrella = false;
    public int HasPresents = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right")) {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (transform.position.x < GameManager.RightLimit) {
                transform.position += new Vector3(Speed, 0, 0);
            }
        }
        if (Input.GetKey("left")) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (transform.position.x > GameManager.LeftLimit) {
                transform.position += new Vector3(-Speed, 0, 0);
            }
        }

        if (Input.GetKey("up")) {

        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.tag == "Snow") {
            Debug.Log("Snow hit.");
            Life -= 1;
            if(Life < 0) {
                GameManager.Instance.GameFinish();
                Life = 3;
            }
        }
        if (other.tag == "PresentBox") {
            Debug.Log("Present Box hit.");
            HasPresents += 1;
        }
        if (other.tag == "Item") {
            Debug.Log("Item hit.");
        }
        if (other.tag == "Umbrella") {
            Debug.Log("Umbrella enter.");
            IsUnderUmbrella = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Umbrella") {
            Debug.Log("Umbrella leave.");
            IsUnderUmbrella = false;
        }
    }
}
