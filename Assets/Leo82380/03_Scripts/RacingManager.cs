using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RacingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField] private TMP_Text gameEndText;
    [SerializeField] private GameObject endPanel;

    private int coin = 1000;
    
    private int _countDown = 3;
    
    private void Start()
    {
        StartCoroutine(CountDown());
    }
    
    IEnumerator CountDown()
    {
        while (_countDown > 0)
        {
            _countDownText.text = _countDown.ToString();
            _countDown--;
            yield return new WaitForSeconds(1f);
        }
        _countDownText.text = "GO!";
        coin -= 100;
        yield return new WaitForSeconds(1f);
        _countDownText.transform.DOScale(0f, 1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);
        _countDownText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        endPanel.SetActive(true);
        Time.timeScale = 0f;
        gameEndText.gameObject.SetActive(true);
        gameEndText.text = other.name + " Win!";
        if (other.CompareTag("Player"))
        {
            if (Difficulty.Instance.DifficultyType == DifficultyType.Easy)
                coin += 120;
            else if (Difficulty.Instance.DifficultyType == DifficultyType.Normal)
                coin += 140;
            else if (Difficulty.Instance.DifficultyType == DifficultyType.Hard)
                coin += 200;
        }
        else if (other.CompareTag("Enemy"))
        {
            coin -= 100;
        }
    }
}
