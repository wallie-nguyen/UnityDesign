using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A predicate that is a function that returns a boolean value.        
/// </summary>
public class FuncPredicate : IPredicate
{
    readonly System.Func<bool> func;

    /// <summary>
    /// Creates a new FuncPredicate with the given function.
    /// </summary>
    /// <param name="func"></param>
    public FuncPredicate(System.Func<bool> func)
    {
        this.func = func;
    }

    /// <summary>
    /// Evaluates the function and returns the result.
    /// </summary>
    /// <returns></returns>
    public bool Evaluate()
    {
        return func.Invoke();
        // => func.Invoke();
        // return func();  same as above
    }
}
