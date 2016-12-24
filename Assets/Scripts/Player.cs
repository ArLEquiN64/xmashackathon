using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;
    public bool IsUnderUmbrella = false;
    public int HasPresents = 0;
    public int Direction = 0;

    public int IsInvincibleTime = 0;
    public bool IsRun = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        IsRun = false;
        if(Direction == 0) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Damage")) {
            IsInvincibleTime = 60;
        }
        else {
            GetComponentInChildren<Renderer>().enabled = true;
            if (IsInvincibleTime > 0) {
                IsInvincibleTime -= 1;
                if (IsInvincibleTime % 10 > 5) {
                    GetComponentInChildren<Renderer>().enabled = false;
                }
                else {
                    GetComponentInChildren<Renderer>().enabled = true;
                }
                
            }

            if (Input.GetKey("right")) {
                Direction = 1;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                if (transform.position.x < GameManager.RightLimit) {
                    transform.position += new Vector3(Speed, 0, 0);
                }
                IsRun = true;
            }
            if (Input.GetKey("left")) {
                Direction = -1;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                if (transform.position.x > GameManager.LeftLimit) {
                    transform.position += new Vector3(-Speed, 0, 0);
                }
                IsRun = true;
            }
            GetComponent<Animator>().SetInteger("Direction", Direction);

            if (Input.GetKey("z")) {
                if (IsUnderUmbrella && !state.IsTag("Present")) {
                    GetComponent<Animator>().SetTrigger("Present");
                }
            }

            if (state.IsName("Present")) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (state.IsName("TurnBack")) {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                Direction = 0;
            }

        }

        GetComponent<Animator>().SetBool("Run", IsRun);
    }

    private void OnTriggerEnter(Collider other) {
        if (IsInvincibleTime == 0) {
            if (other.tag == "Snow") {
                Debug.Log("Snow hit.");
                Destroy(other.gameObject);
                Life -= 1;
                GetComponent<Animator>().SetTrigger("Damage");
                if (Life <= 0) {
                    GameManager.Instance.GameFinish();
                    GetComponent<Animator>().SetTrigger("Death");
                    Life = 3;
                }
            }
            if (other.tag == "PresentBox") {
                Destroy(other.gameObject);
                HasPresents += 1;
            }
            if (other.tag == "Item") {
                Debug.Log("Item hit.");
                var item = other.gameObject.GetComponent<ItemBase>();
                item.GetItem(this);
            }
        }

        if (other.tag == "Passenger") {
            Debug.Log("Passenger enter.");
            IsUnderUmbrella = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Passenger") {
            Debug.Log("Passenger leave.");
            IsUnderUmbrella = false;
        }
    }
}
