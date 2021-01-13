using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    
}


public class _Shark
{
    private string name; // 이름
    private int price; // 가격
    private short adultTime; //성체 되기까지의 시간
    private short stressLimit; // 스트레스 상한치
    private short special; // 희귀도
    private short maxSize; //최대 크기
    private short minSize; //최소 크기
    private short dowLimit; // 방류 상한치
    private short neWaterQuality; //필요 수질

    public _Shark(string _name, int _price, short _audltTime, short _stressLimit, short _special, short _maxSize, short _minSize, short _dowLimit, short _neWaterQuality)
    {
        this.name = _name;
        this.price = _price;
        this.adultTime = _audltTime;
        this.stressLimit = _stressLimit;
        this.special = _special;
        this.maxSize = _maxSize;
        this.minSize = _minSize;
        this.dowLimit = _dowLimit;
        this.neWaterQuality = _neWaterQuality;
    }
}

public class Shark
{
    private short hunger; // 배고픔
    private short curSize; // 현재 크기
    private short stress; // 스트레스
}

public class WaterTank
{
    private Shark[] shark; // 개체 넣어주기 
    private short averageStr; // 평균 스트레스
    private short volume; // 용량
    private short waterQuality; //수질 (종에 알맞는 수질인지 아닌지)
}