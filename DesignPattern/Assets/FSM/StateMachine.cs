using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private StateNode currentStateNode;
    private Dictionary<Type, StateNode> nodes = new();
    private HashSet<ITransition> anyTransition = new();

    public void Update()
    {
        var transtion = GetTransition();
        if (transtion != null)
        {
            ChangeState(transtion.To);
        }

        currentStateNode.State?.Update();
    }

    public void FixedUpdate()
    {
        currentStateNode.State?.FixedUpdate();
    }

    public void SetState(IState state)
    {
        currentStateNode = nodes[state.GetType()];
        currentStateNode.State?.Enter();
    }

    public void ChangeState(IState state)
    {
        if (state == currentStateNode.State) return;
        var previousState = currentStateNode.State;
        var nextState = nodes[state.GetType()].State;

        previousState?.Exit();
        nextState?.Enter();
        currentStateNode = nodes[state.GetType()];
    }

    private ITransition GetTransition()
    {
        foreach (var transition in anyTransition)
        {
            if (transition.Condition.Evaluate())
            {
                return transition;
            }
        }

        foreach (var transition in currentStateNode.Transitions)
        {
            if (transition.Condition.Evaluate())
            {
                return transition;
            }
        }

        return null;
    }

    public void AddTransition(IState from, IState to, IPredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddAnyTransition(IState to, IPredicate condition)
    {
        anyTransition.Add(new Transition(GetOrAddNode(to).State, condition));
    }

    private StateNode GetOrAddNode(IState state)
    {
        var node = nodes.GetValueOrDefault(state.GetType());

        if (node == null)
        {
            node = new StateNode(state);
            nodes.Add(state.GetType(), node);
        }

        return node;
    }
}
