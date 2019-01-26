using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class textObj {
	public int Id = -1;
	public string keyName = "";
	public int Index = -1;
	public int TalkStage = -1;
	public int Object = -1; // record the actor name
	public int OptionsNumber = -1;
	public string TalkText = "";
	public int ItemScheduler = -1;
}
