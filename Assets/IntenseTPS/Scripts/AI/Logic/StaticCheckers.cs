using System.Collections.Generic;
using UnityEngine;

public class Checkers
{
    public static bool IsOneOfTags(Transform transform, List<string> tags)
    {
        if (tags != null && transform != null)
        {
            foreach (string str in tags)
            {
                if (transform.CompareTag(str))
                    return true;
            }
        }

        return false;
    }

    public static bool isChildOf(Transform transform, Transform[] childs)
    {
        foreach (Transform child in childs)
            if (transform == child)
                return true;
        return false;
    }

    public static Transform FindInChilds(Transform baseParent, string transformName)
    {
        Transform[] childs = baseParent.GetComponentsInChildren<Transform>();
        foreach (var child in childs)
            if (child.name == transformName)
                return child;
        return null;
    }
}