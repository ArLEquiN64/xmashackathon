using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassengerBase : MonoBehaviour {
    public PassengerMove passengerMove;
    public abstract void EnterPlayer(Player p);
    public abstract void LeavePlayer(Player p);
}
