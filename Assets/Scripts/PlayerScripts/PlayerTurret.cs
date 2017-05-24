using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TurretData
{
    public float offset, fireRate, delay;

    public TurretData(float offst = 1.25f, float fireRte = 0.25f, float wait = 0.25f)
    {
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

    void FireShot()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0.0f, 0.0f, turretData.offset);
        //turretData.prefabName;
        GameObject bullet = (GameObject)Instantiate(Resources.Load(WeaponLibrary.laserBolt), spawnPosition, Quaternion.identity);
        if (playerAS != null)
        {
            playerAS.Play();
        }
    }
}
