using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum Resources
    {
        Tape
    };

    [SerializeField] Resources resourceType;
    [SerializeField] string playerTag = "Player";
    [SerializeField] Stats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            Destroy(gameObject);
            playerStats.PlusOneBullet();
        }
    }
}
