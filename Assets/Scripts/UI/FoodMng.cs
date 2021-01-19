using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMng : MonoBehaviour
{
    private bool able = true;

    public void ClickFoodBox()
    {
        if (able)
        {
            StartCoroutine(Reuse());
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
    }

    IEnumerator Reuse()
    {
        able = false;
        yield return new WaitForSeconds(300);
        able = true;
    }
}
