using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TurretData
{
    public float offset, fireRate;
    public string prefabName;

    public TurretData(float offst = 1.25f, float fireRte = 0.25f, string nam = "PlayerBolt")
    {
        offset = offst;
        fireRate = fireRte;
        prefabName = nam;
    }
}

[AddComponentMenu("Scripts/PlayerScripts/PlayerTurret")]
[RequireComponent(typeof(AudioSource))]
public class PlayerTurret : MonoBehaviour
{

    // Gameobject Components

    private AudioSource playerAS;

    // floats
    public float turretVolume = 0.5f;

    // Custom Data Structures / Classes
    [SerializeField]
    private Timer shootingTimer = new Timer();

    [SerializeField]
    private TurretData turretData = new TurretData(1.25f, 0.25f, "PlayerBolt");

    void Start()
    {
        playerAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && shootingTimer.GetElapsedTime() > turretData.fireRate)
        {
            shootingTimer.ResetTimer();
            FireShot();
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
            //AudioClip clip = (AudioClip)Resources.Load(AudioLibrary.playerWeapon);
            //playerAS.PlayOneShot(clip, turretVolume);
        }
    }
}
