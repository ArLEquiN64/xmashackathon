﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour {//Itemの基底クラス
	public abstract void getItem (Player player);//アイテム取得時のコールバック

}