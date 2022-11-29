using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private bool isATrap;
    [SerializeField] private float fallSpeed;

    private void TrapPlatform()
    {
        if (!isATrap)
            return;

        LeanTween.moveLocalY(gameObject, -7f, fallSpeed);
        LeanTween.Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            TrapPlatform();
    }
}
