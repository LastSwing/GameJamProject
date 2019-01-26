using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TalkList
{
	public int Id;
	public string KeyName;
	public int Index;
	public int TalkStage;
	public int Object; // record the actor name
	public int OptionsNumber;
	public string TalkText;
	public int ItemSchedule;
}
