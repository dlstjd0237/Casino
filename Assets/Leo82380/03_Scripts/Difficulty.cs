using UnityEngine;
using DG.Tweening;
using Logger = Log.Logger;
using UnityEngine.SceneManagement;

public enum DifficultyType
{
    Easy,
    Normal,
    Hard
}
public class Difficulty : Singleton<Difficulty>
{
    [SerializeField] private GameObject difficultyPanel;
    [SerializeField] private Ease ease;
    [SerializeField] private float duration;
    [SerializeField] private DifficultyType difficultyType;
    [SerializeField] private GameObject _no;

    public DifficultyType DifficultyType => difficultyType;

    protected override void Awake()
    {
        base.Awake();
        difficultyPanel.transform.localScale = Vector3.zero;
        difficultyPanel.transform.DOScale(1f, duration).SetEase(ease);
    }

    public void Easy()
    {
        if (CasinoGameManager.Instance.Coin >= 10)
        {
            CasinoGameManager.Instance.Coin -= 10;
            Logger.Log("Easy");
            difficultyType = DifficultyType.Easy;
            GameStart();
        }
        else
        {
            _no.SetActive(true);
        }

    }

    public void Normal()
    {
        if (CasinoGameManager.Instance.Coin >= 25)
        {
            CasinoGameManager.Instance.Coin -= 25;
            Logger.Log("Normal");
            difficultyType = DifficultyType.Normal;
            GameStart();
        }
        else
        {
            _no.SetActive(true);
        }
    }

    public void Hard()
    {
        if (CasinoGameManager.Instance.Coin >= 40)
        {
            CasinoGameManager.Instance.Coin -= 40;
            Logger.Log("Hard");
            difficultyType = DifficultyType.Hard;
            GameStart();
        }
        else
        {
            _no.SetActive(true);
        }
    }


    private void GameStart()
    {
        SceneManager.LoadScene("Racing_Game");
    }
}
