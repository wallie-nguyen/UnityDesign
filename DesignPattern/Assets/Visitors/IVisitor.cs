using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor
{
    void Visit<T>(T visitable) where T : Component, IVisitable;
}

public interface IVisitable
{
    void Accept(IVisitor visitor);
}

public class MyVisitor : MonoBehaviour, IVisitor
{
    public void Visit<T>(T visitable) where T : Component, IVisitable
    {
    }
}