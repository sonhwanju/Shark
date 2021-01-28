using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBtn : MonoBehaviour
{
    string key;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickBtn);
    }

    void ClickBtn()
    {
        key = GetComponent<ScrollItem>().itemname.text;
        FoodMng.Instance.key=key;
    }
}
