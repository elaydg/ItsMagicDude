using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject notes;
    public GameObject pickUpText;
    public GameObject poison;

    public bool inReach = false;
    public bool isRead = false;
    void Start()
    {
        notes.SetActive(false);
        pickUpText.SetActive(false);

        if (poison != null)
        {
            poison.GetComponent<Collider>().enabled = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            pickUpText.SetActive(true);
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            pickUpText.SetActive(false);
            inReach = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach) 
        {
            notes.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            player.GetComponent<PlayerController>().enabled = false; //not okunurken oyuncunun hareketlerini durdur.

        }
    }

    public void ExitButton() 
    {
        notes.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (poison != null)
        {
            Collider poisonCollider = poison.GetComponent<Collider>();
            if (poisonCollider != null)
            {
                poisonCollider.enabled = true; //poison etkinleþtirildi
            }
            else
            {
                Debug.LogError("Poison object is missing a Collider component!");
            }
        }

        isRead = true;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
