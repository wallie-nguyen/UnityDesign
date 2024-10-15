using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState : IState
{
    protected readonly PlayerController Player;
    protected readonly Animator Animator;

    protected static readonly int MoveXHash = Animator.StringToHash("MoveX");
    protected static readonly int MoveYHash = Animator.StringToHash("MoveY");
    protected static readonly int JumpHash = Animator.StringToHash("Jump");
    protected static readonly int LocomotionHash = Animator.StringToHash("Grounded");

    /// <summary>
    /// The duration of the crossfade between animations.
    /// </summary>
    protected const float crossfadeDuration = 0.1f;

    protected BaseState(PlayerController player, Animator animator)
    {
        this.Player = player;
        this.Animator = animator;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Update()
    {
    }
}

public class PlayerController : MonoBehaviour
{

    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();

        // Create the states
        var locomotionState = new LocomotionState(this, GetComponent<Animator>());
        var jumpState = new JumpState(this, GetComponent<Animator>());

        // Add the transitions
        At(locomotionState, jumpState, new FuncPredicate(() => Input.GetButtonDown("Jump")));
        // At(jumpState, locomotionState, new FuncPredicate(() => Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)); Check for grounding

        // Set the initial state
        stateMachine.SetState(locomotionState);
    }

    void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
    void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void HandleJump() { }
    public void HandleMove() { }
}