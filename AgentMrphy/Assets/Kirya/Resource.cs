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
            GetComponent<AudioSource>().Play();
            StartCoroutine(WaitBeforeDestroy());
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        playerStats.PlusOneBullet();
    }
}
