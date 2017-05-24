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

        ExpController.instance.UpdateLevel();
    }

    public void StartGame()
    {
        StartCoroutine(SpawnWaves());

        startGameButton.gameObject.SetActive(false);

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
            if (Input.GetKeyDown(KeyCode.R))
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
        TimeController.instance.bTimerTicking = false;
    }
}

