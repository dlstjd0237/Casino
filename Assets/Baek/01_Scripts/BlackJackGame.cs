using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlackJackGame : MonoBehaviour
{
    private CardInfo _cardInfo;
    private int CardCount = 0;
    [SerializeField] private TextMeshProUGUI _pointText;
    private int _currentPlayerPoint = 0;
    private int _currentPlayerCardAmount;
    private void Awake()
    {
        _cardInfo = GetComponent<CardInfo>();
        CardCount = _cardInfo._cardListSO.CardList.Count;
        for (int i = 1; i < 3; i++)
        {
            GameObject Card = Instantiate(_cardInfo._cardListSO.CardList[Random.Range(0, CardCount)], transform);
            ++_currentPlayerCardAmount;
            Card.transform.position = PlayerCardTrm(_currentPlayerCardAmount);
            Card.GetComponent<CardOpen>().OpenCard();
            _currentPlayerPoint += Card.GetComponent<CardOpen>().CardInfo.Point;
            _pointText.SetText(_currentPlayerPoint.ToString());
        }
    }

    public void HitBtn()
    {
        GameObject Card = Instantiate(_cardInfo._cardListSO.CardList[Random.Range(0, CardCount)], transform);
        ++_currentPlayerCardAmount;
        Card.transform.position = PlayerCardTrm(_currentPlayerCardAmount);
        Card.GetComponent<CardOpen>().OpenCard();
        _currentPlayerPoint += Card.GetComponent<CardOpen>().CardInfo.Point;
        _pointText.SetText(_currentPlayerPoint.ToString());
        if (_currentPlayerPoint == 21)
        {
            Debug.Log("½Â¸®");
        }else if( _currentPlayerPoint > 21)
        {
            Debug.Log("´Ï°¡ Áü ¤»");
        }

    }

    private Vector2 PlayerCardTrm(int Count)
    {
        switch (Count)
        {
            case 1:
                return new Vector2(-2.25f, -1.5f);
            case 2:
                return new Vector2(-1, -1.5f);
            case 3:
                return new Vector2(0.25f, -1.5f);
            case 4:
                return new Vector2(1.5f, -1.5f);
            case 5:
                return new Vector2(-2.25f, -3f);
            case 6:
                return new Vector2(-1f, -3f);
            case 7:
                return new Vector2(0.25f, -3f);
            case 8:
                return new Vector2(1.5f, -3f);

            default:
                return new Vector2(1, 1);
        }
    }
}
