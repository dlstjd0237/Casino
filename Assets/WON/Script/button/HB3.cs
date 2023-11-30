using UnityEngine;

public class HB3 : MonoBehaviour
{
    public bool horse3 = false;
    public void OnClickExit()
    {
        if (CasinoGameManager.Instance.Coin >= 100)
        {
            CasinoGameManager.Instance.Coin -= 100;
            horse3 = true;
        }
    }
}
