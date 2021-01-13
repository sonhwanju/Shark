using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public InterfaceManager interfaceManager;

    Dictionary<string, _Shark> _shark;
    void Start()
    {
        interfaceManager = gameObject.GetComponent<InterfaceManager>();

        _shark = new Dictionary<string, _Shark>();
        string name;

        name = "귀상어"; //임의 값
        _shark.Add(name, new _Shark(name, 100000, 20, 5, 3, 10, 1, 100, 5)); // 임의 값

        /*if(_shark.ContainsKey("귀상어"))
        {
            _Shark __shark = _shark["귀상어"];
            __shark.Show();
        }*/

        foreach(KeyValuePair<string, _Shark> pair in _shark)
        {
            _Shark __shark = pair.Value;
            __shark.Show();
        }   
    }
}
