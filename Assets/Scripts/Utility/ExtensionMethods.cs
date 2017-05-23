using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static string playerExplosion = "Explosion_Player";
    public static string asteroidExplosion = "Explosion_Asteroid";
    public static string enemyExplosion = "Explosion_Enemy";

    public static string player = "PlayerShip";
    public static string laserBolt = "PlayerBolt";
    public static string asteroid_01 = "Asteroid_01";
    public static string asteroid_02 = "Asteroid_02";
    public static string asteroid_03 = "Asteroid_03";

    public static string GetRandomAsteroid()
    {
        int rand = Random.Range(1, 4);
        return "Asteroid_0" + rand.ToString();
    }

}
