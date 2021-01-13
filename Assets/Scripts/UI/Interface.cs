using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{

    private short instance;
    private _TyIf type;


    public Interface(short instance, _TyIf type)
    {
        this.instance = instance;
        this.type = type;
    }

    public void PressButton()
    {

    }
}
public enum _TyIf
{
    MENU,
    PARTSHOP,
    COLLECTION,
    INVENTORY,
    HELP,
    SETTING,
    WATERTANK,
    SHARKSHOP,
    COSTBAR
};