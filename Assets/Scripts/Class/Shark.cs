using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Shark
{
    public string name; // 이름
    public short hunger; // 배고픔
    public short curSize; // 현재 크기 - > 산소량, 먹이 등 비례한다
    public short time; // 현재 시간
    public short stress; // 스트레스

    public Shark(string name)
    {
        this.name = name;
    }
}
