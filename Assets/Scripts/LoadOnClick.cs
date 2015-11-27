using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour
{
    public GameObject loadingImage;
    private GameController gameController;
    private PlayerController playerController;
    int coins;
    int doubleShotCost = 20;
    int tripleShotCost = 1000;
    int cuadShotCost = 2000;
    FileInfo file;
    FileInfo shotFile;
    private string fileName;
    public Text purchasedText;
    public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        Application.LoadLevel(level);   
    }
    void Start()
    {
        fileName = "shoot";
        file = new FileInfo(Application.dataPath + "\\" + "myFile.txt");
        shotFile = new FileInfo(Application.dataPath + "\\" + fileName+".txt");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null && playerControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            playerController = playerControllerObject.GetComponent<PlayerController>();

        }
        

        //necesito el game y player controller
        //por las coins y save file
    }
    public void PurchaseUpgrade(int shots)
    {
        Load();
        if (shots == 2 && coins >= doubleShotCost)
        {
            coins -= doubleShotCost;
            SaveShot(2);
            purchasedText.text = "Successfully purchased double shots";
        }
        else if (shots == 3 && coins >= tripleShotCost)
        {
            coins -= tripleShotCost;
            SaveShot(3);
            purchasedText.text = "Successfully purchased triple shots";
        }
        else if (shots == 4 && coins >= cuadShotCost)
        {
            coins -= cuadShotCost;
            SaveShot(4);
            purchasedText.text = "Successfully purchased cuad shots";
        }
        Save();
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
    public void SaveShot(int newFireType)
    {
        try
        {
            StreamWriter writer;
            if (!shotFile.Exists)
            {
                writer = shotFile.CreateText();
            }
            else
            {
                shotFile.Delete();
                writer = shotFile.CreateText();
            }
            writer.WriteLine(newFireType.ToString());
            writer.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
}