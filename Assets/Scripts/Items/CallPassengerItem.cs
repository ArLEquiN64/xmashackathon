using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPassengerItem : ItemBase {
	
	public float Rate = 0.5f;
	public LateInvoke Invoker;

	public override void GetItem(Player player){
		GameManager.Instance.PlayExtendSound ();
		var rate = this.Rate;
		PassengerManager.Instance.PassengerTimeSpanMin *= rate;
		PassengerManager.Instance.PassengerTimeSpanMax *= rate;
		var invoker = Instantiate (this.Invoker);
		invoker.Action = () => {
			PassengerManager.Instance.PassengerTimeSpanMin /= rate;
			PassengerManager.Instance.PassengerTimeSpanMax /= rate;
		};
		invoker.Time = 6;
	}

}
