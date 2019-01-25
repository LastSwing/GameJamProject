using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : SingletonMonoBehaviour<GameObjectPool> {
    //下面这句是用字典构造你的池子，字典里的String就是坑的名字，每一个坑对应一个GameObject列表  
    Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>() { };

    //从池子得到物体的方法，传递两个参数，你需要得到的物体，和你需要放置的位置  
    //你所需的物体应该已经制作成预置物体  
    public GameObject GetPool(GameObject go, Vector3 position)
    {
        string key = go.name + "(Clone)";//要去拿东西的坑名字  

        GameObject rongqi; //你用来取物体的容器；  


        //下面分三种情况来分析  
        if (pool.ContainsKey(key) && pool[key].Count > 0)//如果坑存在，坑里有东西  
        {
            //直接拿走坑里面的第一个  
            rongqi = pool[key][0];
            pool[key].RemoveAt(0);//把第一个位置释放；  
        }
        else if (pool.ContainsKey(key) && pool[key].Count <= 0)//坑存在，坑里没东西  
        {
            //初始化一个
            rongqi = Instantiate(go, position, Quaternion.identity) as GameObject;
        }
        else  //没坑  
        {
            //不仅要初始化，还要把坑加上  
            rongqi = Instantiate(go, position, Quaternion.identity) as GameObject;
            pool.Add(key, new List<GameObject>() { });
        }

        //调整物体初始状态  
        rongqi.SetActive(true);

        //子物体显示
        foreach (Transform child in rongqi.transform)
        {
            child.gameObject.SetActive(true);
        }

        //位置初始化  
        rongqi.transform.position = position;
        return rongqi;
    }

    //放入池子中的方法  
    public void IntoPool(GameObject go)
    {
        //东西都是从坑里拿出来的，所以放物体进去的时候肯定有他的坑，可以直接放入，不用分情况了  
        string key = go.name;
        pool[key].Add(go);
        go.SetActive(false);
    }
}
