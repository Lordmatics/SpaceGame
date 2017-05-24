using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, ICanExceedBounds, IContactDestroyable
{

    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public GameBoundaries boundary;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;

    // Custom Data Structures
    public PlayerMovementData movementData = new PlayerMovementData();

    bool bIsDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = -transform.forward * movementData.speed;

        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.minZ, boundary.maxZ)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -movementData.tilt);
    }

    public void OnBoundsExit()
    {
        Value script = GetComponent<Value>();
        if (!GameController.instance.IsGameOver())
            ScoreController.instance.LoseScore(script.GetValue());

        Destroy(gameObject);
    }

    public void OnObjectHit(GameObject other)
    {
        //Destroy(other);
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        LaserBolt laser = other.GetComponent<LaserBolt>();

        if (player != null)
        {
            GameController.instance.GameOver();
            Instantiate(Resources.Load(ParticleLibrary.enemyExplosion), transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(laser != null)
        {
            if(laser.type == LaserBolt.FriendOrFoe.Friendly && !bIsDead)
            {
                bIsDead = true;
                Instantiate(Resources.Load(ParticleLibrary.enemyExplosion), transform.position, transform.rotation);
                // Done in laser class
                //Value script = GetComponent<Value>();
                //ExpController.instance.GainExperience(script.ExpValue);
                Destroy(gameObject);
            }
        }

    }
}
