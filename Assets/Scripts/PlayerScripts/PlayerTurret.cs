using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/PlayerScripts/PlayerTurret")]
public class PlayerTurret : MonoBehaviour
{

    // Gameobject Components

    // floats
    public float offset = 1.25f;
    public string prefabName = "PlayerBolt";

    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    FireShot();
        //}

        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireShot();
        }
    }

    void FireShot()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0.0f, 0.0f, offset);
        GameObject bullet = (GameObject)Instantiate(Resources.Load(prefabName), spawnPosition, Quaternion.identity);
    }
}
