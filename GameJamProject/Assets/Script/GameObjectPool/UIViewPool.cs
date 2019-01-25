using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIViewPool  {
    static Dictionary<string, GameObject> pool = new Dictionary<string, GameObject>() { };
    
    public static GameObject FindGameObject(string name, Transform parent)
    {

        Object go=Resources.Load("UI/"+name);
        GameObject rongqi;
        string key = name;
        
        if (pool.ContainsKey(key) )
        {
            rongqi = pool[key];  
        }
        else  
        {
            rongqi = MonoBehaviour.Instantiate(go,parent) as GameObject;
            rongqi.GetComponent<RectTransform>().localPosition=Vector3.zero;
            pool.Add(key, rongqi);
        }
        
        return rongqi;
    }
    
}
