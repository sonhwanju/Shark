using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InterfaceManager : MonoBehaviour
{
    public Interface[] defaultIf = new Interface[6];
    public Interface usehandle;



    public void CallRecieve(Interface handle, _TyIf type)
    {
        SelectButton(handle);
        switch (type)
        {
            case _TyIf.MENU:
                Interface temp;
                RectTransform h = handle.GetComponent<RectTransform>();
                float moveF;
                if (usehandle != null)
                {
                    for (int i = 0; i < handle.childs.Length; i++)
                    {
                        temp = handle.childs[i];
                        moveF = h.localPosition.y - (h.rect.height * 1.07f * (i + 1));
                        temp.transform.DOLocalMoveY(moveF, 0.5f).SetEase(Ease.OutCubic);
                    }
                }
                else
                {
                    for (int i = handle.childs.Length - 1; i > -1; i--)
                    {
                        temp = handle.childs[i];
                        moveF = h.localPosition.y;
                        temp.transform.DOLocalMoveY(moveF, 0.5f).SetEase(Ease.OutCubic);
                    }
                }
                break;
            case _TyIf.PARTSHOP:

                OpenDefaultTab();
                break;
            case _TyIf.COLLECTION:

                OpenDefaultTab();
                break;
            case _TyIf.INVENTORY:

                OpenDefaultTab();
                break;
            case _TyIf.HELP:

                OpenDefaultTab();
                break;
            case _TyIf.SETTING:

                OpenDefaultTab();
                break;
            case _TyIf.WATERTANK:


                break;
            case _TyIf.SHARKSHOP:


                break;
        }
    }

    public void SelectButton(Interface handle)
    {
        CloseDefaultTab();
        if (usehandle == null)
        {
            handle.transform.DOScale(Vector3.one * 1.14f, 0.5f);
            usehandle = handle;
        }
        else
        {
            usehandle.transform.DOScale(Vector3.one, 0.5f);
            if (usehandle != handle)
            {
                handle.transform.DOScale(Vector3.one * 1.14f, 0.5f);
                usehandle = handle;
            }
            else
                usehandle = null;
        }
    }

    public void OpenDefaultTab()
    {
        if (usehandle != null)
        {
            Interface tab = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tab];
            tab.transform.localScale = Vector2.one;
            tab.transform.DOScale(Vector2.zero, 1f).From(false).SetEase(Ease.OutQuint);
        }
    }

    public void CloseDefaultTab()
    {
        Interface tab = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tab];
        tab.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.OutQuint);
    }

}

public enum _DefaultInterface
{
    _Menu,
    _Costbar,
    _Tab,
    _Tank1,
    _Tank2,
    _Sharkshop
}