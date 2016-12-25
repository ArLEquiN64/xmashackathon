using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;
    public bool IsFrontPassenger = false;
    public int UnderUmbrellaTime = 0;
    public int HasPresents = 0;
    public int Direction = 0;

    public int InvincibleTime = 0;
    public bool IsRun = false;
    public PassengerBase Passenger;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Life > 0) {
            IsRun = false;
            if (Direction == 0) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if (state.IsName("Damage")) {
                InvincibleTime = 60;
            }
            else {
                GetComponentInChildren<Renderer>().enabled = true;
                if (InvincibleTime > 0) {
                    InvincibleTime -= 1;
                    if (InvincibleTime % 10 > 5) {
                        transform.Find("Root_M").gameObject.GetComponentInChildren<Renderer>().enabled = false;
                    }
                    else {
                        transform.Find("Root_M").gameObject.GetComponentInChildren<Renderer>().enabled = true;
                    }
                }
                transform.Find("Effect").gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
                if (UnderUmbrellaTime > 0) {
                    UnderUmbrellaTime -= 1;
                    transform.Find("Effect").gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.2f);
                }
                if (UnderUmbrellaTime == 1 && Passenger) {
                    Passenger.LeavePlayer(this);
                    Passenger = null;
                }
                if (!state.IsTag("Present")) {
                    if (Input.GetKey("right")) {
                        if (state.IsName("Idle")) {
                            UnderUmbrellaTime = 0;
                        }
                        Direction = 1;
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        if (transform.position.x < GameManager.RightLimit) {
                            transform.position += new Vector3(Speed, 0, 0);
                        }
                        IsRun = true;
                    }
                    if (Input.GetKey("left")) {
                        if (state.IsName("Idle")) {
                            UnderUmbrellaTime = 0;
                        }
                        Direction = -1;
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        if (transform.position.x > GameManager.LeftLimit) {
                            transform.position += new Vector3(-Speed, 0, 0);
                        }
                        IsRun = true;
                    }
                }
                GetComponent<Animator>().SetInteger("Direction", Direction);

                if (Input.GetKeyDown("z")) {
                    if (IsFrontPassenger && !state.IsTag("Present") && InvincibleTime == 0 && HasPresents > 0) {
                        GetComponent<Animator>().SetTrigger("Present");
                        Passenger.EnterPlayer(this);
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
    }

    private void OnTriggerEnter(Collider other) {
        if (InvincibleTime == 0 && UnderUmbrellaTime == 0) {
            if (other.tag == "Snow") {
                Debug.Log("Snow hit.");
                Destroy(other.gameObject);
                Life -= 1;
                if (Life == 0) {
                    Invoke("Death", 3.5f);
                    GetComponent<Animator>().SetTrigger("Death");
                }
                else if(Life > 0) {
                    GetComponent<Animator>().SetTrigger("Damage");
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
            IsFrontPassenger = true;
            Passenger = other.gameObject.GetComponent<PassengerBase>();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Passenger") {
            Debug.Log("Passenger leave.");
            IsFrontPassenger = false;
            // other.gameObject.GetComponent<PassengerBase>().LeavePlayer(this);
        }
    }

    public void SetUnderUmbrellaTime(int time) {
        UnderUmbrellaTime = time;
    }

    private void Death() {
        GameManager.Instance.GameFinish();
        Life = 3;
    }
}
