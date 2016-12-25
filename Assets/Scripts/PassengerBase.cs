using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassengerBase : MonoBehaviour {
    public abstract void EnterPlayer(Player p);
    public abstract void LeavePlayer(Player p);

	public float Speed = 0.01f;//速度
	public GameObject Body;

	private float _baseSpeed = 0;

	protected virtual void Start() {
		GetComponentInChildren<Animator>().SetBool("IsWalk", true);
	}

	// Update is called once per frame
	protected virtual void Update() {
		if (this.Speed < 0) {
			this.transform.position += new Vector3(this.Speed, 0, 0);
			this.Body.transform.rotation = Quaternion.Euler(0, -90, 0);
		}else {
			this.Body.transform.rotation = Quaternion.Euler(0, 90, 0);
			this.transform.position += new Vector3(this.Speed, 0, 0);
		}
	}

	public void StopMove() {
		GetComponentInChildren<Animator>().SetBool("IsWalk", false);
		this._baseSpeed = this.Speed;
		this.Speed = 0;
	}

	public void StartMove() {
		this.StartMove (this._baseSpeed);
	}
	public void StartMove(float speed) {
		GetComponentInChildren<Animator>().SetBool("IsWalk", true);
		this.Speed = speed;
	}

	protected virtual void Destroy(){
		PassengerManager.PassengerList.Remove (this.gameObject);
	}
}
