using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explanation : MonoBehaviour
{
    public GameObject clone;
    public GameObject exPanel;
    public Text exText;

    private int x = 1;

    private void Start()
    {
        if (exPanel != null)
            exPanel.SetActive(false);
    }

    public void Touch()
    {
        if(x == 1)
        {
            exPanel.SetActive(true);
            exText.text = GameManager.Instance.contents[GetComponent<ScrollItem>().itemname.text];
            x = 2;
        }
        else if(x == 2)
        {
            exPanel.SetActive(false);
            x = 1;
        }
        
    }
}
    