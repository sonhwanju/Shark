using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMng: MonoBehaviour
{
    public static FoodMng Instance;
    private bool able = false;
    public string key;
    [SerializeField] int rechargeTime = 300;

    [SerializeField] GameObject Food;
    Queue<GameObject> queue = new Queue<GameObject>();

    private void Start()
    {
        Instance = this;
        for (int i = 0; i < 20; ++i)
        {
            GameObject _food = Instantiate(Food, Vector2.zero, Quaternion.identity);
            _food.transform.SetParent(transform);
            InsertFood(_food);
        }
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
        yield return new WaitForSeconds(rechargeTime);
        able = true;
    }

    public void InsertFood(GameObject f)
    {
        queue.Enqueue(f);
        f.SetActive(false);
    }
    public GameObject GetFood()
    {
        GameObject f = queue.Dequeue();
        f.SetActive(true);
        return f;
    }
    public void SpawnFood()
    {
        if (GameManager.Instance.foods[key].count > 0)
        {
            GameManager.Instance.foods[key].count--;
            GameObject f = GetFood();
            f.transform.position = Vector2.zero;  //임시 생성위치
            f.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Foods/" + key);
        }            //UI->Image, 2dSpr->SpriteRenderer
    }
}
