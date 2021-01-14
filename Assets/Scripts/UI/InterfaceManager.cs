using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    Interface[] defaultIf = new Interface[6];
    [SerializeField]
    Interface usehandle;


    public void CallRecieve(Interface handle, _TyIf type)
    {
        SelectButton(handle);
        switch (type)
        {
            case _TyIf.MENU:
                if (usehandle != null)
                {
                    for (int i = 0; i < handle.childs.Length; i++)
                    {
                        Interface temp = handle.childs[i];
                        RectTransform h = handle.GetComponent<RectTransform>();
                        float moveF = h.localPosition.y - (h.rect.height * (i + 1));
                        temp.transform.DOLocalMoveY(moveF, 0.5f).SetEase(Ease.OutCubic);
                    }
                }
                else
                {
                    for (int i = handle.childs.Length - 1; i > -1; i--)
                    {
                        Interface temp = handle.childs[i];
                        RectTransform h = handle.GetComponent<RectTransform>();
                        float moveF = h.localPosition.y;
                        temp.transform.DOLocalMoveY(moveF, 0.5f).SetEase(Ease.OutCubic);
                    }
                }
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

    public void SelectButton(Interface handle)
    {
        if (usehandle == null)
        {
            handle.transform.DOScale(Vector3.one * 1.2f, 0.5f);
            usehandle = handle;
        }
        else
        {
            usehandle.transform.DOScale(Vector3.one, 0.5f);
            if (usehandle != handle)
            {
                handle.transform.DOScale(Vector3.one * 1.2f, 0.5f);
                usehandle = handle;
            }
            else
                usehandle = null;
        }
    }

}

public enum _DefaultInterface
{
    _Menu,
    _Costbar,
    _Sight,
    _Tank1,
    _Tank2,
    _Sharkshop
}