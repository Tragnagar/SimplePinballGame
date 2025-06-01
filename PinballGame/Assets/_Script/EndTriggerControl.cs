using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс контролирует триггер, в который попадает мяч.
/// </summary>
public class EndTriggerControl : MonoBehaviour
{
    public static EndTriggerControl S;              // Объект-одиночка

    [Header("Set Dynamically")]
    public bool onTrig = false;                     // Маркер входа мяча в триггер
    
    void Start()
    {
        S = this;
    }


    private void OnTriggerEnter(Collider coll)
    {
        // На входе в триггер маркер - true
        if (coll.gameObject.tag == "Ball") onTrig = true;
    }

    private void OnTriggerExit(Collider coll)
    {
        // На выходе из триггера маркер - false
        if (coll.gameObject.tag == "Ball") onTrig = false;
    }
}
