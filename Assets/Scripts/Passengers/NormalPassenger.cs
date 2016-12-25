using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPassenger : PassengerBase {

    public float TimeLimit = 5f;

    private bool _isPlayerEnter = false;
    private float _totalTime = 0;

    // Use this for initialization
    void Start() {
        passengerMove = transform.parent.gameObject.GetComponent<PassengerMove>();
    }

    // Update is called once per frame
    void Update() {
        if (this._isPlayerEnter) {
            this._totalTime = Time.deltaTime;
        }
        if (this._totalTime > this.TimeLimit) {
            GameManager.Instance.GameFinish();
        }
    }

    public override void EnterPlayer(Player p) {
        this._isPlayerEnter = true;
        passengerMove.StopMove();
        p.SetUnderUmbrellaTime(180);
    }

    public override void LeavePlayer(Player p) {
        this._isPlayerEnter = false;
        passengerMove.StartMove(0.01f);
    }
}