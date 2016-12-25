using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class SpeedupItem : ItemBase {//スピードアップアイテム
	public LateInvoke Invoker;
	public float lastingTime = 5; 
	public float upSpeed = 0.05f;

	public override void GetItem(Player player){
		GameManager.Instance.PlayExtendSound ();
		Debug.Log ("TODて、klmml;,;l");

		player.Speed += upSpeed;

		var a = Instantiate (Invoker);
		a.Time = lastingTime;
		a.Action = () => {
			player.Speed -= upSpeed;
		};

	}
}
