using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    public TurretData turretData;

    private AudioSource enemyAS;

    void Start()
    {
        enemyAS = GetComponent<AudioSource>();
        InvokeRepeating("Fire", turretData.delay, turretData.fireRate);
    }

    void Fire()
    {
        Vector3 spawnPosition = transform.position - new Vector3(0.0f, 0.0f, turretData.offset);
        //turretData.prefabName;
        GameObject bullet = (GameObject)Instantiate(Resources.Load(WeaponLibrary.enemyLaserBolt), spawnPosition, Quaternion.identity);
        if (enemyAS != null)
        {
            enemyAS.Play();
        }
    }
}
