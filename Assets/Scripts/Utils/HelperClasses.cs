using UnityEngine;

namespace Utils.HelperClasses
{
    [System.Serializable]
    public class PrefabProps
    {
        [SerializeField] public GameObject prefab;
        [SerializeField] public Transform nodeHolder;
    }
}