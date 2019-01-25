using UnityEngine;

public abstract class State
{

    public int ID { set; get; }
    public Transform TargetTra { set; get; }
    public StateMachine StateMac { set; get; }

    public virtual void Enter() { }
    public virtual void Execute() { }
    public virtual void Exit() { }

    public virtual void OnMessage(CommonMessage message) { }
}
