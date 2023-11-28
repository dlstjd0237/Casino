public class CasinoGameManager : Singleton<CasinoGameManager>
{
    private int _coin = 0;
    public int Coin { get => _coin; set => _coin = value; }
}
