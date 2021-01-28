using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkPlus : MonoBehaviour
{
    [SerializeField]
    private Text sharkText;

    public int _count;
    public int _index; // 고른 수조

    public _SharkData _sharkData; // 고른 상어
    public Sprite[] sprite = new Sprite[4];

    public Image[] tkbt = new Image[2];

    public int handle;
    private void Start()
    {
        _count = 1;
        SelectTank1();
    }

    public bool Shark_Plus(int index, _SharkData data, int count)
    {
        if(GameManager.Instance.watertank[index].sharks.Count == 0) //수조에 상어가 없다면
        {
            for (int i = 0; i < count; i++)
            {
                GameManager.Instance.watertank[index].sharks.Add(null);
                GameManager.Instance.watertank[index].sharks[i].name = data.name;
            }
            return true;
        }
        else if(GameManager.Instance.watertank[index].sharks[0].name == data.name) // 수조에 똑같은 상어가 있다면
        {
            for (int i = 0; i < count; i++)
            {
                int length = GameManager.Instance.watertank[index].sharks.Count;
                GameManager.Instance.watertank[index].sharks.Add(null);
                GameManager.Instance.watertank[index].sharks[i + length].name = data.name;
            }
            return true;
        }
        else // 다른 상어가 있다넹
        {
            return false;
        }
    }
    public void Buy() //테스트 안해봄...되는지는 모르겠어요 - 아직 버튼연동 X
    {
        if(GameManager.Instance.money.money >= _count * _sharkData.price)
        {
            GameManager.Instance.money.SubMoney(_count * _sharkData.price);
            GameManager.Instance.money.MoneyUpdate();
            Shark_Plus(_index, _sharkData, _count);
        }
        else if(GameManager.Instance.money.money < _sharkData.price)
        {
            //돈 부족
            return;
        }
    }

    public void Text_Plus()
    {
        _count++;
        sharkText.text = _count + "x";
    }

    public void Text_Minus()
    {
        if (_count > 1)
        {
            _count--;
            sharkText.text = _count + "x";
        }
    }

    public void SelectShark(int h)
    {
        ScrollManaging sm = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].childs[0].GetComponent<ScrollManaging>();
        sm.items[handle].GetComponent<Image>().sprite = sprite[0];
        handle = h;
        _sharkData = GameManager.Instance.sharks[sm.items[handle].GetComponent<ScrollItem>().itemname.text];
        sm.items[handle].GetComponent<Image>().sprite = sprite[1];
    }

    public void SelectTank1()
    {
        tkbt[1].sprite = sprite[2];
        _index = 0;
        tkbt[0].sprite = sprite[3];
    }
    public void SelectTank2()
    {
        tkbt[0].sprite = sprite[2];
        _index = 1;
        tkbt[1].sprite = sprite[3];
    }
}
