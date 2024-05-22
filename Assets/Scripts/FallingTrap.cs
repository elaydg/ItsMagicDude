using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Ba�lang��ta hareket etmesin
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.isKinematic = false; // Tetiklenince kinematik de�il
        }
    }
}

