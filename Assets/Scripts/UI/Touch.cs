using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField]
    private Vector2 startposition;
    [SerializeField]
    private Vector2 endposition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startposition = Input.mousePosition;
            endposition = Vector2.zero;
        }
        if (Input.GetMouseButtonUp(0))
        {
            startposition = Vector2.zero;
            endposition = Input.mousePosition;
        }
    }
}
