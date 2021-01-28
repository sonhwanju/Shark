using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ScrollItem : MonoBehaviour
{
    public Image image;
    public Text itemname;
    public Text content;
    public int index;

    private void Start()
    {
        if (transform.parent.parent.parent.GetComponent<ScrollManaging>().type == Item_Ty._SharkShop)
        {
            GetComponent<Button>().onClick.AddListener(() => GameManager.Instance.interfaceManager.defaultIf[(int)_DefaultInterface._TextEditor].GetComponent<SharkPlus>().SelectShark(index));
        }
    }
}
