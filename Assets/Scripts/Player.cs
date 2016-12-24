using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;
    public bool IsUnderUmbrella = false;
    public int HasPresents = 0;

    public bool IsRun = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsRun = false;
        if (Input.GetKey("right")) {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (transform.position.x < GameManager.RightLimit) {
                transform.position += new Vector3(Speed, 0, 0);
            }
            IsRun = true;
        }
        if (Input.GetKey("left")) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (transform.position.x > GameManager.LeftLimit) {
                transform.position += new Vector3(-Speed, 0, 0);
            }
            IsRun = true;
        }
        GetComponent<Animator>().SetBool("Run", IsRun);

        if (Input.GetKey("up")) {

        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Snow") {
            Debug.Log("Snow hit.");
			Destroy (other.gameObject);
            Life -= 1;
            GetComponent<Animator>().SetTrigger("Damage");
            if (Life < 0) {
                GameManager.Instance.GameFinish();
                GetComponent<Animator>().SetTrigger("Death");
                Life = 3;
            }
        }
        if (other.tag == "PresentBox") {
			Destroy (other.gameObject);
            HasPresents += 1;
        }
        if (other.tag == "Item") {
            Debug.Log("Item hit.");
			var item = other.gameObject.GetComponent<ItemBase> ();
			item.GetItem (this);
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
