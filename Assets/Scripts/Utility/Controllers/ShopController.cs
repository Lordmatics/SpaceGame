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
    public int costMultiplierMS;
    public float moveSpeedIncrement = 0.5f;
    public float maxMoveSpeed = 15.0f;
    public Text buttonTextMS;

    [Header("Fire Rate Purchases == 7")]
    [Space]

    public Text fireRateStatText;
    public Text fireRateCostText;
    public int fireRateCost = 500;
    public int costMultiplierFR;

    public float fireRateIncrement = 0.05f;
    public float maxFireRate = 0.15f;
    public Text buttonTextFR;

    [Header("Ship Power Purchases == 9")]
    [Space]

    public Text shipPowerStatText;
    public Text shipPowerCostText;
    public int shipPowerCost = 250;
    public int costMultiplierP;

    public int shipPowerIncrement = 1;
    public int maxPower = 10;
    public Text buttonTextSP;

    [Header("Ship Cannon Purchases == 2")]
    [Space]

    public Text shipCannonStatText;
    public Text shipCannonCostText;
    public int shipCannonCost = 10000;
    public int costMultiplierCT;

    public int shipCannonIncrement = 1;
    public int maxCannonTier = 3;
    public Text buttonTextCT;

    [Space]

    public PlayerTurret playerTurret;
    public PlayerMovement playerMovement;

    public static ShopController instance;

    public string PointsString = "SpendablePoints";
    public string MSString = "PlayerMoveSpeed";
    public string FRString = "PlayerFireRate";
    public string PString = "PlayerPower";
    public string CTString = "PlayerCannonTier";

    public string MSCostString = "PlayerMoveSpeedCost";
    public string FRCostString = "PlayerFireRateCost";
    public string PCostString = "PlayerPowerCost";
    public string CTCostString = "PlayerCannonTierCost";
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Playerprefs points;
    }

    // Option to max out if cheat code enterred
    public void MaxMoveSpeed()
    {
        playerMovement.playerData.speed = maxMoveSpeed;
        float loops = (maxMoveSpeed - 5.0f) / moveSpeedIncrement;
        moveSpeedCost = (int)loops * costMultiplierMS;
        SetPPMS();
        CheckBuyButtons();

    }
    public void MaxFireRate()
    {
        playerTurret.SetFireRate(maxFireRate);
        float loops = ((0.5f - maxFireRate) / fireRateIncrement) * 10;
        fireRateCost = (int)loops * costMultiplierFR;
        SetPPFR();
        CheckBuyButtons();

    }
    public void MaxPower()
    {
        playerTurret.SetPower(maxPower);
        float loops = (maxPower - 1) / shipPowerIncrement;
        shipPowerCost = (int)loops * costMultiplierP;
        SetPPP();
        CheckBuyButtons();

    }
    public void MaxCannon()
    {
        playerTurret.SetCannonTier(maxCannonTier);
        float loops = (maxCannonTier - 1) / shipCannonIncrement;
        shipCannonCost = (int)loops * costMultiplierCT;
        SetPPCT();
        CheckBuyButtons();

    }
    public void MaxStats()
    {
        MaxMoveSpeed();
        MaxFireRate();
        MaxPower();
        MaxCannon();
    }

    public void AssignDefaults()
    {
        moveSpeedCost = 25;
        costMultiplierMS = 2;
        moveSpeedIncrement = 0.5f;
        maxMoveSpeed = 15.0f;

        fireRateCost = 100;
        costMultiplierFR = 3;
        fireRateIncrement = 0.05f;
        maxFireRate = 0.15f;

        shipPowerCost = 250;
        costMultiplierP = 5;
        shipPowerIncrement = 1;
        maxPower = 10;

        shipCannonCost = 10000;
        costMultiplierCT = 10;
        shipCannonIncrement = 1;
        maxCannonTier = 3;
    }

    void OnEnable()
    {
        LoadPlayerPrefs();

        CheckBuyButtons();

        UpdateMoveSpeed();
        UpdateFireRate();
        UpdateStrength();
        UpdateShipTier();
        UpdatePoints();
    }

    void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(PointsString))
        {
            pointsToSpend = PlayerPrefs.GetInt(PointsString);
        }
        if (PlayerPrefs.HasKey(MSString))
        {
            playerMovement.playerData.speed = PlayerPrefs.GetFloat(MSString);
        }
        if (PlayerPrefs.HasKey(FRString))
        {
            playerTurret.SetFireRate(PlayerPrefs.GetFloat(FRString));
        }

        if (PlayerPrefs.HasKey(PString))
        {
            playerTurret.SetPower(PlayerPrefs.GetInt(PString));

        }
        if (PlayerPrefs.HasKey(CTString))
        {
            playerTurret.SetCannonTier(PlayerPrefs.GetInt(CTString));
        }

        if (PlayerPrefs.HasKey(MSCostString))
        {
            moveSpeedCost = PlayerPrefs.GetInt(MSCostString);
        }
        if (PlayerPrefs.HasKey(FRString))
        {
            fireRateCost = PlayerPrefs.GetInt(FRCostString);
        }

        if (PlayerPrefs.HasKey(PString))
        {
            shipPowerCost = PlayerPrefs.GetInt(PCostString);
        }
        if (PlayerPrefs.HasKey(CTString))
        {
            shipCannonCost = PlayerPrefs.GetInt(CTCostString);
        }
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
        PlayerPrefs.SetInt(PointsString, pointsToSpend);
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
        if (curMS < maxMoveSpeed)
        {
            if (SpendPoints(moveSpeedCost))
            {
                playerMovement.playerData.speed += moveSpeedIncrement;
                moveSpeedCost *= costMultiplierMS;
                UpdateMoveSpeed();
                CheckButtonMS();
            }
        }
        SetPPMS();
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
        if (curFR > maxFireRate)
        {
            if (SpendPoints(fireRateCost))
            {
                float newFireRate = playerTurret.GetTurretData().fireRate - fireRateIncrement;
                playerTurret.SetFireRate(newFireRate);
                fireRateCost *= costMultiplierFR;
                UpdateFireRate();
                CheckButtonFR();

            }
        }
        SetPPFR();
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
        if (curPow < maxPower)
        {
            if (SpendPoints(shipPowerCost))
            {
                int newStrength = playerTurret.GetTurretData().power + shipPowerIncrement;
                playerTurret.SetPower(newStrength);
                shipPowerCost *= costMultiplierP;
                UpdateStrength();
                CheckButtonSP();

            }
        }
        SetPPP();
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

        if (curTier < maxCannonTier)
        {
            if (SpendPoints(shipCannonCost))
            {
                int newTier = playerTurret.GetTurretData().cannonTier + shipCannonIncrement;
                playerTurret.SetCannonTier(newTier);
                shipCannonCost *= costMultiplierCT;
                UpdateShipTier();
                CheckButtonCT();

            }
        }

        SetPPCT();
    }

    void SetPPMS()
    {
        PlayerPrefs.SetInt(MSCostString, moveSpeedCost);
        PlayerPrefs.SetFloat(MSString, playerMovement.playerData.speed);
    }

    void SetPPFR()
    {
        PlayerPrefs.SetInt(FRCostString, fireRateCost);
        PlayerPrefs.SetFloat(FRString, playerTurret.GetTurretData().fireRate);
    }

    void SetPPP()
    {
        PlayerPrefs.SetInt(PCostString, shipPowerCost);
        PlayerPrefs.SetInt(PString, playerTurret.GetTurretData().power);
    }

    void SetPPCT()
    {
        PlayerPrefs.SetInt(CTCostString, shipCannonCost);
        PlayerPrefs.SetInt(CTString, playerTurret.GetTurretData().cannonTier);
    }
}
