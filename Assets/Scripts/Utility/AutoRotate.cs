using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Utility/AutoRotate")]
[RequireComponent(typeof(Rigidbody))]
public class AutoRotate : MonoBehaviour
{

    private Rigidbody RB;

    public float rotation = 5.0f;

	void Start ()
    {
        ApplyRotation();
        RB.angularVelocity = Random.insideUnitSphere * rotation;
    }

    public void ApplyRotation()
    {
        RB = GetComponent<Rigidbody>();
        RB.angularDrag = 0.0f;
        RB.useGravity = false;
    }
	
}
