using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public Interface[] childs;
    [SerializeField]
    private _TyIf type;
    public Interface parent;


    public Interface(Interface parent, _TyIf type)
    {
        this.parent = parent;
        this.type = type;
    }

    public void Press()
    {
        GameManager.Instance.interfaceManager.CallRecieve(this, type);
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