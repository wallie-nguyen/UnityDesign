using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A transition from one state to another with a condition that must be met.
/// </summary>
public class Transition : ITransition
{
    public IState To { get; }

    public IPredicate Condition { get; }

    public Transition(IState to, IPredicate condition)
    {
        To = to;
        Condition = condition;
    }
}
