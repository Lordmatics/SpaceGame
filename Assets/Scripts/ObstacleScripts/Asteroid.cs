using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ObstacleScripts/Asteroid")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AutoRotate))]
[RequireComponent(typeof(DestroyByContact))]
public class Asteroid : MonoBehaviour, ICanExceedBounds, IContactDestroyable
{

    // Gameobject Components
    private Rigidbody asteroidRB;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    void Start()
    {
        asteroidRB = GetComponent<Rigidbody>();

        asteroidRB.velocity = -transform.forward * movementData.speed;
    }

    public void OnBoundsExit()
    {
        Destroy(gameObject);
    }

    public void OnObjectHit(GameObject other)
    {
        //Destroy(other);
        Instantiate(Resources.Load("Explosions/" + ExtensionMethods.asteroidExplosion), transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
