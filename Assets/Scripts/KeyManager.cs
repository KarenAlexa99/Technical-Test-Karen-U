using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private KeyController[] keys;
    public int CollectedKeys { get; set; }

    private void Awake()
    {
        CollectedKeys = 0;

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].OnCollectKey += CollectedKey;
        }
    }

    private void CollectedKey()
    {
        CollectedKeys++;
    }

    public int GetMaximumKeys()
    {
        return keys.Length;
    }

}
