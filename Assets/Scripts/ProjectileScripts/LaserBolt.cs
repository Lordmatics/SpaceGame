using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/ProjectileScripts/LaserBolt")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(DestroyByContact))]
public class LaserBolt : MonoBehaviour , ICanExceedBounds, IContactDestroyable
{
    public enum FriendOrFoe
    {
        Friendly,
        Foe
    }

    public FriendOrFoe type;

    // Gameobject Components
    private Rigidbody laserRB;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    public int powerLevel = 1;

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
        // Shot by Enemy
        if(type == FriendOrFoe.Foe)
        {
            //Only Destroy 
            // - Out of Bounds
            // - Hits Player
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                GameController.instance.GameOver();
                Destroy(gameObject);
            }
        }
        // Shot by Player
        else
        {
            // Destroy on impact - Except on Bullets
            Value script = other.GetComponent<Value>();
            if (script != null)
            {
                ScoreController.instance.GainScore(script.GetValue());
                ExpController.instance.GainExperience(script.GetEXPWorth());
            }
            Destroy(gameObject);

        }

        // Maybe add durability script and make tankier obstacles

    }
}
