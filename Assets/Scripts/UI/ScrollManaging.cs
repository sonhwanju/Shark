using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManaging : MonoBehaviour
{
    public List<ScrollItem> items;
    public Category[] categories;
    public Item_Ty type;
    public float length = 1000;
    public GameObject[] item_clone;

    private void Update()
    {
        float nyan = GetComponent<ScrollRect>().content.transform.localPosition.y;
        if ((nyan < 0) || (nyan > length))
        {
            if (nyan < 0)
            {
                GetComponent<ScrollRect>().content.transform.localPosition = Vector2.zero;
            }
            else
            {
                GetComponent<ScrollRect>().content.transform.localPosition = new Vector2(0, length);
            }
        }
    }

    public void ItemMake()
    {
        int length;
        int index;
        int num;
        switch (type)
        {
            case Item_Ty._WaterQuality:
                length = GameManager.Instance.waterquality_parts.Keys.Count;
                index = items.Count;
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(600, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
            case Item_Ty._Oxygen:
                length = GameManager.Instance.oxygen_parts.Keys.Count;
                index = items.Count; 
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(600, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
            case Item_Ty._Volume:
                length = GameManager.Instance.volume_parts.Keys.Count;
                index = items.Count;
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(600, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
            case Item_Ty._Collection:
                length = GameManager.Instance.sharks.Keys.Count;
                index = items.Count;
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(600, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
            case Item_Ty._Inventory:
                length = GameManager.Instance.foods.Keys.Count;
                index = items.Count;
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(100 + 250 * (index % 5), -(index / 5) * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
            case Item_Ty._Tank1:
                break;
            case Item_Ty._Tank2:
                break;
            case Item_Ty._SharkShop:
                length = GameManager.Instance.sharks.Keys.Count;
                index = items.Count;
                num = items.Count;
                if (items.Count < length)
                {
                    for (int i = 0; i < length - num; i++)
                    {
                        items.Add(null);
                    }
                    for (int i = 0; i < length - num; i++)
                    {
                        GameObject temp = GameObject.Instantiate(item_clone[0], Vector3.zero, Quaternion.identity, GetComponent<ScrollRect>().content.transform);
                        temp.transform.localPosition = new Vector3(0, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                break;
        }
        ItemLoad();
    }

    public void ItemLoad()
    {
        GetComponent<ScrollRect>().content.transform.localPosition = Vector3.zero;
        int i = 0;
        switch (type)
        {
            case Item_Ty._WaterQuality:
                foreach (string key in GameManager.Instance.waterquality_parts.Keys)
                {
                    _WaterQuality wq = GameManager.Instance.waterquality_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = wq.name;
                    items[i].content.text = "가격 " + wq.price + "$";
                    i++;
                }
                CategorySelect();
                break;
            case Item_Ty._Oxygen:
                foreach (string key in GameManager.Instance.oxygen_parts.Keys)
                {
                    _Oxygen ox = GameManager.Instance.oxygen_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = ox.name;
                    items[i].content.text = "가격 " + ox.price + "$";
                    i++;
                }
                CategorySelect();
                break;
            case Item_Ty._Volume:
                foreach (string key in GameManager.Instance.volume_parts.Keys)
                {
                    _Volume vo = GameManager.Instance.volume_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = vo.name;
                    items[i].content.text = "가격 " + vo.price + "$";
                    i++;
                }
                CategorySelect();
                break;
            case Item_Ty._Collection:
                foreach (string key in GameManager.Instance.sharks.Keys)
                {
                    _SharkData sd = GameManager.Instance.sharks[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = sd.name;
                    items[i].content.text = "등급 " + sd.special;
                    i++;
                }
                break;
            case Item_Ty._Inventory:
                foreach (string key in GameManager.Instance.foods.Keys)
                {
                    
                    _Food fd = GameManager.Instance.foods[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].content.text = fd.count.ToString();
                    i++;
                }
                break;
            case Item_Ty._Tank1:
                break;
            case Item_Ty._Tank2:
                break;
            case Item_Ty._SharkShop:
                foreach (string key in GameManager.Instance.sharks.Keys)
                {
                    _SharkData sd = GameManager.Instance.sharks[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = sd.name;
                    items[i].content.text = "가격 " + sd.price + "$";
                    i++;
                }
                break;
        }
    }

    public void CategorySelect()
    {
        for (int i = 0; i < categories.Length; i++)
        {
            categories[i].GetComponent<Image>().sprite = categories[i].sprites[0];
        }

        switch (type)
        {
            case Item_Ty._WaterQuality:
                categories[0].GetComponent<Image>().sprite = categories[0].sprites[1];
                break;
            case Item_Ty._Oxygen:
                categories[1].GetComponent<Image>().sprite = categories[1].sprites[1];
                break;
            case Item_Ty._Volume:
                categories[2].GetComponent<Image>().sprite = categories[2].sprites[1];
                break;
        }
    }
}

public enum Item_Ty
{
    _WaterQuality,
    _Oxygen,
    _Volume,
    _Collection,
    _Inventory,
    _Tank1,
    _Tank2,
    _SharkShop
}
