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
    public _Oxygen oxygen;
    public _WaterQuality waterQuality;
    public _Volume volume;
}

[Serializable]
public struct _Oxygen
{
    public short raiting; //등급s
}

[Serializable]
public struct _WaterQuality
{
    public short raiting; // 등급
}

[Serializable]
public struct _Volume
{
    public short size; // 크기
}