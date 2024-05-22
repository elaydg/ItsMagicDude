using UnityEngine;

public class fallingTrap : MonoBehaviour
{
    public GameObject trapObject; // Düþecek nesne
    public Transform respawnPoint;

    private Vector3 initialPosition; // Baþlangýç konumu
    private bool isFalling = false; // Düþme durumu

    void Start()
    {
        initialPosition = trapObject.transform.position; // Baþlangýç konumunu kaydet
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
                rb.isKinematic = false; // Fiziði aktif hale getir
            }
        }
    }

    public void ResetTrap()
    {
        trapObject.transform.position = initialPosition; // Baþlangýç konumuna döndür
        Rigidbody rb = trapObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // Hýzý sýfýrla
            rb.angularVelocity = Vector3.zero; // Açýsal hýzý sýfýrla
            rb.isKinematic = true; // Fiziði pasif hale getir
        }
        isFalling = false; // Düþme durumunu sýfýrla
    }
}

