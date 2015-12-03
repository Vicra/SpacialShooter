using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class UpgradeController : MonoBehaviour {

	// Use this for initialization
    public Text coinsText;
    FileInfo file;
    private int coins;
	void Start () {
        file = new FileInfo(Application.dataPath + "\\" + "myFile.txt");
        //Load();
        if(PlayerPrefs.HasKey("Coins"))
            coins = PlayerPrefs.GetInt("Coins");
        else
        {
            coins = 0;
        }
        
        coinsText.text ="Coins: " + coins.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
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
