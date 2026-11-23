using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    Knight,
}
public class PlayerFactory
{
    private static PlayerFactory instance;
    public static PlayerFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerFactory();
            }
            return instance;
        }
    }
    public IPlayer GetPlayer(PlayerType type)
    {
        GameObject obj = GameObject.Find(type.ToString());
        IPlayer player = null;
        switch(type)
        {
            case PlayerType.Knight:
                player = new Knight(obj);
                break;
        }
        return player;
    }
}