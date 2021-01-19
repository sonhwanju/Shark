using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaterTank
{
    public Shark[] sharks; // 개체 넣어주기 
    public Part part; // 부품
    public short averageStr; // 평균 스트레스
    public short volume; // 용량
    public short waterQuality; //수질 (종에 알맞는 수질인지 아닌지)
}

[Serializable]
public class Part
{
    public string oxygen;
    public string waterQuality;
    public string volume;
}

[Serializable]
public struct _Oxygen
{
    public string name; // 이름
    public string image; // 이미지 이름
    public short raiting; //등급s
    public short price; // 가격
    public bool buy; // 샀냐
}

[Serializable]
public struct _WaterQuality
{
    public string name; // 이름
    public string image; // 이미지 이름
    public short raiting; // 등급
    public short price; // 가격
    public bool buy; // 샀냐
}

[Serializable]
public struct _Volume
{
    public string name; // 이름
    public string image; // 이미지 이름
    public short size; // 크기
    public short price; // 가격
    public bool buy; // 샀냐
}