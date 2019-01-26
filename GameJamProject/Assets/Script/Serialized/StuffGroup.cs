using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StuffGroup  {
	public int Id = -1;
	public string KeyName = "";
	public int ItemId = -1;
	public string ItemName = "";
	public string ItemModel = "";
	public string ItemSchedule = "";
	public string ItemExplain = "";
	public textObj[] TalkList = null;
	public optionObj[] OptionsList = null;
}
