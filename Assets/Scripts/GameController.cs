using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    private GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private AudioSource audioSource;

    //**UI TEXT
    public Text scoreText;
    public Text coinsText;
    public Text gameOverText;

    //**COUNTS
    public int score;
    public int coins;

    //**GAME EVENTS
    private bool restart;
    private bool gameOver;

    //**FILE
    private string fileName;
    FileInfo file; 
    void Start()
    {
        hazard = hazards[UnityEngine.Random.Range(0,hazards.Length)];
        file  = new FileInfo(Application.dataPath + "\\" + "myFile.txt");
       
        Load();

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
            hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Instantiate(hazard, spawnPosition, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                //SaveToFile();
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
        gameOver = true;
        Save();
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
    
    void Save()
    {
        try
        {
            StreamWriter writer;
            if (!file.Exists)
            {
                writer = file.CreateText();
            }
            else
            {
                file.Delete();
                writer = file.CreateText();
            }
            writer.WriteLine(coins.ToString());
            writer.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

    void Load()
    {
        try
        {
            if (file.Exists)
            {
                StreamReader reader = File.OpenText(Application.dataPath + "\\" + "myFile.txt");
                string coinCount = reader.ReadLine();
                coins = Int32.Parse(coinCount);
                reader.Close();
            }
            else
            {
                coins = 0;
                Save();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
