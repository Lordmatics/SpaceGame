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
public class PlayerTurret : MonoBehaviour
{

    // Gameobject Components

    // Custom Data Structures / Classes
    [SerializeField]
    private Timer shootingTimer = new Timer();

    [SerializeField]
    private TurretData turretData = new TurretData(1.25f, 0.25f, "PlayerBolt");

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
    }
}
