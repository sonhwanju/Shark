using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private InterfaceManager interfaceManager;
    void Start()
    {
        interfaceManager = new InterfaceManager();
    }
}
