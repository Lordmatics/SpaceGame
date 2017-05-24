using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public int hitPoints = 1;

    public bool bIsDead = false;

    public bool TakeDamage(int amount)
    {
        hitPoints -= amount;
        if(hitPoints <= 0)
        {
            bIsDead = true;
            return true;
        }
        return false;
    }
}
