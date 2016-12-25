using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public int Life = 3;
    public float Speed = 0.05f;

//    public bool IsFrontPassenger = false;
    public int HasPresents = 0;
    public int Direction = 0;
	public bool UnderUmbrella = false;
	public float InvincibleTime = 3;//無敵時間

    public bool IsRun = false;

	private List<GameObject> _crossingPasssenger = new List<GameObject>();
	private float _currentInvincibleTimeRemaining = 0;
	private bool _isDead=false;

	public bool IsFrontPassenger{
		get{
			return this._crossingPasssenger.Count != 0;
		}
	}

    // Update is called once per frame
    void Update() {
		if (this.Life <= 0) {
			return;
		}

		GetComponentInChildren<Renderer>().enabled = true;


		//傘ならグレーのエフェクト
		if (this.UnderUmbrella) {
			transform.Find("Effect").gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.2f);
		}else{
			transform.Find("Effect").gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
		}

		if (!this.UnderUmbrella && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Damage")) {//傘じゃない
			Direction = 0;
			if (Input.GetKey("right")) {
				Direction = 1;
			}
			if (Input.GetKey("left")) {
				Direction = -1;
			}

			if (Input.GetKey("z") && IsFrontPassenger && HasPresents > 0) {
				ChangeUnbrella (true);
			}
		}else{//傘
			if (!Input.GetKey("z")) {//z放したらleave
				ChangeUnbrella(false);
			}
		}
        
		var animetor = GetComponent<Animator> ();
		AnimatorStateInfo state = animetor.GetCurrentAnimatorStateInfo(0);//TODO:ダメージ中は操作禁止


		animetor.SetInteger("Direction", Direction);
		animetor.SetBool("Run", IsRun);
		checkDirection (this.Direction);
        if (state.IsName("TurnRight")) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (state.IsName("Present")) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (state.IsName("TurnBack")) {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        this._invincibleControll ();//無敵なら点滅
    }

	public void ResetState(){
		HasPresents = 0;
		Direction = 0;
		UnderUmbrella = false;
		IsRun = false;
		if(this.UnderUmbrella){
			this._crossingPasssenger [0].GetComponent<PassengerBase> ().LeavePlayer (this);
		}
		this._crossingPasssenger.Clear ();
		_isDead = false;
	}

	public void ChangeUnbrella(bool underUmbrella){
		if(this.UnderUmbrella == underUmbrella){
			return;
		}
		this.UnderUmbrella = underUmbrella;

		if(underUmbrella){//入る
            if (IsFrontPassenger && HasPresents > 0) {
                this._crossingPasssenger[0].GetComponent<PassengerBase>().EnterPlayer(this);
                GetComponent<Animator>().SetTrigger("Present");
                this.UnderUmbrella = true;
                Debug.Log("ENTER");
            }
		}else{//出る
			GetComponent<Animator> ().SetTrigger ("Leave");
			this._crossingPasssenger[0].GetComponent<PassengerBase>().LeavePlayer (this);
			this.UnderUmbrella = false;
		}
		
	}

    private void OnTriggerEnter(Collider other) {
		if (!this.UnderUmbrella&&!_isDead&&this._currentInvincibleTimeRemaining<=0) {
            if (other.tag == "Snow") {
                Debug.Log("Snow hit.");

				Debug.Log (this._currentInvincibleTimeRemaining);
                Destroy(other.gameObject);
                Life -= 1;
                if (Life <= 0) {
					this._isDead = true;
                    Invoke("Death", 3.5f);
                    GetComponent<Animator>().SetTrigger("Death");
                }else {
					GetComponent<Animator>().SetTrigger("Damage");
					this._currentInvincibleTimeRemaining = this.InvincibleTime;
                }
            }
            if (other.tag == "PresentBox") {
                Destroy(other.gameObject);
                HasPresents += 1;
            }
            if (other.tag == "Item") {
                Destroy(other.gameObject);
                Debug.Log("Item hit.");
                var item = other.gameObject.GetComponent<ItemBase>();
                item.GetItem(this);
            }
        }

        if (other.tag == "Passenger") {
			this._crossingPasssenger.Add (other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Passenger") {
			this._crossingPasssenger.Remove (other.gameObject);
        }
    }

	private void OnDamege(){
		
	}

    private void Death() {
        GameManager.Instance.GameFinish();
        Life = 3;
    }

	private void _invincibleControll(){//無敵なら点滅。そうでなければ点灯
		if (this._currentInvincibleTimeRemaining > 0 && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Damage")) {
			this._currentInvincibleTimeRemaining -= Time.deltaTime;

			var en = Mathf.FloorToInt(this._currentInvincibleTimeRemaining * 5) % 2 == 0;
			transform.Find ("Root_M").gameObject.GetComponentInChildren<Renderer> ().enabled = en;
		}else{
			GetComponentInChildren<Renderer>().enabled = true;
		}
	}

	private void checkDirection(int direction){//directionに応じて移動、向き変更
		if (direction == -1) {
			transform.rotation = Quaternion.Euler(0, -90, 0);
			if (transform.position.x > GameManager.LeftLimit) {
				transform.position += new Vector3(-Speed, 0, 0);
			}
			IsRun = true;

		}else if(direction==1){
			transform.rotation = Quaternion.Euler(0, 90, 0);
			if (transform.position.x < GameManager.RightLimit) {
				transform.position += new Vector3(Speed, 0, 0);
			}
			IsRun = true;
		}else{
			transform.rotation = Quaternion.Euler(0, 180, 0);
			IsRun = false;
		}
	}


}
