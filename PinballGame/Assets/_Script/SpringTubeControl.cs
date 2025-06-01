using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс управляет объектом SpringTube
/// </summary>
public class SpringTubeControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject tubeHead;                               // Верхушка тубы
    [SerializeField] private float force;                                       // Значение силы

    // Метод срабатывает при столкновении шара с основанием трубы
    public void OnCollisionEnter(Collision coll)
    {
        GameObject cGO = coll.gameObject;

        if (cGO.tag == "Ball")
        {
            tubeHead.transform.localPosition = new Vector3(0, -0.09f, 0);
            //Main.S.UpdatePlayerScore()
        }
    }

    // Метод срабатывает при прекращении столкновения шара с основанием тубы
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
