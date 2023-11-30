using UnityEngine;

public class HB2 : MonoBehaviour
{
    public bool horse2 = false;
    public void OnClickExit()
    {
        if (CasinoGameManager.Instance.Coin >= 100)
        {
            CasinoGameManager.Instance.Coin -= 100;
            horse2 = true;
        }
    }
}
