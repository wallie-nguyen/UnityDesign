using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A state node in a state machine.
/// </summary>
public class StateNode
{
    public IState State { get; }
    public HashSet<ITransition> Transitions { get; }

    public StateNode(IState state)
    {
        State = state;
        Transitions = new HashSet<ITransition>();
    }

    /// <summary>
    /// Add a transition to another state.
    /// </summary>
    /// <param name="to"></param>
    /// <param name="condition"></param>
    public void AddTransition(IState to, IPredicate condition)
    {
        Transitions.Add(new Transition(to, condition));
    }
}
