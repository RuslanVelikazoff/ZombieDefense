public class GameData
{
    public int coin;

    public bool[] buyGun = new bool[4];

    public GameData()
    {
        coin = 200000;

        buyGun[0] = true;
        buyGun[1] = false;
        buyGun[2] = false;
        buyGun[3] = false;
    }
}
