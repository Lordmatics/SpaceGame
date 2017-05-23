using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyLibrary
{

    public static string asteroid_01 = "Obstacles/Asteroid_01";
    public static string asteroid_02 = "Obstacles/Asteroid_02";
    public static string asteroid_03 = "Obstacles/Asteroid_03";

    public static string GetRandomAsteroid()
    {
        int rand = Random.Range(1, 4);
        return "Obstacles/Asteroid_0" + rand.ToString();
    }
}
