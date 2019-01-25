using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    StateMachine stateMachine = new StateMachine();

    void Start()
    {
        stateMachine.AddState(new RotateState(transform, stateMachine));
        stateMachine.AddState(new RunState(transform, stateMachine));
        stateMachine.InitState(0);
    }

    void Update()
    {
        stateMachine.ExecuteState();
    }

    void OnGUI()
    {
        if (GUILayout.Button("旋转状态"))
        {
            stateMachine.ChangeState(1);
        }

        if (GUILayout.Button("行走状态"))
        {
            stateMachine.ChangeState(0);
        }
    }
}