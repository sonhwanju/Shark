using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    Interface[] defaultIf = new Interface[4];
    [SerializeField]
    Interface usehandle;


    public void CallRecieve(Interface handle, _TyIf type)
    {
        usehandle = handle;

        switch (type)
        {
            case _TyIf.MENU:
                
                break;
            case _TyIf.PARTSHOP:

                break;
            case _TyIf.COLLECTION:

                break;
            case _TyIf.INVENTORY:

                break;
            case _TyIf.HELP:

                break;
            case _TyIf.SETTING:

                break;
            case _TyIf.WATERTANK:

                break;
            case _TyIf.SHARKSHOP:

                break;
            case _TyIf.COSTBAR:

                break;

        }

    }

}
