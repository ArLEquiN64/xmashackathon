using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPassenger : PassengerBase {

    public float TimeLimit = 5f;

    private bool _isPlayerEnter = false;
    private float _totalTime = 0;

    // Use this for initialization
    void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {
        base.Update();
        if (this._isPlayerEnter) {
            this._totalTime += Time.deltaTime;
        }
        if (this._totalTime > this.TimeLimit) {
            GameManager.Instance.GameFinish();
            this._totalTime = 0;
        }
    }

    public override void EnterPlayer(Player p) {
        this._isPlayerEnter = true;
        this.StopMove();
        p.HasPresents -= 1;
    }

    public override void LeavePlayer(Player p) {
        this._isPlayerEnter = false;
        this.StartMove(0.01f);
    }
}