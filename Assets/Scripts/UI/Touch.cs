using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{

    public Vector2 startposition;
    public Vector2 endposition;

    [SerializeField]
    private Image blackout;
    private bool nyan = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startposition = Input.mousePosition;
            endposition = new Vector2(float.NaN, float.NaN);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endposition = Input.mousePosition;
        }

        if (nyan)
        {
            if (GameManager.Instance.isSea)
            {
                if ((startposition.x > Screen.width / 5 * 4) && (endposition.x > Screen.width / 5 * 2))
                {
                    if (((startposition.x - endposition.x) > Screen.width / 10) && (GameManager.Instance.interfaceManager.usehandle == null))
                    {
                        blackout.gameObject.SetActive(true);
                        blackout.DOFade(1f, 0.5f).OnComplete(() =>
                        {
                            nyan = false;
                            GameObject obj = GameManager.Instance.transform.GetChild(0).gameObject;
                            obj.transform.localPosition = new Vector3(0, 0, -10);
                            GameManager.Instance.isSea = false;
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank1].gameObject.SetActive(true);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank2].gameObject.SetActive(true);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].gameObject.SetActive(false);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._FoodBoxBtn].gameObject.SetActive(false);
                            GameManager.Instance.interfaceManager.usehandle = null;
                            blackout.DOFade(0, 0.5f).OnComplete(() =>
                            {
                                nyan = true;
                            });
                            blackout.gameObject.SetActive(false);
                        });
                    }
                }
            }
            else
            {
                if ((startposition.x < Screen.width / 5) && (endposition.x < Screen.width / 5 * 3))
                {
                    if (((endposition.x - startposition.x) > Screen.width / 10) && (GameManager.Instance.interfaceManager.usehandle == null))
                    {
                        blackout.gameObject.SetActive(true);
                        blackout.DOFade(1f, 0.5f).OnComplete(() =>
                        {
                            nyan = false;
                            GameObject obj = GameManager.Instance.transform.GetChild(0).gameObject;
                            obj.transform.localPosition = new Vector3(-20, 0, -10);
                            GameManager.Instance.isSea = true;
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank1].gameObject.SetActive(false);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank2].gameObject.SetActive(false);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].gameObject.SetActive(true);
                            GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._FoodBoxBtn].gameObject.SetActive(true);
                            GameManager.Instance.interfaceManager.usehandle = null;
                            blackout.DOFade(0, 0.5f).OnComplete(() =>
                            {
                                nyan = true;
                            });
                            blackout.gameObject.SetActive(false);
                        });
                    }
                }
            }
        }

        if ((GameManager.Instance.interfaceManager.tabhandle == GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank1].childs[0].transform.parent.gameObject) || (GameManager.Instance.interfaceManager.tabhandle == GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank2].childs[0].transform.parent.gameObject) || (GameManager.Instance.interfaceManager.tabhandle == GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].childs[0].transform.parent.gameObject))
        {
            if ((endposition.y > Screen.height / 5 * 4) && (startposition.y > Screen.height / 5 * 4))
            {
                if (GameManager.Instance.interfaceManager.usehandle != null)
                {
                    GameManager.Instance.interfaceManager.usehandle.transform.DOScale(Vector3.one, 0.5f);
                    GameManager.Instance.interfaceManager.usehandle = null;
                }
                startposition = new Vector2(float.NaN, float.NaN);
                endposition = new Vector2(float.NaN, float.NaN);
                Interface tab = GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._SpecialTab];
                tab.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.OutQuint);
            }
        }
    }
}
