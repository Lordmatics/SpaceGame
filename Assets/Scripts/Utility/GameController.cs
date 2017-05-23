using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues = new Vector3(6.0f, 0.0f, 15.0f);

    // floats
    public float initialDelay = 1.0f;
    public float spawnDelay = 0.5f;
    public float waveDelay = 4.0f;


    // ints
    public int enemiesPerWave = 10;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion();
                Instantiate(Resources.Load(EnemyLibrary.GetRandomAsteroid()), spawnPos, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);
        }
    }
}

