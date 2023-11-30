using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Roll : MonoBehaviour
{
    private int currentCoinValue;
    [SerializeField] float rotSpeed;
    [SerializeField] RayPin rayPin;
    [SerializeField] TextMeshProUGUI coinValue;
    [SerializeField] Image stopButton;
    private int coin;
    float changeSpeed;
    bool isSpin;
    bool isStartSpin;

    private void Awake()
    {
        coinValue.text = $"Coin : {CasinoGameManager.Instance.Coin}";
        stopButton.color = Color.gray;
    }

    public void StartSpinRoulette()
    {
        if (CasinoGameManager.Instance.Coin < 100)
            coinValue.text = "Not enough Coin!";
        else if (isStartSpin == false)
        {
            CasinoGameManager.Instance.Coin -= 50;

            coinValue.text = $"Coin : {CasinoGameManager.Instance.Coin}";

            isStartSpin = true;
            DOTween.To(() => 0, x => changeSpeed = x, rotSpeed, 5).OnComplete(() =>
            {
                isSpin = true;
                stopButton.color = Color.white;
            });
        }
    }

    public void StopSpinRoulette()
    {
        if (isSpin == true)
        {
            isSpin = false;
            DOTween.To(() => rotSpeed, x => changeSpeed = x, 0, 7).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                if (CasinoGameManager.Instance.Coin + int.Parse(rayPin.RayDown()) >= 0)
                {
                    StartCoroutine(ReslutValue());
                }

                stopButton.color = Color.gray;
                isStartSpin = false;
            });
        }
    }

    IEnumerator ReslutValue()
    {
        int currentInt = CasinoGameManager.Instance.Coin;
        int resultsInt;

        if (rayPin.RayDown() == "*5" || rayPin.RayDown() == "/5")
        {
            resultsInt = CasinoGameManager.Instance.Coin + int.Parse(rayPin.RayDown());
        }
        resultsInt = CasinoGameManager.Instance.Coin + int.Parse(rayPin.RayDown());
        bool isMasdaad = currentInt > resultsInt;

        while (currentInt != resultsInt)
        {
            currentInt += isMasdaad ? -1 : 1;
            coinValue.text = $"Coin : {currentInt}";
            yield return null;
        }
    }

    private void Update()
    {
        print(10);
        transform.Rotate(new Vector3(0, 0, -changeSpeed) * Time.deltaTime);
        Debug.Log(CasinoGameManager.Instance.Coin);
    }
}
