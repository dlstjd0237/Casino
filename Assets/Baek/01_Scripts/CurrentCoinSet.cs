using UnityEngine;
using TMPro;
public class CurrentCoinSet : MonoBehaviour
{
    private TextMeshProUGUI _coinText;

    private void Awake()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
        CoinTextSet();
    }

    public void CoinTextSet()
    {
        _coinText.SetText(CasinoGameManager.Instance.Coin.ToString());
    }
 
}
