using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{

    public float lifetime = 1.5f;

	void Start ()
    {
        Destroy(gameObject, lifetime);
	}
}
