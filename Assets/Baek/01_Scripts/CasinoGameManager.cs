public class CasinoGameManager : Singleton<CasinoGameManager>
{
    private int _coin = 500;
    public int Coin { get => _coin; set => _coin = value; }
}
