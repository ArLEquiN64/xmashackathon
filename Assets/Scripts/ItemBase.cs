using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : FallObj {//Itemの基底クラス
	public abstract void GetItem (Player player);//アイテム取得時のコールバック

	public virtual void destroy(){
		ItemGenerator.Items.Remove(this.gameObject);
	}

}
