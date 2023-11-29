using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public enum BlackJackTurn
{
    Player,
    Enemy,
    Result
}
public class BlackJackGame : MonoBehaviour
{
    private CardInfo _cardInfo;
    private int CardCount = 0;
    [SerializeField] private TextMeshProUGUI _playerPointText;
    [SerializeField] private TextMeshProUGUI _enemyPointText;
    [SerializeField] private TextMeshProUGUI _gameResultText;
    [SerializeField] private TextMeshProUGUI _takePointText;
    [SerializeField] private TextMeshProUGUI _betText;
    [SerializeField] private GameObject _noMoneyText;
    [SerializeField] private GameObject _gamePanel, _gameStartPanel;
    [SerializeField] private int _bet = 100;
    [SerializeField] private CurrentCoinSet _cointSet;
    private int _currentPlayerPoint = 0;
    private int _currentEnemyPoint = 0;
    private int _currentPlayerCardAmount = 0;
    private int _currentEnemyCardAmount = 0;
    private List<Card> _cardList = new();
    private AudioSource _audioSource;
    private BlackJackTurn _blackJackTurn;
    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
        _cardInfo = GetComponent<CardInfo>();
        _cardList.Clear();
        _blackJackTurn = BlackJackTurn.Player;
        _betText.SetText(_bet.ToString());
        CardCount = _cardInfo._cardListSO.CardList.Count;

    }

    public void StartBtn()
    {
        if (CasinoGameManager.Instance.Coin >= _bet)
        {
            CasinoGameManager.Instance.Coin -= _bet;
            _cointSet.CoinTextSet();
            _cardList.Clear();
            _gameStartPanel.SetActive(false);
            _blackJackTurn = BlackJackTurn.Player;
            _gamePanel.SetActive(false);
            for (int i = 0; i < 2; i++)
            {
                DrawCard(_blackJackTurn);
            }
        }
        else
        {
            _noMoneyText.SetActive(true);
        }
    }

    public void HitBtn()
    {
        if (_blackJackTurn == BlackJackTurn.Player)
            DrawCard(_blackJackTurn);
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
    private Vector2 EnemyCardTrm(int Count)
    {
        switch (Count)
        {
            case 1:
                return new Vector2(-2.25f, 1.5f);
            case 2:
                return new Vector2(-1, 1.5f);
            case 3:
                return new Vector2(0.25f, 1.5f);
            case 4:
                return new Vector2(1.5f, 1.5f);
            case 5:
                return new Vector2(-2.25f, 3f);
            case 6:
                return new Vector2(-1f, 3f);
            case 7:
                return new Vector2(0.25f, 3f);
            case 8:
                return new Vector2(1.5f, 3f);

            default:
                return new Vector2(1, 1);
        }
    }

    private bool CardOverlapChake(Card card)
    {
        for (int i = 0; i < _cardList.Count; i++)
        {
            if (_cardList[i] == card)
            {
                return true;//중복 있음
            }
        }
        return false; //중복 없음
    }
    public void DrawCard(BlackJackTurn Turn)
    {
        GameObject Cardinfo = _cardInfo._cardListSO.CardList[Random.Range(0, CardCount)];
        CardOpen qwer = Cardinfo.GetComponent<CardOpen>();
        if (CardOverlapChake(qwer.CardInfo))
        {
            DrawCard(_blackJackTurn);
            return;
        }
        else
        {
            _cardList.Add(qwer.CardInfo);
        }
        _audioSource.Play();
        GameObject Card = Instantiate(Cardinfo, transform);
        if (Turn == BlackJackTurn.Player)
            ++_currentPlayerCardAmount;
        else if (Turn == BlackJackTurn.Enemy)
            ++_currentEnemyCardAmount;

        Card.transform.position = _blackJackTurn == BlackJackTurn.Player ? PlayerCardTrm(_currentPlayerCardAmount) : EnemyCardTrm(_currentEnemyCardAmount);
        Card.GetComponent<CardOpen>().OpenCard();
        if (Turn == BlackJackTurn.Player)
        {
            _currentPlayerPoint += Card.GetComponent<CardOpen>().CardInfo.Point;
            _playerPointText.SetText(_currentPlayerPoint.ToString());

        }
        else if (Turn == BlackJackTurn.Enemy)
        {
            _currentEnemyPoint += Card.GetComponent<CardOpen>().CardInfo.Point;
            _enemyPointText.SetText(_currentEnemyPoint.ToString());
        }

        if (Turn == BlackJackTurn.Player)
        {
            if (_currentPlayerPoint == 21)
            {
                PlayerWin();
            }
            else if (_currentPlayerPoint > 21)
            {
                EnemyWin();
            }
        }
        else if (Turn == BlackJackTurn.Enemy)
        {
            if (_currentEnemyPoint == 21)
            {
                EnemyWin();
            }
            else if (_currentEnemyPoint > 21)
            {
                PlayerWin();
            }
            else if (_currentEnemyPoint == _currentPlayerPoint)
            {
                Draw();
            }
            else if (_currentEnemyPoint > _currentPlayerPoint)
            {
                EnemyWin();
            }
        }
    }



    private void EnemyWin()
    {
        OnPanel();
        _gameResultText.SetText("Defeat");
        _takePointText.SetText("+ 0");
        _cointSet.CoinTextSet();
    }

    private void PlayerWin()
    {
        OnPanel();
        _gameResultText.SetText("Victory");
        CasinoGameManager.Instance.Coin += _bet * 2;

        _takePointText.SetText("+ "+(_bet * 2).ToString());
        _cointSet.CoinTextSet();
    }

    private void Draw()
    {
        OnPanel();
        _gameResultText.SetText("Draw");
        CasinoGameManager.Instance.Coin += _bet;

        _takePointText.SetText("+ "+_bet.ToString());
        _cointSet.CoinTextSet();
    }
    private void OnPanel()
    {
        _gamePanel.SetActive(true);
    }

    public void Stand()
    {
        if (_blackJackTurn == BlackJackTurn.Player)
        {
            _blackJackTurn = BlackJackTurn.Enemy;
            _cardList.Clear();
            StartCoroutine(EnemyAi());

        }

    }


    private IEnumerator EnemyAi()
    {
        for (int i = 0; i < 2; i++)
        {
            DrawCard(_blackJackTurn);
            yield return new WaitForSeconds(1.5f);
        }
        while (_currentPlayerPoint > _currentEnemyPoint)
        {
            DrawCard(_blackJackTurn);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void NewGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
