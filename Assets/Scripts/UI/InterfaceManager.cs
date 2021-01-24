using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InterfaceManager : MonoBehaviour
{
    public Interface[] defaultIf = new Interface[6];
    public Interface usehandle;
    public GameObject tabhandle;



    public void CallRecieve(Interface handle, _TyIf type)
    {
        SelectButton(handle);
        CloseDefaultTab();
        if (tabhandle != null)
        {
            tabhandle.SetActive(false);
            tabhandle = null;
        }
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

                OpenTab(handle);
                SetScrollCategory(handle.childs[0], Item_Ty._WaterQuality);

                break;
            case _TyIf.COLLECTION:

                OpenTab(handle);
                SetScrollCategory(handle.childs[0], Item_Ty._Collection);

                break;
            case _TyIf.INVENTORY:

                OpenTab(handle);
                SetScrollCategory(handle.childs[0], Item_Ty._Inventory);

                break;
            case _TyIf.HELP:

                OpenTab(handle);

                break;
            case _TyIf.SETTING:

                OpenTab(handle);

                break;
            case _TyIf.WATERTANK:


                break;
            case _TyIf.SHARKSHOP:


                break;
        }
    }

    public void SetScrollCategory(Interface handle, Item_Ty type)
    {
        ScrollManaging sm = handle.GetComponent<ScrollManaging>();
        sm.type = type;
        handle.GetComponent<ScrollManaging>().ItemMake();
    }


    public void SelectButton(Interface handle)
    {
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
            {
                usehandle = null;
            }
        }
    }

    public void OpenTab(Interface handle)
    {
        if (tabhandle == null)
        {
            tabhandle = handle.childs[0].transform.parent.gameObject;
            tabhandle.SetActive(true);
            OpenDefaultTab();
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