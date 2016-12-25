using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupItem : ItemBase {//スピードアップアイテム
	public override void GetItem(Player player){
		player.Speed += 0.05f;
		new WaitForSeconds (5);
		player.Speed -= 0.05f;
		Debug.Log ("TODO:player.Speedを増やして、一定時間後戻す！");
	}


}
