using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class _SharkData
{
    public string name; // 이름
    public string image; // 이미지 이름
    public string[] food; // 먹는 음식
    public int price; // 가격
    public short adultTime; //성체 되기까지의 시간
    public short stressLimit; // 스트레스 상한치
    public short special; // 희귀도
    public short maxSize; //최대 크기
    public short minSize; //최소 크기
    public short dowLimit; // 하루 성장폭
    public short neWaterQuality; //필요 수질
}
