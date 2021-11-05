using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TurnPoint : MonoBehaviour
{
    [SerializeField] bool isBlocker;
    private GameObject blocker;

    private void Awake()
    {
        blocker = GetComponentInChildren<Rigidbody2D>().gameObject;
    }
    private void Start()
    {
        if (isBlocker)
            blocker.SetActive(true);
        else
            blocker.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() != null)
            collision.GetComponent<EnemyController>().HandleTurnPointEnter();
    }
}
