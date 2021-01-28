using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partButton : MonoBehaviour
{
    public partstate state;
    public GameObject panel;
    public Text text;
    public Text part;
    public Image image;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(Touch);
    }

    public void Touch()
    {
        if (state == partstate.puted)
            return;
        part.text = GetComponent<ScrollItem>().itemname.text;
        image.sprite = GetComponent<ScrollItem>().image.sprite;
        Interface panelif = panel.GetComponent<Interface>();
        panelif.childs[3].GetComponent<Button>().onClick.RemoveAllListeners();
        panelif.childs[4].GetComponent<Button>().onClick.RemoveAllListeners();
        panelif.childs[4].GetComponent<Button>().onClick.AddListener(CancelPart);
        switch (state)
        {
            case partstate.notbuyed:
                text.text = "구매 하시겠습니까?";
                panelif.childs[3].GetComponent<Button>().onClick.AddListener(BuyPart);

                break;
            case partstate.buyed:
                text.text = "착용 하시겠습니까?";
                panelif.childs[3].GetComponent<Button>().onClick.AddListener(PutPart);

                break;
        }
        panel.transform.parent.gameObject.SetActive(true);
    }

    public void BuyPart()
    {
        string[] strs = part.text.Split(' ');
        switch (strs[1])
        {
            case "여과기":
                if (GameManager.Instance.money.money >= GameManager.Instance.waterquality_parts[part.text].price)
                {
                    GameManager.Instance.money.SubMoney(GameManager.Instance.waterquality_parts[part.text].price);
                    _WaterQuality wq = GameManager.Instance.waterquality_parts[part.text];
                    wq.buy = true;
                    GameManager.Instance.waterquality_parts[part.text] = wq;
                }
                    break;
            case "산소통":
                if (GameManager.Instance.money.money >= GameManager.Instance.oxygen_parts[part.text].price)
                {
                    GameManager.Instance.money.SubMoney(GameManager.Instance.oxygen_parts[part.text].price);
                    _Oxygen ox = GameManager.Instance.oxygen_parts[part.text];
                    ox.buy = true;
                    GameManager.Instance.oxygen_parts[part.text] = ox;
                }
                break;
            case "수조":
                if (GameManager.Instance.money.money >= GameManager.Instance.volume_parts[part.text].price)
                {
                    GameManager.Instance.money.SubMoney(GameManager.Instance.volume_parts[part.text].price);
                    _Volume vo = GameManager.Instance.volume_parts[part.text];
                    vo.buy = true;
                    GameManager.Instance.volume_parts[part.text] = vo;
                }
                break;
        }
        GameManager.Instance.money.MoneyUpdate();
        CancelPart();
        GameManager.Instance.interfaceManager.usehandle.childs[0].GetComponent<ScrollManaging>().ItemLoad();
    }

    public void PutPart()
    {
        string[] strs = part.text.Split(' ');
        switch (strs[1])
        {
            case "여과기":
                GameManager.Instance.watertank[0].part.waterQuality = part.text;
                GameManager.Instance.watertank[1].part.waterQuality = part.text;
                break;
            case "산소통":
                GameManager.Instance.watertank[0].part.oxygen = part.text;
                GameManager.Instance.watertank[1].part.oxygen = part.text;
                break;
            case "수조":
                GameManager.Instance.watertank[0].part.volume = part.text;
                GameManager.Instance.watertank[1].part.volume = part.text;
                break;
        }
        CancelPart();
        GameManager.Instance.interfaceManager.usehandle.childs[0].GetComponent<ScrollManaging>().ItemLoad();
    }

    public void CancelPart()
    {
        panel.transform.parent.gameObject.SetActive(false);
    }
}

public enum partstate
{
    notbuyed,
    buyed,
    puted
}
