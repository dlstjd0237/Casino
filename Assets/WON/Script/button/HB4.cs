using UnityEngine;

public class HB4 : MonoBehaviour
{
    public bool horse4 = false;
    public void OnClickExit()
    {
        if (CasinoGameManager.Instance.Coin >= 100)
        {
            CasinoGameManager.Instance.Coin -= 100;
            horse4 = true;
        }
    }
}