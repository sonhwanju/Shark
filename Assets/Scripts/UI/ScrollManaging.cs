using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManaging : MonoBehaviour
{
    public List<ScrollItem> items;
    public Item_Ty type;
    public float length = 1000;
    public GameObject item_clone;

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

    }

    public void ItemLoad()
    {
        int i = 0;
        switch (type)
        {
            case Item_Ty._WaterQuality:
                foreach (string key in GameManager.Instance.waterquality_parts.Keys)
                {
                    _WaterQuality wq = GameManager.Instance.waterquality_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = wq.name;
                    items[i].price.text = "가격 " + wq.price + "$";
                    i++;
                }
                break;
            case Item_Ty._Oxygen:
                foreach (string key in GameManager.Instance.oxygen_parts.Keys)
                {
                    _Oxygen ox = GameManager.Instance.oxygen_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = ox.name;
                    items[i].price.text = "가격 " + ox.price + "$";
                    i++;
                }
                break;
            case Item_Ty._Volume:
                foreach (string key in GameManager.Instance.volume_parts.Keys)
                {
                    _Volume vo = GameManager.Instance.volume_parts[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = vo.name;
                    items[i].price.text = "가격 " + vo.price + "$";
                    i++;
                }
                break;
            case Item_Ty._Collection:
                break;
            case Item_Ty._Inventory:
                break;
            case Item_Ty._Tank1:
                break;
            case Item_Ty._Tank2:
                break;
            case Item_Ty._SharkShop:
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
