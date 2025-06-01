using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс описывает упрвление пружиной, запускающей мяч в игру.
/// </summary>
public class StartingSpringControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float springForce;         // Сила, с которой пружина бьет по шарику

    private Rigidbody rbGO;                             // Объект Rigidbody пружины

    void Start()
    {
        // Присвоить ссылку на Rigidbody пружины
        rbGO = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // Если нажата клавиша "Пробел"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Приложить к пружине силу, обратную направлению оси Z (толкнуть пружину назад)
            rbGO.AddForce(transform.forward * (-1) * springForce, ForceMode.Impulse);
        }
    }
}
