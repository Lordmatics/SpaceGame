using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TurretData
{

    public int power, cannonTier;

    public float offset, fireRate, delay;

    // Power 1 -> infinity
    // Fire Rate range (0.5 -> 0.15)
    // Cannon Tier - 1 -> 3
    public TurretData(float offst = 1.25f, float fireRte = 0.5f, float wait = 0.25f)
    {
        power = 1;
        cannonTier = 1;
        offset = offst;
        fireRate = fireRte;
        delay = wait;
    }
}

[AddComponentMenu("Scripts/PlayerScripts/PlayerTurret")]
[RequireComponent(typeof(AudioSource))]
public class PlayerTurret : MonoBehaviour
{

    // Gameobject Components

    private AudioSource playerAS;

    // floats
    public float turretVolume = 0.05f;

    // Custom Data Structures / Classes
    [SerializeField]
    private Timer shootingTimer = new Timer();

    [SerializeField]
    private TurretData turretData = new TurretData(1.25f, 0.25f);

    public AndroidFireZone fireZone;

    void Start()
    {
        playerAS = GetComponent<AudioSource>();
        playerAS.volume = turretVolume;

        fireZone = GameObject.FindObjectOfType<AndroidFireZone>();
    }

    void Update()
    {
        if (shootingTimer.GetElapsedTime() > turretData.fireRate)
        {
#if UNITY_ANDROID
            if(fireZone.CanFire())
            {
                shootingTimer.ResetTimer();
                FireShot();
            }
#else
            if(Input.GetButton("Fire1"))
            {
                shootingTimer.ResetTimer();
                FireShot();
            }
#endif

        }
    }

    public TurretData GetTurretData()
    {
        return turretData;
    }

    public void SetFireRate(float newFireRate)
    {
        turretData.fireRate = newFireRate;
    }

    public void SetPower(int newPower)
    {
        turretData.power = newPower;
    }

    public void SetCannonTier(int newTier)
    {
        turretData.cannonTier = newTier;
    }

    void FireShot()
    {
        if (turretData.cannonTier > 3) turretData.cannonTier = 3;
        switch(turretData.cannonTier)
        {
            // Single Shot
            case 1:
                Vector3 spawnPosition = transform.position + new Vector3(0.0f, 0.0f, turretData.offset);
                GameObject bullet = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPosition, Quaternion.identity);
                break;
                // Double Shot
            case 2:
                Vector3 spawnPositionL = transform.position + new Vector3(-0.15f, 0.0f, turretData.offset);
                Vector3 spawnPositionR = transform.position + new Vector3(0.15f, 0.0f, turretData.offset - 0.05f);
                GameObject bulletL = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionL, Quaternion.identity);
                GameObject bulletR = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionR, Quaternion.identity);
                break;
                // Angle Shot
            case 3:
                // Middle Barrage
                Vector3 spawnPositionL1 = transform.position + new Vector3(-0.15f, 0.0f, turretData.offset);
                Vector3 spawnPositionR1 = transform.position + new Vector3(0.15f, 0.0f, turretData.offset);// - 0.05f);
                GameObject bulletL1 = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionL1, Quaternion.identity);
                GameObject bulletR1 = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionR1, Quaternion.identity);

                // Angled shots
                Vector3 spawnPositionL2 = transform.position + new Vector3(-0.7f, 0.0f, 1.45f);
                Vector3 spawnPositionR2 = transform.position + new Vector3(0.55f, 0.0f, 1.45f);
                Vector3 spawnRotL2 = new Vector3(0.0f, -15.0f, 0.0f);
                Vector3 spawnRotR2 = new Vector3(0.0f, 15.0f, 0.0f);
                GameObject bulletL2 = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionL2, Quaternion.identity);
                if (bulletL2 != null) bulletL2.transform.localEulerAngles = spawnRotL2;
                GameObject bulletR2 = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionR2, Quaternion.identity);
                if (bulletR2 != null) bulletR2.transform.localEulerAngles = spawnRotR2;

                break;
            default:
                Vector3 spawnPositionDef = transform.position + new Vector3(0.0f, 0.0f, turretData.offset);
                GameObject bulletDef = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPositionDef, Quaternion.identity);
                break;
        }

        if (playerAS != null)
        {
            playerAS.Play();
        }
    }
}
