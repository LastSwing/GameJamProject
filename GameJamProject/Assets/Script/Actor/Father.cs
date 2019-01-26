using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : BasicActor {

	public Father() { }

	public Father(float _pressValue, float _harmonyValue, float _moneyValue, float _healthyValue) : base(_pressValue, _harmonyValue, _moneyValue, _healthyValue) { }

	public override void ReCalculHarmonyValye()
	{
		base.ReCalculHarmonyValye();
	}

	public override void ReCalculHealthyValue()
	{
		base.ReCalculHealthyValue();
	}

	public override void ReCalculMoneyValue()
	{
		base.ReCalculMoneyValue();
	}

	public override void ReCalculPressValue()
	{
		base.ReCalculPressValue();
	}
}
