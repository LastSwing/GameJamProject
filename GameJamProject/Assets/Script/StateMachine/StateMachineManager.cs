using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public sealed class  StateMachineManager
{
    
    private static StateMachineManager instance = null;
    private static readonly object padlock = new object();
    StateMachineManager(){}
    public static StateMachineManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StateMachineManager();
                    }
                }
            }
            return instance;
        }
    }
    List< StateMachine> stateMachineList=new List<StateMachine>();
    public void AddMachine(StateMachine machine)
    {
        stateMachineList.Add(machine);
    }
    public bool CheckMachine(StateMachine machine)
    {
        return stateMachineList.Contains(machine);
    }
    public void RemoveMachine(StateMachine machine)
    {
        stateMachineList.Remove(machine);
    }
    public void SendAllMessage(CommonMessage message)
    {
        foreach(StateMachine s in stateMachineList)
        {
            s.OnMessage(message);
        }
    }
 }
    
