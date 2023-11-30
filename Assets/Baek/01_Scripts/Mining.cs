using UnityEngine;

public class Mining : MonoBehaviour
{
    private float _coolTIme = 0.25f;
    private bool _touch;
    private void Update()
    {
        if (_touch == true)
        {
            if (_coolTIme >= 0)
            {
                _coolTIme -= Time.deltaTime;
            }
            else
            {
                _coolTIme = 0.25f;
                _touch = false;
            }
        }
    }
    public void CoinMining()
    {
        if (_touch == false)
        {

            CasinoGameManager.Instance.Coin += 1;
            CasinoGameManager.Instance.SaveData();
            _touch = true;

        }
    }
}
