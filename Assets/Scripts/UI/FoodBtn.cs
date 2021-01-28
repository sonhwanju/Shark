using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBtn : MonoBehaviour
{
    public string key;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickBtn);
    }

    void ClickBtn()
    {
        //key = GetComponent<ScrollItem>().itemname.text;  텍스트가 없음
        FoodMng.Instance.key=key;
    }
}
