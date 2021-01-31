using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManaging : MonoBehaviour
{
    public bool[] start = { false, false };
    public int time;

    public void Start()
    {
        StartCoroutine(Tank(0));
        StartCoroutine(Tank(1));
    }

    IEnumerator Tank(int index)
    {
        for (; ; )
        {
            if (start[index])
            {
                GameManager.Instance.watertank[index].waterQuality = GameManager.Instance.waterquality_parts[GameManager.Instance.watertank[index].part.waterQuality].raiting;
                if (GameManager.Instance.watertank[index].sharks.Count != 0)
                {
                    _SharkData sd = GameManager.Instance.sharks[GameManager.Instance.watertank[index].sharks[0].name];
                    int tankvolume = 0;
                    for (int i = 0; i < GameManager.Instance.watertank[index].sharks.Count; i++)
                    {
                        tankvolume += GameManager.Instance.watertank[index].sharks[i].curSize;
                    }

                    if (tankvolume > GameManager.Instance.watertank[index].volume)
                    {
                        for (int i = 0; i < GameManager.Instance.watertank[index].sharks.Count; i++)
                        {
                            tankvolume += GameManager.Instance.watertank[index].sharks[i].stress++;
                        }
                    }

                    if (GameManager.Instance.watertank[index].volume < GameManager.Instance.oxygen_parts[GameManager.Instance.watertank[index].part.oxygen].raiting)
                    {
                        for (int i = 0; i < GameManager.Instance.watertank[index].sharks.Count; i++)
                        {
                            tankvolume += GameManager.Instance.watertank[index].sharks[i].stress++;
                        }
                    }

                    if (tankvolume > GameManager.Instance.waterquality_parts[GameManager.Instance.watertank[index].part.waterQuality].raiting)
                    {
                        for (int i = 0; i < GameManager.Instance.watertank[index].sharks.Count; i++)
                        {
                            tankvolume += GameManager.Instance.watertank[index].sharks[i].stress++;
                        }
                    }

                    for (int i = 0; i < GameManager.Instance.watertank[index].sharks.Count; i++)
                    {
                        GameManager.Instance.watertank[index].sharks[i].curSize += sd.dowLimit;
                        GameManager.Instance.watertank[index].sharks[i].curSize = (short)Mathf.Clamp(GameManager.Instance.watertank[index].sharks[i].curSize, sd.minSize, sd.maxSize);
                        if (GameManager.Instance.watertank[index].sharks[i].stress > sd.stressLimit)
                        {
                            //사망!
                            GameManager.Instance.watertank[index].sharks.RemoveAt(i);
                        }
                    }
                }

            }
            else
            {
                start[index] = true;
            }
            yield return new WaitForSeconds(time);
        }
    }
}
