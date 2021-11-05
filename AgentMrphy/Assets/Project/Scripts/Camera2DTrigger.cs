using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DTrigger : MonoBehaviour
{
	Collider2D bounds;

	void Awake()
    {
		bounds = GetComponent<Collider2D>();
	}
	List<int> i;
	void OnTriggerEnter2D(Collider2D other)
	{
		Camera2D.CalculateBounds(bounds);
    }

}

