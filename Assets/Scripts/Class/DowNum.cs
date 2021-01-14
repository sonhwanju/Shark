using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DowNum //방류 수
{
    public int shark1; // 상어 1급
    public int shark2; // 상어 2급
    public int shark3; // 상어 3급

    public void SharkUpdate()
    {
        TextManaging temp = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Costbar].GetComponent<TextManaging>();
        temp.SetText(1, shark1.ToString());
        temp.SetText(2, shark2.ToString());
        temp.SetText(3, shark3.ToString());
    }

    public void AddShark(int index, int adder)
    {
        switch(index)
        {
            case 1:
                shark1 = (((shark1 + adder) > 9999999) ? 9999999 : (shark1 + adder));
                break;
            case 2:
                shark2 = (((shark2 + adder) > 9999999) ? 9999999 : (shark2 + adder));
                break;
            case 3:
                shark3 = (((shark3 + adder) > 9999999) ? 9999999 : (shark3 + adder));
                break;
        }
    }

    public void SubShark(int index, int suber)
    {
        switch (index)
        {
            case 1:
                shark1 = shark1 - suber;
                break;
            case 2:
                shark2 = shark2 - suber;
                break;
            case 3:
                shark3 = shark3 - suber;
                break;
        }
    }
}
