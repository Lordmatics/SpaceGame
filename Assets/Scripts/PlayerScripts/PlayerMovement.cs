using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameBoundaries
{
    public float minX, maxX, minZ, maxZ;

    public GameBoundaries(float xMin = -6.0f, float xMax = 6.0f, float zMin = -4.0f, float zMax = 8.0f)
    {
        minX = xMin;
        maxX = xMax;
        minZ = zMin;
        maxZ = zMax;
    }
}

[System.Serializable]
public struct PlayerMovementData
{
    public float speed, tilt;

    public PlayerMovementData(float spd = 12.5f, float tlt = 4.0f)
    {
        speed = spd;
        tilt = tlt;
    }
}

[AddComponentMenu("Scripts/PlayerScripts/PlayerMovement")]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour , IContactDestroyable
{

    // Game Components
    private Rigidbody playerRB;

    // floats
    public float explosionVolume = 1.0f;
    
    // Custom Data Structures

    public PlayerMovementData playerData = new PlayerMovementData();

    public GameBoundaries boundaries = new GameBoundaries();

    private Quaternion calibrationQuaternion;

    public AndroidTouchPad touchPad;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        touchPad = GameObject.FindObjectOfType<AndroidTouchPad>();
#if UNITY_ANDROID
        CalibrateAccelerometer();
#endif
    }

    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }

    void FixedUpdate()
    {


#if UNITY_ANDROID
        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAcceleration(accelerationRaw);
        //Vector3 movementVector = new Vector3(acceleration.x, 0.0f, acceleration.y);

        Vector2 direction = touchPad.GetDirection();
        Vector3 movementVector = new Vector3(direction.x, 0.0f, direction.y);
#else
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontalMovement, 0.0f, verticalMovement);
#endif

        playerRB.velocity = movementVector * playerData.speed;
        playerRB.position = new Vector3
        (
            Mathf.Clamp(playerRB.position.x,boundaries.minX,boundaries.maxX),
            0.0f,
            Mathf.Clamp(playerRB.position.z, boundaries.minZ, boundaries.maxZ)
        );

        playerRB.rotation = Quaternion.Euler(0.0f, 0.0f, playerRB.velocity.x * -playerData.tilt); 
    }

    public void OnObjectHit(GameObject other)
    {
        Instantiate(Resources.Load(ParticleLibrary.playerExplosion), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
