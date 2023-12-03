using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinData
{
    public int Coin;
    public bool StartGame;
    public int Amount1;
    public int Amount2;
    public int Amount3;
    public int Amount4;
    public int Amount5;
    public int Amount6;

}


public class CasinoGameManager : Singleton<CasinoGameManager>
{
    public CoinData _coinData = new CoinData();
    private string path, filename = "/CoinData.json";
    public int Coin { get => _coinData.Coin; set => _coinData.Coin = value; }


    protected override void Awake()
    {
        base.Awake();
      path = Application.persistentDataPath + "/CoinData.json";

        LoadData();


        if (_coinData.StartGame == false)
        {
            _coinData.Coin = 500;
            _coinData.StartGame = true;
            _coinData.Amount1 = 0;
            _coinData.Amount2 = 0;
            _coinData.Amount3 = 0;
            _coinData.Amount4 = 0;
            _coinData.Amount5 = 0;
            _coinData.Amount6 = 0;


        }

        SaveData();
    }
    public void SaveData()
    {

        string data = JsonUtility.ToJson(_coinData);
        File.WriteAllText(path, data);
    }
    public void LoadData()
    {

        string data = File.ReadAllText(path);
        _coinData = JsonUtility.FromJson<CoinData>(data);
    }

    public void OnDisable()
    {
        SaveData();
    }
}
