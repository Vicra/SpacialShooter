using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    
    public int score;
    public int coins;
    void Start()
    {
        

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
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Instantiate(hazard, spawnPosition, transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
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

}
