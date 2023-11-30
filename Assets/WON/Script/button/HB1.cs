using UnityEngine;

public class HB1 : MonoBehaviour
{
    public bool horse1 = false;
    public void OnClickExit()
    {
        if (CasinoGameManager.Instance.Coin >= 100)
        {
            CasinoGameManager.Instance.Coin -= 100;
            horse1 = true;
        }
    }
}
