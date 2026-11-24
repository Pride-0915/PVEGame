using UnityEngine;
// Knight继承IPlayer，并为骑士设置初始状态。
public class Knight : IPlayer
{
    // 把场景中的角色对象交给IPlayer基类；OnInit在首次GameUpdate时调用。
    public Knight(GameObject obj) : base(obj) { }

    protected override void OnInit()
    {
        // 先运行IPlayer.OnInit及其基类初始化，再创建状态机并选择骑士的初始状态。
        base.OnInit();
        m_StateMachine.SetState<KnightIdleState>();
    }
}

// GameUpdate首次调用OnInit时，调用顺序为Knight -> IPlayer -> ICharacter。
// IPlayer在此过程中创建玩家状态机并获取Sprite上的Animator。
// SetState只选择状态；该状态的OnInit会在状态机首次更新该状态时运行。
// 状态机按类型缓存状态：首次切换到某类型时通过反射创建实例，之后复用该实例。