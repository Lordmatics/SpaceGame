using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //public Dictionary<int, int> levelTable = new Dictionary<int, int>();

    public DictionaryIntInt test1 = new DictionaryIntInt();


    void Start()
    {
        for (int i = 0; i < test1.Count + 1; i++)
        {
            int val;
            test1.TryGetValue(i, out val);
            Debug.Log(val);

        }
    }
    private int experience;

    public int Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }

    public int level
    {
        get
        {
            return experience / 750;
        }
    }

    public void GainExperience()
    {

    }

    public void UpdateLevel()
    {
        GameController.instance.levelText.text = "Level : " + level.ToString();
    }

}
