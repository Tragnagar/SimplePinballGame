using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс управляет ротором, активируя его, когда он соприкасается с шаром и деактивируя его,
/// когда шар перестает касаться частей ротора.
/// </summary>

public class RotorControl : MonoBehaviour {
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            HingeJoint goHJ = GetComponent<HingeJoint>();
            goHJ.useMotor = true;
        }
    }

    public void OnCollisionExit(Collision coll)
    {
        HingeJoint goHJ = GetComponent<HingeJoint>();
        goHJ.useMotor = false;
    }
}
