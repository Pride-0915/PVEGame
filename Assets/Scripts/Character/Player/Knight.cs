using System.Collections;
using TMPro;
using UnityEngine;

public class Knight : IPlayer
{
    public Knight(GameObject obj) : base(obj) { }
    protected override void OnInit()
    {
        base.OnInit();
        m_StateMachine.SetState<KnightIdleState>();
    }
}