using UnityEngine;

public class fallingTrap : MonoBehaviour
{
    public GameObject trapObject; // D��ecek nesne
    public Transform respawnPoint;

    private Vector3 initialPosition; // Ba�lang�� konumu
    private bool isFalling = false; // D��me durumu

    void Start()
    {
        initialPosition = trapObject.transform.position; // Ba�lang�� konumunu kaydet
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FallTrap();
            other.transform.position = respawnPoint.position;
        }
    }

    void FallTrap()
    {
        if (!isFalling)
        {
            isFalling = true;
            Rigidbody rb = trapObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Fizi�i aktif hale getir
            }
        }
    }

    public void ResetTrap()
    {
        trapObject.transform.position = initialPosition; // Ba�lang�� konumuna d�nd�r
        Rigidbody rb = trapObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // H�z� s�f�rla
            rb.angularVelocity = Vector3.zero; // A��sal h�z� s�f�rla
            rb.isKinematic = true; // Fizi�i pasif hale getir
        }
        isFalling = false; // D��me durumunu s�f�rla
    }
}

