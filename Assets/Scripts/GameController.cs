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

    private ShotController shotController;

    private int first;
    private int second;
    private int third;

    //**FILE
    private string fileName;
    FileInfo file;
    void Start()
    {
        hazard = hazards[UnityEngine.Random.Range(0,hazards.Length)];
        file  = new FileInfo(Application.dataPath + "\\" + "myFile.txt");

        //Load();
        coins = PlayerPrefs.GetInt("Coins");

        gameOverText.text = "";
        gameOver = false;
        restart = false;
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
                Vector3 spawnPosition = 
                    new Vector3(spawnValues.x, UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Instantiate(hazard, spawnPosition, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            hazardCount++;
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
        Handheld.Vibrate(); 
        gameOver = true;
        PlayerPrefs.SetInt("Coins",coins);
        EnterScore(score);

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
    void LoadScores()
    {
        if (PlayerPrefs.HasKey("First"))
            first = PlayerPrefs.GetInt("First");
        if (PlayerPrefs.HasKey("Second"))
            second = PlayerPrefs.GetInt("Second");
        if (PlayerPrefs.HasKey("Third"))
            third = PlayerPrefs.GetInt("Third");
    }
    void SaveScore()
    {
        PlayerPrefs.SetInt("First", first);
        PlayerPrefs.SetInt("Second", second);
        PlayerPrefs.SetInt("Third", third);
    }
    public void EnterScore(int score)
    {
        LoadScores();
        if (score > first)
        {
            third = second;
            second = first;
            first = score;
        }
        else if (score > second)
        {
            third = second;
            second = score;
        }
        else if (score > third)
        {
            third = score;
        } 
        SaveScore();
    }
}
