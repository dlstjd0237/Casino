using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class RacingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField] private TMP_Text gameEndText;
    [SerializeField] private GameObject endPanel;
    private bool _isWin;


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
        yield return new WaitForSeconds(1f);
        _countDownText.transform.DOScale(0f, 1f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);
        _countDownText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isWin == false)
        {
            Debug.Log(other.name);
            _isWin = true;
            Invoke(nameof(NextSceneLoad), 1);
            endPanel.SetActive(true);

            gameEndText.gameObject.SetActive(true);
            gameEndText.text = other.name + " Win!";
            if (other.CompareTag("Player"))
            {
                if (Difficulty.Instance.DifficultyType == DifficultyType.Easy)
                    CasinoGameManager.Instance.Coin += 20;
                else if (Difficulty.Instance.DifficultyType == DifficultyType.Normal)
                    CasinoGameManager.Instance.Coin += 50;
                else if (Difficulty.Instance.DifficultyType == DifficultyType.Hard)
                    CasinoGameManager.Instance.Coin += 80;
            }

        }
    }

    private void NextSceneLoad()
    {
        SceneManager.LoadScene("Home");
    }
}
