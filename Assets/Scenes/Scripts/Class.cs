using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}


public class _Shark
{
    private Dictionary<short, string> dicShark = new Dictionary<short, string>();
    short adultTime; //성체 되기까지의 시간
    short stressLimit; // 스트레스 상한치
    short special; // 희귀도
    short maxSize, minSize; //최대, 최소 크기
    int price; // 가격
    string name; // 이름
    short dowLimit; // 방류 상한치
    short neWaterQuality; //필요 수질
}

public class Shark
{
    short hunger; // 배고픔
    short curSize; // 현재 크기
    short stress; // 스트레스
}

public class WaterTank
{
    short averageStr; // 평균 스트레스
    short volume; // 용량
    Shark[]; // 개체 넣어주기 
    short waterQuality; //수질 (종에 알맞는 수질인지 아닌지)


}