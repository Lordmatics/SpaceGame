using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text pointsToSpendText;
    public int pointsToSpend;

    [Header("Move Speed Purchases == 20")]
    [Space]

    public Text moveSpeedStatText;
    public Text moveSpeedCostText;
    public int moveSpeedCost = 100;
    public float moveSpeedIncrement = 0.5f;
    public float maxMoveSpeed = 15.0f;
    public Text buttonTextMS;

    [Header("Fire Rate Purchases == 7")]
    [Space]

    public Text fireRateStatText;
    public Text fireRateCostText;
    public int fireRateCost = 500;
    public float fireRateIncrement = 0.05f;
    public float maxFireRate = 0.15f;
    public Text buttonTextFR;

    [Header("Ship Power Purchases == 9")]
    [Space]

    public Text shipPowerStatText;
    public Text shipPowerCostText;
    public int shipPowerCost = 1000;
    public int shipPowerIncrement = 1;
    public int maxPower = 10;
    public Text buttonTextSP;

    [Header("Ship Cannon Purchases == 2")]
    [Space]

    public Text shipCannonStatText;
    public Text shipCannonCostText;
    public int shipCannonCost = 10000;
    public int shipCannonIncrement = 1;
    public int maxCannonTier = 3;
    public Text buttonTextCT;

    [Space]

    public PlayerTurret playerTurret;
    public PlayerMovement playerMovement;

    public static ShopController instance;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Playerprefs points;
    }

    void OnEnable()
    {
        CheckBuyButtons();

        UpdateMoveSpeed();
        UpdateFireRate();
        UpdateStrength();
        UpdateShipTier();
        UpdatePoints();
    }

    void CheckButtonMS()
    {
        if (playerMovement.playerData.speed >= maxMoveSpeed)
        {
            buttonTextMS.text = "MAX";
        }
        else
        {
            buttonTextMS.text = "Buy";
        }
    }

    void CheckButtonFR()
    {
        if (playerTurret.GetTurretData().fireRate <= maxFireRate)
        {
            buttonTextFR.text = "MAX";
        }
        else
        {
            buttonTextFR.text = "Buy";
        }
    }

    void CheckButtonSP()
    {
        if (playerTurret.GetTurretData().power >= maxPower)
        {
            buttonTextSP.text = "MAX";
        }
        else
        {
            buttonTextSP.text = "Buy";
        }
    }

    void CheckButtonCT()
    {
        if (playerTurret.GetTurretData().cannonTier >= maxCannonTier)
        {
            buttonTextCT.text = "MAX";
        }
        else
        {
            buttonTextCT.text = "Buy";
        }
    }

    void CheckBuyButtons()
    {
        CheckButtonMS();
        CheckButtonFR();
        CheckButtonSP();
        CheckButtonCT();
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        GameController.instance.RestartScene();
    }

    public void GainPoints(int amount)
    {
        pointsToSpend += amount;
        UpdatePoints();
    }

    void UpdatePoints()
    {
        pointsToSpendText.text = "Points to Spend : " + pointsToSpend.ToString();
    }

    bool SpendPoints(int cost)
    {
        if (cost <= pointsToSpend)
        {
            pointsToSpend -= cost;
            UpdatePoints();
            return true;
        }
        else return false;
    }

    void UpdateMoveSpeed()
    {
        moveSpeedStatText.text = "MoveSpeed : " + playerMovement.playerData.speed.ToString();
        moveSpeedCostText.text = "Cost : " + moveSpeedCost.ToString();
    }

    // 20
    public void UpgradeMoveSpeed()
    {
        float curMS = playerMovement.playerData.speed;

        if(SpendPoints(moveSpeedCost) && curMS < maxMoveSpeed)
        {
            playerMovement.playerData.speed += moveSpeedIncrement;
            moveSpeedCost *= 2;
            UpdateMoveSpeed();
            CheckButtonMS();
        }
    }

    void UpdateFireRate()
    {
        fireRateStatText.text = "FireRate : " + playerTurret.GetTurretData().fireRate.ToString();
        fireRateCostText.text = "Cost : " + fireRateCost.ToString();
    }

    // 7
    public void UpgradeFireRate()
    {
        float curFR = playerTurret.GetTurretData().fireRate;

        if (SpendPoints(fireRateCost) && curFR > maxFireRate)
        {
            float newFireRate = playerTurret.GetTurretData().fireRate - fireRateIncrement;
            playerTurret.SetFireRate(newFireRate);
            fireRateCost *= 3;
            UpdateFireRate();
            CheckButtonFR();
        }
    }

    void UpdateStrength()
    {
        shipPowerStatText.text = "Power : " + playerTurret.GetTurretData().power.ToString();
        shipPowerCostText.text = "Cost : " + shipPowerCost.ToString();
    }

    // 9
    public void UpgradeStrength()
    {
        int curPow = playerTurret.GetTurretData().power;

        if (SpendPoints(shipPowerCost) && curPow < maxPower)
        {
            int newStrength = playerTurret.GetTurretData().power + shipPowerIncrement;
            playerTurret.SetPower(newStrength);
            shipPowerCost *= 5;
            UpdateStrength();
            CheckButtonSP();
        }
    }

    void UpdateShipTier()
    {
        shipCannonStatText.text = "Cannon Tier : " + playerTurret.GetTurretData().cannonTier;
        shipCannonCostText.text = "Cost : " + shipCannonCost.ToString();
    }

    // 2
    public void UpgradeShipCannon()
    {
        int curTier = playerTurret.GetTurretData().cannonTier;

        if (SpendPoints(shipCannonCost) && curTier < maxCannonTier)
        {
            int newTier = playerTurret.GetTurretData().cannonTier + shipCannonIncrement;
            playerTurret.SetCannonTier(newTier);
            shipCannonCost *= 10;
            UpdateShipTier();
            CheckButtonCT();
        }
    }

}
