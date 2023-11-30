using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinData
{
    public int Coin;
    public bool StartGame;
}


public class CasinoGameManager : Singleton<CasinoGameManager>
{
    public CoinData _coinData = new CoinData();
    private string path, filename = "CoinData";
    public int Coin { get => _coinData.Coin; set => _coinData.Coin = value; }


    protected override void Awake()
    {
        base.Awake();
        path = Application.persistentDataPath + "/";
        Debug.Log(path);
        LoadData();


        if (_coinData.StartGame == false)
        {
            _coinData.Coin = 500;
            _coinData.StartGame = true;
        }
       
        SaveData();
    }
    public void SaveData()
    {
        Debug.Log("ภ๚ภๅตส");
        string data = JsonUtility.ToJson(_coinData);
        File.WriteAllText(path + filename, data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        _coinData = JsonUtility.FromJson<CoinData>(data);
    }

    public void OnDisable()
    {
        SaveData();
    }
}
