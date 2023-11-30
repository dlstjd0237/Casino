using UnityEngine;

public class HB5 : MonoBehaviour
{
    public bool horse5 = false;
    public void OnClickExit()
    {
        if (CasinoGameManager.Instance.Coin >= 100)
        {
            CasinoGameManager.Instance.Coin -= 100;
            horse5 = true;
        }
    }
}
