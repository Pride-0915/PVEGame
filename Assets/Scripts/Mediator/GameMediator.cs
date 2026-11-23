using System.Collections;
using UnityEngine;

public class GameMediator : AbstractMediator
{
    private static GameMediator instance;
    public static GameMediator Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameMediator();
            }
            return instance;
        }
    }
    public GameMediator() { }

}