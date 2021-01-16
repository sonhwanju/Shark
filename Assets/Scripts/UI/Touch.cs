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

    Queue<bool> TouchQueue;

    private void Start()
    {
        TouchQueue = new Queue<bool>(5);
    }

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


        if (GameManager.Instance.isSea)
        {
            if ((startposition.x > Screen.width / 5 * 4) && (endposition.x > Screen.width / 5 * 2))
            {
                if ((startposition.x > endposition.x) && (GameManager.Instance.interfaceManager.usehandle == null))
                {
                    blackout.gameObject.SetActive(true);
                    blackout.DOFade(1f, 0.5f).OnComplete(()=> {
                        GameObject obj = GameManager.Instance.transform.GetChild(0).gameObject;
                        obj.transform.localPosition = new Vector3(0, 0, -10);
                        GameManager.Instance.isSea = false;
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank1].gameObject.SetActive(true);
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank2].gameObject.SetActive(true);
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].gameObject.SetActive(false);
                        GameManager.Instance.interfaceManager.usehandle = null;
                        blackout.DOFade(0, 0.5f);
                        blackout.gameObject.SetActive(false);
                    });
                }
            }
        }
        else
        {
            if ((startposition.x < Screen.width / 5) && (endposition.x < Screen.width / 5 * 3))
            {
                if ((startposition.x < endposition.x) && (GameManager.Instance.interfaceManager.usehandle == null))
                {
                    blackout.gameObject.SetActive(true);
                    blackout.DOFade(1f, 0.5f).OnComplete(() => {
                        GameObject obj = GameManager.Instance.transform.GetChild(0).gameObject;
                        obj.transform.localPosition = new Vector3(-20, 0, -10);
                        GameManager.Instance.isSea = true;
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank1].gameObject.SetActive(false);
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Tank2].gameObject.SetActive(false);
                        GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._Sharkshop].gameObject.SetActive(true);
                        GameManager.Instance.interfaceManager.usehandle = null;
                        blackout.DOFade(0, 0.5f);
                        blackout.gameObject.SetActive(false);
                    });
                }
            }
        }

    }
}
