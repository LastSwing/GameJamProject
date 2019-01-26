using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicActor {

	private float _pressValue = 0;
	private float _harmonyValue = 0;
	private float _moneyValue = 0;
	private float _healthyValue = 0;

	public BasicActor() { }
	public BasicActor(float pressValue, float harmonyValue, float moneyValue, float healthyValue) {
		_pressValue = pressValue;
		_harmonyValue = harmonyValue;
		_moneyValue = moneyValue;
		_healthyValue = healthyValue;
	}
	#region GetSet
	public void setPressValue(float value) {
		_pressValue = value;
	}

	public void setHarmonyValue(float value) {
		_harmonyValue = value;
	}
	public void setMoneyValue(float value) {
		_moneyValue = value;
	}

	public void setHealthyValue(float value) {
		_healthyValue = value;
	}

	public float getPressValeu() {
		return _pressValue;
	}
	public float getHarmonyValue() {
		return _harmonyValue;
	}

	public float getMoneyValue() {
		return _moneyValue;
	}

	public float getHealthyValue() {
		return _healthyValue;
	}
	#endregion
	// reCalculate the value
	public virtual void ReCalculPressValue() {}
	public virtual void ReCalculHarmonyValye() { }
	public virtual void ReCalculMoneyValue() { }
	public virtual void ReCalculHealthyValue() { }

}
