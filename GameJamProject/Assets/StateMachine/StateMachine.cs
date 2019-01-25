using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine
{

    public Dictionary<int, State> dictionary = new Dictionary<int, State>();//状态字典,纪录所有状态
    public State CurrentState { set; get; }//当前状态

    public StateMachine()
    {
        if (StateMachineManager.Instance.CheckMachine(this))
        {
            StateMachineManager.Instance.RemoveMachine(this);
        }
        StateMachineManager.Instance.AddMachine(this);
    }
    public State GetState(int id)//获取当前状态(id为索引)
    {
        if (dictionary.ContainsKey(id))
            return dictionary[id];
        else
            return null;
    }

    public void AddState(State state)//注册状态
    {
        int id = state.ID;
        if (!dictionary.ContainsKey(id))
            dictionary.Add(id, state);
    }

    public void RemoveState(int id)//移除状态
    {
        if (dictionary.ContainsKey(id))
            dictionary.Remove(id);
    }

    public void InitState(int id)//初始化当前状态
    {
        if (CurrentState == null)
        {
            CurrentState = dictionary[id];
            CurrentState.Enter();
        }
    }

    public void ChangeState(int id)//状态转移(执行当前状态的离开操作以及新状态的进入操作)
    {
        if (CurrentState.ID != id)
        {
            CurrentState.Exit();
            CurrentState = dictionary[id];
            CurrentState.Enter();
        }
    }

    public void ExecuteState()//执行状态运行的操作,这个一般是在update中执行
    {
        CurrentState.Execute();
    }

    public bool CheckState(int id)//检查状态
    {
        return CurrentState.ID == id;
    }

    public void OnMessage(CommonMessage message)//接收广播响应状态
    {
        CurrentState.OnMessage(message);
    }
}