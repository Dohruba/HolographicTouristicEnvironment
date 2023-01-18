using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab
{
    public GameObject prefab;
    public string Path;

    public NetworkedPrefab(GameObject obj, string path)
    {
        prefab = obj;
        Path = ReturnModifiedPrefab(path);
    }

    private string ReturnModifiedPrefab(string path)
    {
        int extLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10;
        int startIndex = path.ToLower().IndexOf("resources");
        if (startIndex == -1)
        {
            return string.Empty;
        }
        else
        {
            string cutPath = path.Substring(startIndex + additionalLength, path.Length - (startIndex + extLength + additionalLength));
            return cutPath;
        }
    }
}
