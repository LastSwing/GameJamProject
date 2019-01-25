using UnityEngine;
using System.Collections;

public class RotateState : State
{

    public RotateState(Transform targetTra, StateMachine sm)
    {
        ID = 1;
        TargetTra = targetTra;
        StateMac = sm;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("进入旋转状态");
       // TargetTra.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public override void Execute()
    {
        base.Execute();
        TargetTra.transform.Rotate(Vector3.up);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("退出旋转状态");
        TargetTra.transform.localScale = new Vector3(2, 2, 2);
    }
}