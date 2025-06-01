using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ��������� �������� SpringTube
/// </summary>
public class SpringTubeControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject tubeHead;                               // �������� ����
    [SerializeField] private float force;                                       // �������� ����

    // ����� ����������� ��� ������������ ���� � ���������� �����
    public void OnCollisionEnter(Collision coll)
    {
        GameObject cGO = coll.gameObject;

        if (cGO.tag == "Ball")
        {
            tubeHead.transform.localPosition = new Vector3(0, -0.09f, 0);
            //Main.S.UpdatePlayerScore()
        }
    }

    // ����� ����������� ��� ����������� ������������ ���� � ���������� ����
    public void OnCollisionExit(Collision coll)
    {
        GameObject cGO = coll.gameObject;

        if (cGO.tag == "Ball")
        {
            tubeHead.transform.localPosition = new Vector3(0, 0, 0);
            coll.rigidbody.AddForce(transform.position * (-1) * force, ForceMode.Impulse);
        }
    }
}
