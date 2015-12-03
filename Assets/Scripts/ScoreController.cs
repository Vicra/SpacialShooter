using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text firstScore;
    public Text secondScore;
    public Text thirdScore;

    private int first;
    private int second;
    private int third;

    void Start()
    {
        LoadScores();
        firstScore.text = first.ToString();
        secondScore.text = second.ToString();
        thirdScore.text = third.ToString();
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
}
