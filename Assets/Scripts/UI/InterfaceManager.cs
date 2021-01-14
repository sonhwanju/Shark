using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    Interface[] defaultIf = new Interface[4];
    [SerializeField]
    Interface usehandle;


    public void CallRecieve(Interface handle, _TyIf type)
    {
        switch (type)
        {
            case _TyIf.MENU:
                if (usehandle == null)
                {
                    for (int i = 0; i < handle.childs.Length; i++)
                    {
                        Interface temp = handle.childs[i];
                        RectTransform h = handle.GetComponent<RectTransform>();
                        float moveF = h.localPosition.y - (h.rect.height * (i + 1));
                        temp.transform.DOLocalMoveY(moveF, 1).SetEase(Ease.OutCubic);
                        usehandle = handle;
                    }
                }
                else
                {
                    for (int i = handle.childs.Length - 1; i > -1; i--)
                    {
                        Interface temp = handle.childs[i];
                        RectTransform h = handle.GetComponent<RectTransform>();
                        float moveF = h.localPosition.y;
                        temp.transform.DOLocalMoveY(moveF, 1).SetEase(Ease.OutCubic);
                        usehandle = null;
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

}
