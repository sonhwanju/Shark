using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaterTank
{
    private Shark[] sharks; // 개체 넣어주기 
    private Part part;
    private short averageStr; // 평균 스트레스
    private short volume; // 용량
    private short waterQuality; //수질 (종에 알맞는 수질인지 아닌지)
}

public class Part
{
    private _Oxygen oxygen;
    private _WaterQuality waterQuality;
    private _Volume volume;
}

public struct _Oxygen
{
    short raiting; //등급s
}

public struct _WaterQuality
{
    short raiting; // 등급
}

public struct _Volume
{
    short size; // 크기
}