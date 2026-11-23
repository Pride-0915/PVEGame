using System.Collections;
using System.Runtime.ConstrainedExecution;
using Unity.Collections;
using UnityEngine;

public class KnoghtWalkState : IPlayerState
{
    private float hor, ver;
    private Vector2 moveDir;
    public KnoghtWalkState(PlayerStateMachine machine) : base(machine)
    {
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        moveDir.Set(hor, ver);
        if (moveDir.magnitude > 0)
        {
            m_rb.transform.position += (Vector3)moveDir.normalized * Time.deltaTime * 8;
        }
        if(moveDir.magnitude == 0)
        {
            m_Machine.SetState<KnightIdleState>();
            return;
        }
        if (hor > 0)
        {
            player.isLeft = false;
        }
        else if (hor < 0)
        {
            player.isLeft = true;
        }
    }
}