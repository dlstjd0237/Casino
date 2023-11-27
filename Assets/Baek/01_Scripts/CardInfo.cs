using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CardType
{
    Spade,
    Heart,
    Diamond,
    Club
}

[Serializable]
public class Card
{
    public CardType CardType;
    public int Point;
}
public class CardInfo : MonoBehaviour
{
    [SerializeField] CardListSO _cardListSO;

}

