using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycles : MonoBehaviour {
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
		if (info.normalizedTime >= 1.0f)
		{
			_animator.speed = 0;
		}
	}
}
