using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyLibrary
{

    public static string asteroid_01 = "Obstacles/Asteroid_01";
    public static string asteroid_02 = "Obstacles/Asteroid_02";
    public static string asteroid_03 = "Obstacles/Asteroid_03";
    public static string asteroid_04 = "Obstacles/Asteroid_04"; // Enemy Ship
    public static string asteroid_05 = "Obstacles/Asteroid_05"; // Turbosquid Asteroid
    public static string asteroid_06 = "Obstacles/Asteroid_06"; // Turbosquid Fighter
    public static string asteroid_07 = "Obstacles/Asteroid_07"; // Turbosquid small suicide ship




    public static string GetRandomAsteroid()
    {
        int rand = Random.Range(1, 8);
        return "Obstacles/Asteroid_0" + rand.ToString();
    }
}
