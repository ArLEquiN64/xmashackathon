using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static List<GameObject> Items = new List<GameObject>();
    private float ItemTimeSpan; //アイテムが生成される間隔
    public float ItemTimeSpanMin = 1f;
    public float ItemTimeSpanMax = 2f;
	public ItemBase[] ItemList;

    public static void ClearItems()
    {
        ItemGenerator.Items.ForEach(item => {
            Destroy(item);
        });
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(genItem());
    }

    private IEnumerator genItem()
    {
        // ループ
        while (true)
        {
            this.ItemTimeSpan = Random.Range(ItemTimeSpanMin, ItemTimeSpanMax);
            yield return new WaitForSeconds(this.ItemTimeSpan);
			var index = Random.Range (0, this.ItemList.Length);
            if (GameManager.Instance.isPlaying)
            {
				var sx = Random.Range(GameManager.LeftLimit, GameManager.RightLimit);
				var item = Instantiate(this.ItemList[index], new Vector3(sx, GameManager.UpLimit + 10f, GameManager.Z), Quaternion.identity, this.transform);
				ItemGenerator.Items.Add(item.gameObject);
            }
        }
    }
}
