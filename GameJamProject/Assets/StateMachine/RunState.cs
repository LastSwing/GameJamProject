using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{

    public RunState(Transform targetTra, StateMachine sm)
    {
        ID = 0;
        TargetTra = targetTra;
        StateMac = sm;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("进入移动状态");
        //TargetTra.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public override void Execute()
    {
        base.Execute();
        TargetTra.transform.Translate(Vector3.forward * Time.deltaTime);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("退出移动状态");
        TargetTra.transform.localScale = new Vector3(1, 1, 1);
    }
}