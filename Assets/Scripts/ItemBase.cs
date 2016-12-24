using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour {//Itemの基底クラス
	public abstract void GetItem (Player player);//アイテム取得時のコールバック

}
