using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMng : MonoBehaviour
{
    private bool able;
    private int t;
    [SerializeField] int rechargeTime=300;

    private void Start()
    {
        if (PlayerPrefs.HasKey("T"))
            t = PlayerPrefs.GetInt("T");
        able = t != 0 ? false : true;

        if (!able) StartCoroutine(Recharge());
    }

    public void ClickFoodBox()
    {
        if (able)
        {
            able = false;
            t = rechargeTime;
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
        else
        {
            //남은 시간
        }
    }

    IEnumerator Recharge()
    {
        for(;;)
        {
            yield return new WaitForSeconds(1);
            t--;

            if (t == 0)
            {
                able = true;
                break;
            }
        }
    }

    private void OnApplicationQuit() => PlayerPrefs.SetInt("T", t);

    //public void TestFunc() => PlayerPrefs.DeleteKey("T");
}
