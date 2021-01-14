using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Shark
{
    private string name; // 이름
    private short hunger; // 배고픔
    private short curSize; // 현재 크기 - > 산소량, 먹이 등 비례한다
    private short stress; // 스트레스
}
