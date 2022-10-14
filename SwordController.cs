using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //print("Osuma!");
            AudioManager.instance.Play("SwordHit");
            FindObjectOfType<GameManager>().HurtP2();
        }
    }
}
