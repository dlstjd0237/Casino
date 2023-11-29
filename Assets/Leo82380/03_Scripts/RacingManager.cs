using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RacingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDownText;
    [SerializeField] private TMP_Text gameEndText;
    [SerializeField] private GameObject endPanel;
    
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
        Debug.Log(other.name);
        endPanel.SetActive(true);
        Time.timeScale = 0f;
        gameEndText.gameObject.SetActive(true);
        gameEndText.text = other.name + " Win!";
    }
}
