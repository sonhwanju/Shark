using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManaging : MonoBehaviour
{
    public Text[] texts = new Text[0];

    public void SetText(int index, string text)
    {
        if (texts[index] != null)
        {
            texts[index].text = text;
        }
    }
}