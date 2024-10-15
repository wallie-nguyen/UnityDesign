using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface for a predicate that can be used to determine if a transition should be taken.
/// </summary>
public interface IPredicate
{
    bool Evaluate();
}
