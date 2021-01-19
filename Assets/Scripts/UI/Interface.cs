using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Interface[] childs;
    [SerializeField]
    private _TyIf type;
    public Interface parent;
    public string subtype;


    public Interface(Interface parent, _TyIf type)
    {
        this.parent = parent;
        this.type = type;
    }

    private void Start()
    {
        if (!(GetComponent<Button>() == null))
        {
            if (type != _TyIf.TAB)
                GetComponent<Button>().onClick.AddListener(Press);
        }
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
    COSTBAR,
    TAB
};