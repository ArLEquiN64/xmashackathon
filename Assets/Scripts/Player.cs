using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;
    public bool IsUnderUmbrella = false;
    public int HasPresents = 0;

    public int IsInvincibleTime = 0;
    public bool IsRun = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        IsRun = false;
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (state.fullPathHash != Animator.StringToHash("Base Layer.Standing_React_Large_From_Back")) {
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

            if (Input.GetKey("up")) {

            }
        }

        GetComponent<Animator>().SetBool("Run", IsRun);
    }

    private void OnTriggerEnter(Collider other) {
        if (IsInvincibleTime == 0) {
            if (other.tag == "Snow") {
                Debug.Log("Snow hit.");
                Destroy(other.gameObject);
                IsInvincibleTime = 60;
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
            if (other.tag == "Passenger") {
                Debug.Log("Passenger enter.");
                IsUnderUmbrella = true;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Passenger") {
            Debug.Log("Passenger leave.");
            IsUnderUmbrella = false;
        }
    }
}
