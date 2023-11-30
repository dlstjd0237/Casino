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
    [SerializeField] TextMeshProUGUI spinBtn;
    Image spinBtnColor;
    private int coin;
    float changeSpeed;
    bool isSpin;
    bool isStartSpin;
    bool isClick = true;

    private void Awake()
    {
        spinBtnColor = spinBtn.GetComponentInParent<Image>();
        spinBtn.text = "SPIN!";
        coinValue.text = $"Coin : {CasinoGameManager.Instance.Coin}";
    }

    public void ClickBtn()
    {
        if (isClick)
        {
            spinBtn.text = "STOP!";
            spinBtnColor.color = Color.gray;
            StartSpinRoulette();
            isClick = false;
        }
        else
        {
            StopSpinRoulette();
        }
    }

    public void StartSpinRoulette()
    {
        if (CasinoGameManager.Instance.Coin < 50)
            coinValue.text = "Not enough Coin!";
        else if (isStartSpin == false)
        {
            CasinoGameManager.Instance.Coin -= 50;

            coinValue.text = $"Coin : {CasinoGameManager.Instance.Coin}";

            isStartSpin = true;
            DOTween.To(() => 0, x => changeSpeed = x, rotSpeed, 5).OnComplete(() =>
            {
                isSpin = true;
                spinBtnColor.color = Color.white;
            });
        }
    }

    public void StopSpinRoulette()
    {
        spinBtnColor.color = Color.gray;
        if (isSpin == true)
        {
            isSpin = false;
            DOTween.To(() => rotSpeed, x => changeSpeed = x, 0, 7).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                StartCoroutine(ReslutValue());


                isStartSpin = false;
                spinBtn.text = "SPIN!";
            });
        }
    }

    IEnumerator ReslutValue()
    {
        int currentInt = CasinoGameManager.Instance.Coin;
        int resultsInt;

        if (rayPin.RayDown() == "3") //곱하기 3
        {
            resultsInt = CasinoGameManager.Instance.Coin * 3;
            CasinoGameManager.Instance.Coin *= int.Parse(rayPin.RayDown());
        }
        else if (rayPin.RayDown() == "5") //나누기 5
        {
            resultsInt = CasinoGameManager.Instance.Coin / 5;
            CasinoGameManager.Instance.Coin /= int.Parse(rayPin.RayDown());
        }
        else
        {
            resultsInt = CasinoGameManager.Instance.Coin + int.Parse(rayPin.RayDown());
            print($"resultsInt : {resultsInt}");
            CasinoGameManager.Instance.Coin += int.Parse(rayPin.RayDown());
        }

        print($"current : {currentInt}, result : {resultsInt}");

        bool isMasdaad = currentInt > resultsInt;

        while (currentInt != resultsInt)
        {
            currentInt += isMasdaad ? -1 : 1;
            coinValue.text = $"Coin : {currentInt}";
            if (currentInt <= 0)
            {
                CasinoGameManager.Instance.Coin = 0;
                break;
            }
            yield return null;
        }
        isClick = true;
        spinBtnColor.color = Color.white;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -changeSpeed) * Time.deltaTime);
        Debug.Log($"Coin : {CasinoGameManager.Instance.Coin}");
    }
}
