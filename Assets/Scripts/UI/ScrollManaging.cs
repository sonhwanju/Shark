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
                        GameObject tempanel = GameObject.Instantiate(temp.GetComponent<Explanation>().clone, Vector3.zero, Quaternion.identity, temp.transform);
                        tempanel.transform.localPosition = new Vector3(0, 0, 0);
                        tempanel.transform.localScale = Vector3.one;
                        temp.GetComponent<Explanation>().exPanel = tempanel;
                        temp.GetComponent<Explanation>().exText = tempanel.transform.GetChild(0).GetComponent<Text>();
                        temp.GetComponent<Button>().onClick.AddListener(temp.GetComponent<Explanation>().Touch);

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
                length = GameManager.Instance.watertank[0].sharks.Count;
                this.length = length * 250;
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
                        temp.transform.localPosition = new Vector3(700, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].gameObject.SetActive(true);
                }
                if (items.Count > length)
                {
                    for (int i = length; i < items.Count; i++)
                    {
                        items[i].gameObject.SetActive(false);
                    }
                }

                break;
            case Item_Ty._Tank2:
                length = GameManager.Instance.watertank[1].sharks.Count;
                this.length = length * 250;
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
                        temp.transform.localPosition = new Vector3(700, -index * 250 - 200, 0);
                        temp.transform.localScale = Vector3.one;
                        items[index] = temp.GetComponent<ScrollItem>();
                        index++;
                    }
                }
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].gameObject.SetActive(true);
                }
                if (items.Count > length)
                {
                    for (int i = length; i < items.Count; i++)
                    {
                        items[i].gameObject.SetActive(false);
                    }
                }
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
                        temp.transform.localPosition = new Vector3(700, -index * 250 - 200, 0);
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
                    partButton pb = items[i].GetComponent<partButton>();
                    Interface tempIf = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._partshopTab];
                    pb.panel = tempIf.gameObject;
                    pb.text = tempIf.childs[0].GetComponent<Text>();
                    pb.part = tempIf.childs[1].GetComponent<Text>();
                    pb.image = tempIf.childs[2].GetComponent<Image>();
                    if (wq.name == GameManager.Instance.watertank[0].part.waterQuality)
                    {
                        items[i].content.text = "착용함";
                        pb.state = partstate.puted;
                    }
                    else if (wq.buy)
                    {
                        items[i].content.text = "구매함";
                        pb.state = partstate.buyed;
                    }
                    else
                    {
                        items[i].content.text = "가격 " + wq.price + "$";
                        pb.state = partstate.notbuyed;
                    }
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
                    partButton pb = items[i].GetComponent<partButton>();
                    Interface tempIf = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._partshopTab];
                    pb.panel = tempIf.gameObject;
                    pb.text = tempIf.childs[0].GetComponent<Text>();
                    pb.part = tempIf.childs[1].GetComponent<Text>();
                    pb.image = tempIf.childs[2].GetComponent<Image>();
                    if (ox.name == GameManager.Instance.watertank[0].part.oxygen)
                    {
                        items[i].content.text = "착용함";
                        pb.state = partstate.puted;
                    }
                    else if (ox.buy)
                    {
                        items[i].content.text = "구매함";
                        pb.state = partstate.buyed;
                    }
                    else
                    {
                        items[i].content.text = "가격 " + ox.price + "$";
                        pb.state = partstate.notbuyed;
                    }
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
                    partButton pb = items[i].GetComponent<partButton>();
                    Interface tempIf = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._partshopTab];
                    pb.panel = tempIf.gameObject;
                    pb.text = tempIf.childs[0].GetComponent<Text>();
                    pb.part = tempIf.childs[1].GetComponent<Text>();
                    pb.image = tempIf.childs[2].GetComponent<Image>();
                    if (vo.name == GameManager.Instance.watertank[0].part.volume)
                    {
                        items[i].content.text = "착용함";
                        pb.state = partstate.puted;
                        GameManager.Instance.watertank[0].volume = vo.size;
                        GameManager.Instance.watertank[1].volume = vo.size;
                    }
                    else if (vo.buy)
                    {
                        items[i].content.text = "구매함";
                        pb.state = partstate.buyed;
                    }
                    else
                    {
                        items[i].content.text = "가격 " + vo.price + "$";
                        pb.state = partstate.notbuyed;
                    }
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
                for(; i < GameManager.Instance.watertank[0].sharks.Count; i++)
                {
                    _SharkData sd = GameManager.Instance.sharks[GameManager.Instance.watertank[0].sharks[i].name];
                    items[i].image.sprite = GameManager.Instance.sprites[sd.name];
                    items[i].itemname.text = GameManager.Instance.watertank[0].sharks[i].stress.ToString();
                    items[i].content.text = GameManager.Instance.watertank[0].sharks[i].hunger.ToString();
                    items[i].content.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.watertank[0].sharks[i].curSize.ToString();
                }
                break;
            case Item_Ty._Tank2:
                for (; i < GameManager.Instance.watertank[1].sharks.Count; i++)
                {
                    _SharkData sd = GameManager.Instance.sharks[GameManager.Instance.watertank[1].sharks[i].name];
                    items[i].image.sprite = GameManager.Instance.sprites[sd.name];
                    items[i].itemname.text = GameManager.Instance.watertank[1].sharks[i].stress.ToString();
                    items[i].content.text = GameManager.Instance.watertank[1].sharks[i].hunger.ToString();
                    items[i].content.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.watertank[1].sharks[i].curSize.ToString();
                }
                break;
            case Item_Ty._SharkShop:
                foreach (string key in GameManager.Instance.sharks.Keys)
                {
                    _SharkData sd = GameManager.Instance.sharks[key];
                    items[i].image.sprite = GameManager.Instance.sprites[key];
                    items[i].itemname.text = sd.name;
                    items[i].content.text = "가격 " + sd.price + "$";
                    items[i].index = i;
                    i++;
                }
                GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._TextEditor].GetComponent<SharkPlus>().SelectShark(0);
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
