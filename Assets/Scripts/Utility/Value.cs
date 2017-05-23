using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{

    [SerializeField]
    private int scoreValue = 1;

    public int GetValue()
    {
        return scoreValue;
    }
}
