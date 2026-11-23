using System.Collections;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class KnightIdleState:IPlayerState
{
    protected float hor, ver;
    protected Vector2 moveDir;
    public KnightIdleState(PlayerStateMachine machine) : base(machine) { }
    protected override void OnEnter()
    {
        base.OnEnter();
        m_Animator.SetBool("isIdle", true);
        m_rb.velocity = Vector2.zero;
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        moveDir.Set(hor, ver);
        if (moveDir.magnitude > 0)
        {
            m_Machine.SetState<KnoghtWalkState>();
            return;
        }
    }
    
    public override void OnExit()
    {
        base.OnExit();
        m_Animator.SetBool("isIdle", false);
    }
}