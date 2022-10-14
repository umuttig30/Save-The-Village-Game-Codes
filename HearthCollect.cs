using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        AudioManager.instance.Play("HeartCollect");

        FindObjectOfType<GameManager>().AddHeart();

         Destroy(gameObject);
    }
}
