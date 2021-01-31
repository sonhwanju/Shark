using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMng: MonoBehaviour
{
    private bool able = false;
  
    [SerializeField] int rechargeTime = 300;  //먹이 충전 쿨타임
    [SerializeField] Button foodBox; 

    private void Start()
    { 
        StartCoroutine(Recharge());   
    }

    public void ClickFoodBox()
    {
        if (able)  
        {
            able = false;
            StartCoroutine(Recharge());
            int r = Random.Range(1, 101);

            if (r <= 15)
            {
                GameManager.Instance.foods["고등어"].count++;
            }
            else if (r <= 25)
            {
                GameManager.Instance.foods["갈치"].count++;
            }
            else if (r <= 35)
            {
                GameManager.Instance.foods["메기"].count++;
            }
            else if (r <= 40)
            {
                GameManager.Instance.foods["참돔"].count++;
            }
            else if (r <= 55)
            {
                GameManager.Instance.foods["새우"].count++;
            }
            else if (r <= 65)
            {
                GameManager.Instance.foods["가재"].count++;
            }
            else if (r <= 70)
            {
                GameManager.Instance.foods["대게"].count++;
            }
            else if (r <= 85)
            {
                GameManager.Instance.foods["오징어"].count++;
            }
            else if (r <= 95)
            {
                GameManager.Instance.foods["문어"].count++;
            }
            else
            {
                GameManager.Instance.foods["낙지"].count++;
            }
        }
        /* else
         {

         }*/
    }

    IEnumerator Recharge()
    {
        Color c = foodBox.GetComponent<Image>().color;
        c.a = 0;
        foodBox.GetComponent<Image>().color=c;
        yield return new WaitForSeconds(rechargeTime);
        able = true;
        c.a = 1;
        foodBox.GetComponent<Image>().color = c;
    }
}
