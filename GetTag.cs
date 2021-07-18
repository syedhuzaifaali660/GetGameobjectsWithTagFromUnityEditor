using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GetTag : MonoBehaviour
{
    public List<GameObject> tags;
    public string tagName;

    List<GameObject> GetAllObjectsOnlyInScne()
    {
        List<GameObject> objectsInScene = new List<GameObject>();
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) 
                &&
                !(go.hideFlags == HideFlags.NotEditable
                ||
                go.hideFlags == HideFlags.HideAndDontSave))
            { objectsInScene.Add(go); }
        }
        return objectsInScene;
    }


    public List<GameObject> GetTagFunc()
    {
        tags.Clear();
        if (DoesTagExits(tagName))  {
            var listObjects = GetAllObjectsOnlyInScne();
            foreach (var item in listObjects)
            {
                if (item.CompareTag(tagName))
                {  tags.Add(item); Debug.Log(item);  }
            }
            return listObjects;
        }
        else  {
            Debug.LogError("Tag Doesn't Exits \n                                               " +
                "Check Tag Spelling");
            return null; }
    }

    public static bool DoesTagExits(string aTag)
    {
        try
        {
            GameObject.FindGameObjectsWithTag(aTag);
            return true;
        } catch
        {
            return false;
        }
    }
}
