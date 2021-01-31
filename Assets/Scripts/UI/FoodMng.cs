using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMng: MonoBehaviour
{
    public static FoodMng Instance;
    private bool able = false;
    public string key;
    [SerializeField] int rechargeTime = 300;  //먹이 충전 쿨타임
    [SerializeField] short downStr=1; //스트레스 깎이는 수치

    [SerializeField] GameObject inven;
    [SerializeField] Button invenBtn;
    [SerializeField] Button[] tankBtn;
    int index=0;
    bool isClick = false;
    bool isFirstTank;

    [SerializeField] GameObject Food;
    Queue<GameObject> queue = new Queue<GameObject>();

    private void Start()
    {
        Instance = this;
        for (int i = 0; i < 15; ++i)
        {
            GameObject _food = Instantiate(Food, Vector2.zero, Quaternion.identity);
            _food.transform.SetParent(transform);
            InsertFood(_food);
        }
        StartCoroutine(Recharge());
        invenBtn.onClick.AddListener(DelayKey);
        tankBtn[0].onClick.AddListener(Tank0_Click);
        tankBtn[1].onClick.AddListener(Tank1_Click);
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
        f.transform.SetParent(transform);
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
        if (key != "")
        {
            if (GameManager.Instance.foods[key].count > 0)
            {
                GameManager.Instance.foods[key].count--;
                GameObject f = GetFood();
                f.transform.position = Vector2.zero;
                f.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Foods/" + key);          //UI->Image, 2dSpr->SpriteRenderer

                f.transform.SetParent(isFirstTank?tankBtn[0].transform:tankBtn[1].transform);
                f.GetComponent<RectTransform>().position =isFirstTank? tankBtn[0].transform.position: tankBtn[1].transform.position;
                GameManager.Instance.watertank[isFirstTank?0:1].averageStr -= downStr;

                StartCoroutine(Despawn(f));
            }            
        }
    }

    private IEnumerator Despawn(GameObject f)
    {
        yield return new WaitForSeconds(10);
        InsertFood(f);
    }


    public void DelayKey()
    {
        if (!isClick)
        {
            isClick = true;
            Invoke("GiveKey", 0.5f);
        }
    }
    public void GiveKey()
    {
        foreach(string k in GameManager.Instance.foods.Keys)
        {
            inven.transform.GetChild(index).GetComponent<FoodBtn>().key = k;
            index++;
        }
    }

    public void Tank0_Click()
    {
        isFirstTank = true;  //왼쪽 수조
    }
    public void Tank1_Click()
    {
        isFirstTank = false;  //오른쪽 수조
    }
}
