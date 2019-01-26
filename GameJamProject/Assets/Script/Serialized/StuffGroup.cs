using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StuffGroup  {
	public int Id;
	public string KeyName;
	public int ItemId;
	public string ItemName;
	public string ItemModel;
	public string ItemSchedule;
	public string ItemExplain;
	public TalkList[] TalkList;
	public OptionList[] OptionList;
}
