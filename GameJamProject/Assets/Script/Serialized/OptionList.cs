using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OptionList
{
	public int Id;//第几个选项
	public string KeyName;
	public int Index;//后继
	public int OptionsStage;
	public int OptionNumber;
	public string OptionsText;
	public int Pressure;
	public int Healthy;
	public int Happiness;
	public int Riches;
}
