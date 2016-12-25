using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static List<GameObject> Items = new List<GameObject>();
    private float ItemTimeSpan; //アイテムが生成される間隔
    public float ItemTimeSpanMin = 1f;
    public float ItemTimeSpanMax = 2f;
    public GameObject ItemCandy;
    public GameObject ItemHat;
    public GameObject ItemSnowflake;
    public GameObject ItemStar;
    private float ItemSelect;
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
            ItemSelect = Random.Range(0f, 4f);
            if (GameManager.Instance.isPlaying)
            {
                if (ItemSelect < 1f)
                {
                    this.generateItemCandy();
                }
                else if (ItemSelect < 2f)
                {
                    this.generateItemHat();
                }
                else if (ItemSelect < 3f)
                {
                    this.generateItemSnowflake();
                }
                else
                {
                    this.generateItemStar();
                }
            }
        }
    }

    private void generateItemCandy()
    {
        var sx = Random.Range(GameManager.LeftLimit, GameManager.RightLimit);
        var item1 = Instantiate(ItemCandy, new Vector3(sx, GameManager.UpLimit + 10f, GameManager.Z), Quaternion.identity, this.transform);
        ItemGenerator.Items.Add(item1);
    }
    private void generateItemHat()
    {
        var sx = Random.Range(GameManager.LeftLimit, GameManager.RightLimit);
        var item1 = Instantiate(ItemHat, new Vector3(sx, GameManager.UpLimit + 10f, GameManager.Z), Quaternion.identity, this.transform);
        ItemGenerator.Items.Add(item1);
    }
    private void generateItemSnowflake()
    {
        var sx = Random.Range(GameManager.LeftLimit, GameManager.RightLimit);
        var item1 = Instantiate(ItemSnowflake, new Vector3(sx, GameManager.UpLimit + 10f, GameManager.Z), Quaternion.identity, this.transform);
        ItemGenerator.Items.Add(item1);
    }
    private void generateItemStar()
    {
        var sx = Random.Range(GameManager.LeftLimit, GameManager.RightLimit);
        var item1 = Instantiate(ItemStar, new Vector3(sx, GameManager.UpLimit + 10f, GameManager.Z), Quaternion.identity, this.transform);
        ItemGenerator.Items.Add(item1);
    }
}
