using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPlus : MonoBehaviour
{  
    public bool Shark_Plus(int index, _SharkData data, int count)
    {
        if(GameManager.Instance.watertank[index].sharks.Count == 0) //수조에 상어가 없다면
        {
            for (int i = 0; i < count; i++)
            {
                GameManager.Instance.watertank[index].sharks.Add(null);
                GameManager.Instance.watertank[index].sharks[i].name = data.name;
            }
            return true;
        }
        else if(GameManager.Instance.watertank[index].sharks[0].name == data.name) // 수조에 똑같은 상어가 있다면
        {
            for (int i = 0; i < count; i++)
            {
                int length = GameManager.Instance.watertank[index].sharks.Count;
                GameManager.Instance.watertank[index].sharks.Add(null);
                GameManager.Instance.watertank[index].sharks[i + length].name = data.name;
            }
            return true;
        }
        else // 다른 상어가 있다넹
        {
            return false;
        }
    }
}
