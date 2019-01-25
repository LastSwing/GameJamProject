using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CommonMessage  {
    float createTime;
    public int cmd = 0;
    public string body = "";
    public CommonMessage()
    {
        createTime = Time.time;
    }
	
}
