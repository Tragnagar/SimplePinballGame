using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ������������ �������, � ������� �������� ���.
/// </summary>
public class EndTriggerControl : MonoBehaviour
{
    public static EndTriggerControl S;              // ������-��������

    [Header("Set Dynamically")]
    public bool onTrig = false;                     // ������ ����� ���� � �������
    
    void Start()
    {
        S = this;
    }


    private void OnTriggerEnter(Collider coll)
    {
        // �� ����� � ������� ������ - true
        if (coll.gameObject.tag == "Ball") onTrig = true;
    }

    private void OnTriggerExit(Collider coll)
    {
        // �� ������ �� �������� ������ - false
        if (coll.gameObject.tag == "Ball") onTrig = false;
    }
}
