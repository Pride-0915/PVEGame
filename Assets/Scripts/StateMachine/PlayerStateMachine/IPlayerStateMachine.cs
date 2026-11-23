using System.Collections;
using UnityEngine;

public class PlayerStateMachine : IStateMachine 
{
    public IPlayer m_Player { get;protected set; }
    public PlayerStateMachine(IPlayer player)
    {
        m_Player = player;
    }
}