using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{
    private int currentCoinValue;
    [SerializeField] float rotSpeed;
    [SerializeField] RayPin rayPin;
    [SerializeField] TextMeshProUGUI coinValue;
    [SerializeField] Image stopButton;
    float changeSpeed;
    bool isSpin;
    bool isStartSpin;

    private void Awake()
    {
        stopButton.color = Color.gray;
    }

    public void StartSpinRoulette()
    {
        if(isStartSpin == false)
        {
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
        if(isSpin == true)
        {
            isSpin = false;
            DOTween.To(() => rotSpeed, x => changeSpeed = x, 0, 7).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                if (int.Parse(rayPin.RayDown()) <= 0)
                    coinValue.text = $"Coin : 0";
                else
                {
                    coinValue.text = $"Coin : {currentCoinValue += int.Parse(rayPin.RayDown())}";


                }
                stopButton.color = Color.gray;
                isStartSpin = false;
            });
        }
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -changeSpeed) * Time.deltaTime);
    }
}
