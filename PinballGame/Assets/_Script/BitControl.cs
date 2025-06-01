using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт отвечает за управление двумя битами на игровом столе.
/// </summary>
public class BitControl : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float targetVel;               // Скорость, которую должен достичь бит
    [SerializeField] private float targetForce;             // Сила, под действием которой бит будет двигаться

    private HingeJoint hj;                                  // Компонент HinjeJoint игрового объекта
    private JointMotor m;                                   // Свойство Motor компонента HinjeJoint

    void Start()
    {
        // Объявление переменных hj и m
        hj = GetComponent<HingeJoint>();
        m = hj.motor;

        // Установка силы, с которой будет вращаться бит
        m.force = targetForce;
        hj.motor = m;
    }

    void Update()
    {
        // Выбор бита ("LeftBit" или "RightBit")
        switch (gameObject.tag)
        {
            case "LeftBit":
                // Если нажата клавиша "А", то включить мотор у левого бита и установить скорость
                if (Input.GetKeyDown(KeyCode.A))
                {
                    m.targetVelocity = targetVel;
                    hj.motor = m;
                    hj.useMotor = true;
                }

                // Если отжата клавиша "А", то инвертировать скорость для возврата левого бита 
                // в исходное положение
                if (Input.GetKeyUp(KeyCode.A))
                {
                    m.targetVelocity = -targetVel;
                    hj.motor = m;
                }
                break;

            case "RightBit":
                // Если нажата клавиша "D", то включить мотор у правого бита и установить скорость
                if (Input.GetKeyDown(KeyCode.D))
                {
                    m.targetVelocity = -targetVel;
                    hj.motor = m;
                    hj.useMotor = true;
                }

                // Если отжата клавиша "D", то инвертировать скорость для возврата правого бита 
                // в исходное положение
                if (Input.GetKeyUp(KeyCode.D))
                {
                    m.targetVelocity = targetVel;
                    hj.motor = m;
                }
                break;
        }
    }
}
