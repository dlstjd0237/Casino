using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class SlotGame : MonoBehaviour
{
    public TMP_Text firstReel;
    public TMP_Text secondReel;
    public TMP_Text thirdReel;

    public TMP_InputField inputBet;

    public TMP_Text betResult;
    public TMP_Text currentCredits;

    private int betAmount;

    public int numberOfSym = 10;

    public float spinDuration = 1.5f;
    private float elapsedTime = 0.0f;

    private bool startSpin = false;

    private bool firstReelSpun = false;
    private bool secondReelSpun = false;
    private bool thirdReelSpun = false;

    private int firstReelResult = 0;
    private int secondReelResult = 0;
    private int thirdReelResult = 0;

    [Serializable]
    public struct WeightedProbability
    {
        public int Number;
        public int Weight;
    }

    private List<WeightedProbability> weightedReelPool = new List<WeightedProbability>();

    private void Start()
    {
        currentCredits.text = "Coin : " + CasinoGameManager.Instance.Coin.ToString();
        SetUpProbability();
    }

    private void Update()
    {
        SpinProcess();
    }

    private void SetBetAmount()
    {
        try
        {
            betAmount = int.Parse(inputBet.text);
        }
        catch
        {
            betAmount = 0;
        }
    }
    public void SpinStart()
    {
        SetBetAmount();
        betResult.text = "";
        if (betAmount > 0 && CasinoGameManager.Instance.Coin >= betAmount)
        {
            startSpin = true;
        }
        else
        {
            betResult.text = "Invalid Value!!";
        }
    }

    private void SpinProcess()
    {
        if (startSpin)
        {
            elapsedTime += Time.deltaTime;
            int randomSpinResult = Random.Range(0, numberOfSym);
            if (!firstReelSpun)
            {
                firstReel.text = randomSpinResult.ToString();
                if (elapsedTime >= spinDuration)
                {
                    int weightedRandom = PickNumber();
                    firstReelResult = weightedRandom;
                    firstReel.text = weightedRandom.ToString();
                    firstReelSpun = true;
                    elapsedTime = 0;
                }
            }
            else if (!secondReelSpun)
            {
                secondReel.text = randomSpinResult.ToString();
                if (elapsedTime >= spinDuration)
                {
                    secondReelResult = randomSpinResult;
                    secondReelSpun = true;
                    elapsedTime = 0;
                }
            }
            else if (!thirdReelSpun)
            {
                thirdReel.text = randomSpinResult.ToString();
                if (elapsedTime >= spinDuration)
                {
                    if (firstReelResult == secondReelResult)
                    {
                        SetUpProbability(firstReelResult, 3);
                    }
                    int weightedRandom = PickNumber();
                    thirdReelResult = weightedRandom;
                    thirdReel.text = weightedRandom.ToString();

                    startSpin = false;
                    elapsedTime = 0;

                    firstReelSpun = false;
                    secondReelSpun = false;

                    CheckBet();
                    SetUpProbability();
                }
            }
        }
    }

    private void CheckBet()
    {
        if (firstReelResult == secondReelResult && secondReelResult == thirdReelResult)
        {
            betResult.text = "!!JackPot!!";
            CasinoGameManager.Instance.Coin += 10 * betAmount;
            currentCredits.text = "Coin : " + CasinoGameManager.Instance.Coin.ToString();
        }
        else if (firstReelResult == secondReelResult)
        {
            betResult.text = "SoSo!!";
            CasinoGameManager.Instance.Coin += (int)(2f * betAmount);
            currentCredits.text = "Coin : " + CasinoGameManager.Instance.Coin.ToString();
        }
        else if (firstReelResult == thirdReelResult)
        {
            betResult.text = "SoSo!!";
            CasinoGameManager.Instance.Coin += (int)(2f * betAmount);
            currentCredits.text = "Coin : " + CasinoGameManager.Instance.Coin.ToString();
        }
        else if (secondReelResult == thirdReelResult)
        {
            betResult.text = "SoSo!!";
            CasinoGameManager.Instance.Coin += (int)(2f * betAmount);
            currentCredits.text = "Credits : " + CasinoGameManager.Instance.Coin.ToString();
        }
        else
        {
            betResult.text = "You Lose!!";
            CasinoGameManager.Instance.Coin -= betAmount;
            currentCredits.text = "Credits : " + CasinoGameManager.Instance.Coin.ToString();
        }
    }

    private void SetUpProbability(int WeightNumber = 0, int Weight = 3)
    {
        weightedReelPool.Clear();
        int weight = 0;
        for (int i = 0; i < 10; i++)
        {
            weight = 1;
            if (i == WeightNumber) weight = Weight;
            weightedReelPool.Add(new WeightedProbability { Number = i, Weight = weight });
        }
    }

    private int PickNumber()
    {
        int maxWeight = 0;
        int weight = 0;
        foreach (var item in weightedReelPool)
        {
            maxWeight += item.Weight;
        }
        int rand = Random.Range(0, maxWeight);
        foreach (var item in weightedReelPool)
        {
            weight += item.Weight;
            if (rand < weight)
            {
                return item.Number;
            }
        }
        Debug.LogError("Error!");
        return 9999;
    }
}
