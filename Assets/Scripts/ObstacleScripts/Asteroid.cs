using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ObstacleScripts/Asteroid")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AutoRotate))]
[RequireComponent(typeof(DestroyByContact))]
[RequireComponent(typeof(Value))]
[RequireComponent(typeof(Durability))]
public class Asteroid : MonoBehaviour, ICanExceedBounds, IContactDestroyable
{

    // Gameobject Components
    private Rigidbody asteroidRB;

    // floats
    public float explosionVolume = 1.0f;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    public Durability healthScript;

    void Start()
    {
        asteroidRB = GetComponent<Rigidbody>();

        healthScript = GetComponent<Durability>();

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
        // If Asteroid hits player
        // If Asteroid hits player laser
        PlayerTurret player = other.GetComponent<PlayerTurret>();
        LaserBolt laserBolt = other.GetComponent<LaserBolt>();

        if (player != null)
        {
            GameController.instance.GameOver();
            Instantiate(Resources.Load(ParticleLibrary.asteroidExplosion), transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(laserBolt != null)
        {
            if(laserBolt.type == LaserBolt.FriendOrFoe.Friendly && !healthScript.bIsDead)
            {
                if(healthScript.TakeDamage(player.GetTurretData().power))
                {
                    //Value script = GetComponent<Value>();
                    //ExpController.instance.GainExperience(script.ExpValue);
                    Instantiate(Resources.Load(ParticleLibrary.asteroidExplosion), transform.position, transform.rotation);
                    Destroy(gameObject);
                }
                else
                {
                    // Play Take damage sound
                }
            }
        }

    }

}
