using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendItem : ItemBase {//残機が増えるアイテム
	public override void GetItem(Player player){
		player.Life += 1;
		GameManager.Instance.PlayExtendSound ();
	}

	
}
