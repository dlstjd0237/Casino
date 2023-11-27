using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackGame : MonoBehaviour
{
    private CardInfo _cardInfo;

    private void Awake()
    {
        _cardInfo = GetComponent<CardInfo>();
    }
}
