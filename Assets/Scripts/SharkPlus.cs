using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkPlus : MonoBehaviour
{
    public void Shark_Plus()
    {
        if(GameManager.Instance.watertank[0].sharks.Length == 0) //수조에 상어가 없다면
        {
            //귀상어 추가
            for (int i = 0; i < GameManager.Instance.watertank[0].sharks.Length; i++)
            {
                GameManager.Instance.watertank[0].sharks[i] = 
            }
        }
        else if(GameManager.Instance.watertank[0].sharks[0].name == "귀상어") // 수조에 똑같은 상어가 있다면
        {

        }
    }
}
