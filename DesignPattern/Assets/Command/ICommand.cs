using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}

public interface IReceiver
{
    void Attack();
    void Defend();
}

public abstract class Command : ICommand
{
    protected readonly IReceiver _receiver;
    protected Command(IReceiver receiver)
    {
        _receiver = receiver;
    }

    public abstract void Execute();
    public abstract void Undo();

    public static Command Create<T>(IReceiver receiver) where T : Command
    {
        // This is the factory method that creates the command instance when needed.
        return (T)System.Activator.CreateInstance(typeof(T), receiver);
    }
}

public class AttackCommand : Command
{
    public AttackCommand(IReceiver receiver) : base(receiver) { }

    public override void Execute()
    {
        _receiver.Attack();
    }

    public override void Undo()
    {
        // Implement undo logic here
    }
}

public class DefendCommand : Command
{
    public DefendCommand(IReceiver receiver) : base(receiver) { }

    public override void Execute()
    {
        _receiver.Defend();
    }

    public override void Undo()
    {
        // Implement undo logic here
    }
}

public class Invoker
{
    private ICommand _command;
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
        _commandHistory.Push(_command);
        _redoStack.Clear(); // Clear redo stack on new command
    }

    public void UndoCommand()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand command = _commandHistory.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
    }

    public void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            ICommand command = _redoStack.Pop();
            command.Execute();
            _commandHistory.Push(command);
        }
    }
}

public class Hero : MonoBehaviour, IReceiver
{
    public void Attack()
    {
        Debug.Log("Hero attacks!");
    }

    public void Defend()
    {
        Debug.Log("Hero defends!");
    }
}

public class HeroController : MonoBehaviour
{
    private IReceiver _hero;
    private Invoker _invoker;

    void Start()
    {
        _hero = GetComponent<Hero>();
        _invoker = new Invoker();

        // Example usage
        ICommand attackCommand = new AttackCommand(_hero);
        ICommand defendCommand = new DefendCommand(_hero);

        _invoker.SetCommand(attackCommand);
        _invoker.ExecuteCommand(); // Hero attacks!

        _invoker.SetCommand(defendCommand);
        _invoker.ExecuteCommand(); // Hero defends!

        // Undo the last command (defend)
        _invoker.UndoCommand(); // Undo Hero defends!

        // Redo the last undone command (defend)
        _invoker.RedoCommand(); // Hero defends!
    }
}