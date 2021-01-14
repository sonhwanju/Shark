using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class _SharkData
{
    public string name; // 이름
    public int price; // 가격
    public short adultTime; //성체 되기까지의 시간
    public short stressLimit; // 스트레스 상한치
    public short special; // 희귀도
    public short maxSize; //최대 크기
    public short minSize; //최소 크기
    public short dowLimit; // 방류 상한치
    public short neWaterQuality; //필요 수질

    public _SharkData(string _name, int _price, short _audltTime, short _stressLimit, short _special, short _maxSize, short _minSize, short _dowLimit, short _neWaterQuality)
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
