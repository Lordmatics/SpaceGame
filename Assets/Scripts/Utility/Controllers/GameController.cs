﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues = new Vector3(6.0f, 0.0f, 15.0f);

    // floats
    public float initialDelay = 1.0f;
    public float spawnDelay = 0.5f;
    public float waveDelay = 4.0f;


    // ints
    public int enemiesPerWave = 10;

    // bools
    private bool bGameOver = false;
    private bool bRestart = false;

    // Texts
    //public Text restartText;
    public Text gameoverText;

    public Button quitGameButton;
    public Button restartButton;

    public Button startGameButton;

    public Text levelText;
    public Text timeText;

    public Canvas shopCanvas;

    public static GameController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //restartText.text = "";
        gameoverText.text = "";

        restartButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(false);

        startGameButton.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        shopCanvas.enabled = false;

        ExpController.instance.UpdateLevel();
    }

    public void StartGame()
    {
        StartCoroutine(SpawnWaves());

        startGameButton.gameObject.SetActive(false);
        if(inputField != null)
            inputField.gameObject.SetActive(false);
    }

    void Update()
    {
        if(bRestart)
        {
            restartButton.gameObject.SetActive(true);
            quitGameButton.gameObject.SetActive(true);

#if UNITY_ANDROID
            //restartButton.gameObject.SetActive(true);
#else
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                RestartScene();
            }
#endif

        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion();
                GameObject GO = (GameObject)Instantiate(Resources.Load(EnemyLibrary.GetRandomAsteroid()), spawnPos, spawnRotation);
                if(GO != null)
                {
                    Value script = GO.GetComponent<Value>();
                    if(script != null)
                    {
                        script.BindToTime();
                    }
                }
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);

            if(bGameOver)
            {
#if UNITY_ANDROID
#else
                //restartText.text = "Press 'r' for Restart";
#endif
                bRestart = true;
                break;
            }
        }
    }

    public bool IsGameOver()
    {
        return bGameOver;
    }

    public void GameOver()
    {
        gameoverText.text = "Game Over!";
        bGameOver = true;
        shopCanvas.enabled = true;
        int amountOfPoints = ExpController.instance.Experience;
        ShopController.instance.GainPoints(amountOfPoints);

        TimeController.instance.bTimerTicking = false;
    }

    public InputField inputField;
    public Text cheatCodeText;
    public string cheatString = "Lordmatics";
    public string maxSpeed = "Speed";
    public string maxFireRate = "FireRate";
    public string maxPower = "Power";
    public string maxCannon = "CannonTier";

    public void OnCheatCodeEnd()
    {
        if(cheatCodeText.text == cheatString)
        {
            Destroy(inputField.gameObject);
            ShopController.instance.MaxStats();
        }
        else if(cheatCodeText.text == maxSpeed)
        {
            Destroy(inputField.gameObject);
            ShopController.instance.MaxMoveSpeed();
        }
        else if (cheatCodeText.text == maxFireRate)
        {
            Destroy(inputField.gameObject);
            ShopController.instance.MaxFireRate();
        }
        else if (cheatCodeText.text == maxPower)
        {
            Destroy(inputField.gameObject);
            ShopController.instance.MaxPower();
        }
        else if (cheatCodeText.text == maxCannon)
        {
            Destroy(inputField.gameObject);
            ShopController.instance.MaxCannon();
        }
    }
}

