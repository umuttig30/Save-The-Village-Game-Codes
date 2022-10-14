using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        HandleMeleeAttack();
    }

    private void HandleMeleeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MeleeAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            MeleeAttack2();
        }
    }

    private void MeleeAttack()
    {
        GetComponent<Animator>().SetTrigger("Attacking1");
    }

    private void MeleeAttack2()
    {
        GetComponent<Animator>().SetTrigger("Attacking2");
    }
}
