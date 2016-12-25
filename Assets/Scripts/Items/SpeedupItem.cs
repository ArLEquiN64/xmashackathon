using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class SpeedupItem : ItemBase {//スピードアップアイテム
	public LateInvoke Invoker;
	public float lastingTime = 5; 

	public override void GetItem(Player player){
		Debug.Log ("TODて、klmml;,;l");

		player.Speed += lastingTime;

		var a = Instantiate (Invoker);
		a.Time = 5f;
		a.Action = () => {
			player.Speed -= 0.05f;
		};

	}
}
