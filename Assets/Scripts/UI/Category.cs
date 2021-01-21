using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    public Interface scroll;
    public Item_Ty type;

    public void Start()
    {
        if (GetComponent<Button>() != null)
        {
            GetComponent<Button>().onClick.AddListener(SetScrollCategory);
        }
    }

    public void SetScrollCategory()
    {
        ScrollManaging sm = scroll.GetComponent<ScrollManaging>();
        sm.type = type;
        scroll.GetComponent<ScrollManaging>().ItemLoad();
    }

}
