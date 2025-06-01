using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ �������� �� ���������� ����� ������ �� ������� �����.
/// </summary>
public class BitControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float targetVel;               // ��������, ������� ������ ������� ���
    [SerializeField] private float targetForce;             // ����, ��� ��������� ������� ��� ����� ���������

    private HingeJoint hj;                                  // ��������� HinjeJoint �������� �������
    private JointMotor m;                                   // �������� Motor ���������� HinjeJoint

    void Start()
    {
        // ���������� ���������� hj � m
        hj = GetComponent<HingeJoint>();
        m = hj.motor;

        // ��������� ����, � ������� ����� ��������� ���
        m.force = targetForce;
        hj.motor = m;
    }

    void Update()
    {
        // ����� ���� ("LeftBit" ��� "RightBit")
        switch (gameObject.tag)
        {
            case "LeftBit":
                // ���� ������ ������� "�", �� �������� ����� � ������ ���� � ���������� ��������
                if (Input.GetKeyDown(KeyCode.A))
                {
                    m.targetVelocity = targetVel;
                    hj.motor = m;
                    hj.useMotor = true;
                }

                // ���� ������ ������� "�", �� ������������� �������� ��� �������� ������ ���� 
                // � �������� ���������
                if (Input.GetKeyUp(KeyCode.A))
                {
                    m.targetVelocity = -targetVel;
                    hj.motor = m;
                }
                break;

            case "RightBit":
                // ���� ������ ������� "D", �� �������� ����� � ������� ���� � ���������� ��������
                if (Input.GetKeyDown(KeyCode.D))
                {
                    m.targetVelocity = -targetVel;
                    hj.motor = m;
                    hj.useMotor = true;
                }

                // ���� ������ ������� "D", �� ������������� �������� ��� �������� ������� ���� 
                // � �������� ���������
                if (Input.GetKeyUp(KeyCode.D))
                {
                    m.targetVelocity = targetVel;
                    hj.motor = m;
                }
                break;
        }
    }
}
