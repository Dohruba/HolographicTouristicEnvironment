using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;

    public static GameSettings GameSettings { get { return instance._gameSettings; } }
    [SerializeField]
    private List<NetworkedPrefab> _networkedPrefabs = new List<NetworkedPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 pos, Quaternion rotation)
    {
        Debug.Log("Call to instantiate " + obj.name);
        foreach (NetworkedPrefab networkedPrefab in instance._networkedPrefabs)
        {
            if (networkedPrefab.prefab == obj)
            {
                if (networkedPrefab.Path != string.Empty)
                {

                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, pos, rotation);
                    Debug.Log("AAAAAAAAAAA");
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameobject: " + networkedPrefab.prefab);
                    return null;
                }
            }
        }
        return null;
    }

    public static void NetworkDestroy(PhotonView photonView)
    {
        PhotonNetwork.Destroy(photonView);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkedPrefab()
    {
#if UNITY_EDITOR        

        instance._networkedPrefabs.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                NetworkedPrefab networkedPrefab = new NetworkedPrefab(results[i], path);
                Debug.Log(networkedPrefab);
                instance._networkedPrefabs.Add(networkedPrefab);
            }
        }
#endif
    }

}
