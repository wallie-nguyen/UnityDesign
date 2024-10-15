using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState : BaseState
{
    public LocomotionState(PlayerController player, Animator animator) : base(player, animator)
    {
    }

    public override void Enter()
    {
        Animator.CrossFade("Locomotion", crossfadeDuration);
    }

    public override void FixedUpdate()
    {
        Player.HandleMove();
    }

    public override void Update() { }
}
