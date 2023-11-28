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
    
    public DifficultyType DifficultyType => difficultyType;

    protected override void Awake()
    {
        base.Awake();
        difficultyPanel.transform.localScale = Vector3.zero;
        difficultyPanel.transform.DOScale(1f, duration).SetEase(ease);
    }

    public void Easy()
    {
        Logger.Log("Easy");
        difficultyType = DifficultyType.Easy;
        GameStart();
    }
    
    public void Normal()
    {
        Logger.Log("Normal");
        difficultyType = DifficultyType.Normal;
        GameStart();
    }
    
    public void Hard()
    {
        Logger.Log("Hard");
        difficultyType = DifficultyType.Hard;
        GameStart();
    }
    
    private void GameStart()
    {
        SceneManager.LoadScene("Racing_Game");
    }
}
