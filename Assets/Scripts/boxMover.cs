using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public float speed = 10f; // Hareket h�z�
    public float maxDistance = 4f; // Hareket edece�i maksimum mesafe

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        // Ba�lang�� pozisyonunu kaydet
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Maksimum mesafeye ula�t���nda y�n� de�i�tir
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            movingRight = !movingRight; // Y�n� de�i�tir
            startPosition = transform.position; // Yeni ba�lang�� pozisyonu olarak ayarla
        }
    }
}

/*public class boxMover : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 100f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            transform.position = startPosition; // Ba�a d�ner
            // speed = 0; // Durdurmak isterseniz bu sat�r� kullan�n
        }
    }
}*/
