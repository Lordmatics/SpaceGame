using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ObstacleScripts/Asteroid")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AutoRotate))]
[RequireComponent(typeof(DestroyByContact))]
[RequireComponent(typeof(Value))]
public class Asteroid : MonoBehaviour, ICanExceedBounds, IContactDestroyable
{

    // Gameobject Components
    private Rigidbody asteroidRB;

    // floats
    public float explosionVolume = 1.0f;

    // ints
    public int asteroidValue = 10;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    void Start()
    {
        asteroidRB = GetComponent<Rigidbody>();

        asteroidRB.velocity = -transform.forward * movementData.speed;
    }

    public void OnBoundsExit()
    {
        Value script = GetComponent<Value>();
        if(!GameController.instance.IsGameOver())
            ScoreController.instance.LoseScore(script.GetValue());

        Destroy(gameObject);
    }

    public void OnObjectHit(GameObject other)
    {
        //Destroy(other);
        Instantiate(Resources.Load(ParticleLibrary.asteroidExplosion), transform.position, transform.rotation);
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null)
        {
            GameController.instance.GameOver();
            
        }
        Destroy(gameObject);
    }

}
