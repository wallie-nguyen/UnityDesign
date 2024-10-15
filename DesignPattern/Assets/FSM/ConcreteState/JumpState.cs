using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    public JumpState(PlayerController player, Animator animator) : base(player, animator)
    {
    }

    public override void Enter()
    {
        Animator.CrossFade(JumpHash, crossfadeDuration);
    }

    public override void FixedUpdate()
    {
        Player.HandleJump();
        Player.HandleMove();
    }
}
