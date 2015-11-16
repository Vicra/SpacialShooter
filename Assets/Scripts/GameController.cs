using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private AudioSource audioSource;

    public Text scoreText;
    public Text coinsText;
    public Text gameOverText;

    public int score;
    public int coins;

    private bool restart;
    private bool gameOver;
    private string fileName;
    void Start()
    {

        fileName = "coinCount.txt";
        LoadFromFile();
        gameOverText.text = "";
        gameOver = false;
        restart = true;
        StartCoroutine(SpawnWaves());
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        score = 0;
        UpdateData();
    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Instantiate(hazard, spawnPosition, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                SaveToFile();
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateData();
    }
    public void AddCoins(int newCoins)
    {
        coins += newCoins;
        UpdateData();
    }
    void UpdateData()
    {
        scoreText.text = "Score: " + score;
        coinsText.text = "Coins: " + coins;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    void SaveToFile()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/"+fileName,true);
        sw.Write(coins.ToString());
        sw.Close();
    }
    void LoadFromFile()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/" + fileName, true);
        coins = Int32.Parse(sr.ReadLine()) ;
        sr.Close();
    }
}
