using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 常用的工具类
/// </summary>
public static class GameUtils
{
    /// <summary>
    /// 使用深度优先搜索返回GameObject或任何其子类型T的组件
    /// </summary>
    public static T GetComponentByName<T>(string name, GameObject gameObject) where T : Component
    {
        Component component = null;
        Transform transform = gameObject.transform;
        foreach (Transform child in transform)
        {
            if (child.name == name)
            {
                return child.GetComponent<T>();
            }
            component = GetComponentByName<T>(name, child.gameObject);
            if (component != null)
            {
                break;
            }
        }
        return component as T;
    }

    /// <summary>
    /// 通过名称查找和GameObject物体下面的子物体名称一致的物体
    /// </summary>
    public static GameObject GetGameObjectByName(string name, GameObject gameObject)
    {
        GameObject go = null;
        Transform transform = gameObject.transform;
        foreach (Transform child in transform)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
            go = GetGameObjectByName(name, child.gameObject);
            if (go != null)
            {
                break;
            }
        }
        return go;
    }

    /// <summary>
    ///  通过名称查找和GameObject物体父类名称一致的物体
    /// </summary>
    public static GameObject GetGameObjectByNameInParent(string name, GameObject gameObject)
    {
        if (gameObject != null)
        {
            GameObject parentGO = gameObject.transform.parent.gameObject;
            if (parentGO.name == name)
            {
                return parentGO;
            }
            else
            {
                return GetGameObjectByNameInParent(name, parentGO);
            }
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 重置Transform为默认状态
    /// </summary>
    public static void ResetTransform(Transform transform)
    {
        if (transform != null)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
    }
    
    /// <summary>
    /// 隐藏Transform物体下面的所有子物体
    /// </summary>
    /// <param name="parent"></param>
    public static void SetActiveChildTrans(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            parent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public static void WaitFowScondTimeDoSth(float WaitTime,Action DoSth = null)
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            DoSth.Invoke();
        }
    }

    //压缩图片
    public static Texture2D ResizeTexture(Texture2D pSource, ImageFilterMode pFilterMode, Vector2 newSize)
    {
        int i;

        Color[] aSourceColor = pSource.GetPixels(0);
        Vector2 vSourceSize = new Vector2(pSource.width, pSource.height);

        float xWidth = Mathf.RoundToInt(newSize.x);
        float xHeight = Mathf.RoundToInt(newSize.y);

        Texture2D oNewTex = new Texture2D((int)xWidth, (int)xHeight, TextureFormat.RGBA32, false);

        int xLength = (int)xWidth * (int)xHeight;
        Color[] aColor = new Color[xLength];

        Vector2 vPixelSize = new Vector2(vSourceSize.x / xWidth, vSourceSize.y / xHeight);

        Vector2 vCenter = new Vector2();
        for (i = 0; i < xLength; i++)
        {
            float xX = (float)i % xWidth;
            float xY = Mathf.Floor((float)i / xWidth);

            vCenter.x = (xX / xWidth) * vSourceSize.x;
            vCenter.y = (xY / xHeight) * vSourceSize.y;

            if (pFilterMode == ImageFilterMode.Nearest)
            {
                vCenter.x = Mathf.Round(vCenter.x);
                vCenter.y = Mathf.Round(vCenter.y);

                int xSourceIndex = (int)((vCenter.y * vSourceSize.x) + vCenter.x);

                aColor[i] = aSourceColor[xSourceIndex];
            }

            else if (pFilterMode == ImageFilterMode.Biliner)
            {

                float xRatioX = vCenter.x - Mathf.Floor(vCenter.x);
                float xRatioY = vCenter.y - Mathf.Floor(vCenter.y);

                int xIndexTL = (int)((Mathf.Floor(vCenter.y) * vSourceSize.x) + Mathf.Floor(vCenter.x));
                int xIndexTR = (int)((Mathf.Floor(vCenter.y) * vSourceSize.x) + Mathf.Ceil(vCenter.x));
                int xIndexBL = (int)((Mathf.Ceil(vCenter.y) * vSourceSize.x) + Mathf.Floor(vCenter.x));
                int xIndexBR = (int)((Mathf.Ceil(vCenter.y) * vSourceSize.x) + Mathf.Ceil(vCenter.x));

                aColor[i] = Color.Lerp(
                    Color.Lerp(aSourceColor[xIndexTL], aSourceColor[xIndexTR], xRatioX),
                    Color.Lerp(aSourceColor[xIndexBL], aSourceColor[xIndexBR], xRatioX),
                    xRatioY
                );
            }

            else if (pFilterMode == ImageFilterMode.Average)
            {

                int xXFrom = (int)Mathf.Max(Mathf.Floor(vCenter.x - (vPixelSize.x * 0.5f)), 0);
                int xXTo = (int)Mathf.Min(Mathf.Ceil(vCenter.x + (vPixelSize.x * 0.5f)), vSourceSize.x);
                int xYFrom = (int)Mathf.Max(Mathf.Floor(vCenter.y - (vPixelSize.y * 0.5f)), 0);
                int xYTo = (int)Mathf.Min(Mathf.Ceil(vCenter.y + (vPixelSize.y * 0.5f)), vSourceSize.y);

                Vector4 oColorTotal = new Vector4();
                Color oColorTemp = new Color();
                float xGridCount = 0;
                for (int iy = xYFrom; iy < xYTo; iy++)
                {
                    for (int ix = xXFrom; ix < xXTo; ix++)
                    {

                        oColorTemp += aSourceColor[(int)(((float)iy * vSourceSize.x) + ix)];

                        xGridCount++;
                    }
                }

                aColor[i] = oColorTemp / (float)xGridCount;
            }
        }

        oNewTex.SetPixels(aColor);
        oNewTex.Apply();
        return oNewTex;
    }
}

public enum ImageFilterMode : int
{
    Nearest = 0,
    Biliner = 1,
    Average = 2
}
