using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{

    [SerializeField]
    private int scoreValue = 1;

    [SerializeField]
    private int expValue = 1;

    public int GetValue()
    {
        return scoreValue;
    }

    public int GetEXPWorth()
    {
        return expValue;
    }

    public void SetEXPWorth(int newWorth)
    {
        expValue = newWorth;
    }

    public void BindToTime()
    {
        Durability health = GetComponent<Durability>();

        float val = TimeController.instance.customSeconds / TimeController.instance.refreshRate;
        int flooredVal = Mathf.FloorToInt(val);

        int modifier = flooredVal * 4;

        expValue += modifier;
        if(health != null)
        {
            health.hitPoints += flooredVal;
        }
    }

}
