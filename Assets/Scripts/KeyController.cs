using UnityEngine;
using System;

public class KeyController : MonoBehaviour
{
    public Action OnCollectKey;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollectKey();
            Destroy(gameObject);
        }
    }
}
