using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagAttack : MonoBehaviour
{
    public bool isPlayerInTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = true;
            GetComponentInParent<EnemyController>().CloseAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }
}
