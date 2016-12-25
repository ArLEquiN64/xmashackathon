using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavysnowItem : ItemBase {//雪の量を増やすアイテム
	public LateInvoke Invoker;
	public float lastingTime = 5;
	public float timesSpan = 0.2f;

	public override void GetItem(Player player){
		
		Debug.Log ("TODO:yuki!増やして、");

		SnowGenerator.Instance.SnowTimeSpan *= timesSpan;
		var a = Instantiate (Invoker);
		a.Time = lastingTime;
		a.Action = () => {
			SnowGenerator.Instance.SnowTimeSpan /= timesSpan;
			Debug.Log ("TODO:終haodaiou");
		};
	}

}
