using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    public static ExpController instance;

    public List<int> expRequirements = new List<int>(100);

    [SerializeField]
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

    public int level;

    void Awake()
    {
        instance = this;
    }

    public int LevelCheck(int xp)
    {
        for (int i = expRequirements.Count - 1; i >= 0; i--)
        {
            if(xp > expRequirements[i])
            {
                return i + 1;
            }
        }
        return 1;
    }

    public void GainExperience(int amount)
    {
        experience = experience + amount;
        experience = Mathf.Clamp(experience, 0, 5000000);
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        level = LevelCheck(experience);
        GameController.instance.levelText.text = "Level : " + level.ToString();
    }
}
