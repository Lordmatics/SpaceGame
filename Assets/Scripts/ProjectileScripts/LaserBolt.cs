using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ProjectileScripts/LaserBolt")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(DestroyByContact))]
public class LaserBolt : MonoBehaviour , ICanExceedBounds, IContactDestroyable
{

    // Gameobject Components
    private Rigidbody laserRB;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    void Start()
    {
        laserRB = GetComponent<Rigidbody>();

        laserRB.velocity = transform.forward * movementData.speed;
    }

    public void OnBoundsExit()
    {
        // Replace with pooling
        Destroy(this.gameObject);
    }

    public void OnObjectHit(GameObject other)
    {
        //Destroy(other);
        Value script = other.GetComponent<Value>();
        if(script != null)
        {
            ScoreController.instance.GainScore(script.GetValue());
        }
        // Maybe add durability script and make tankier obstacles

        Destroy(gameObject);
    }
}
