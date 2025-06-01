using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ��������� ��������� ��������, ����������� ��� � ����.
/// </summary>
public class StartingSpringControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float springForce;         // ����, � ������� ������� ���� �� ������

    private Rigidbody rbGO;                             // ������ Rigidbody �������

    void Start()
    {
        // ��������� ������ �� Rigidbody �������
        rbGO = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // ���� ������ ������� "������"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��������� � ������� ����, �������� ����������� ��� Z (�������� ������� �����)
            rbGO.AddForce(transform.forward * (-1) * springForce, ForceMode.Impulse);
        }
    }
}
