using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Money //돈
{
    public int money; // 달러

    public void MoneyUpdate()
    {
        TextManaging temp = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Costbar].GetComponent<TextManaging>();
        temp.SetText(0, money.ToString() + "$");
    }

    public void AddMoney(int adder)
    {
        money = (((money + adder) > 9999999) ? 9999999 : (money + adder));
    }

    public void SubMoney(int suber)
    {
        money = money - suber;
    }
}
