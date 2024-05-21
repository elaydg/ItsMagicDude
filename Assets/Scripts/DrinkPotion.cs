using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPotion : MonoBehaviour
{
    public GameObject player;
    public GameObject drinkText;
    public GameObject crawlNote;

    public bool inReach = false;
    private bool isDrink = false;


    private PlayerController playerController;
    private ReadNotes readNotes;

    private void Start()
    {
        drinkText.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        crawlNote.SetActive(false);

        readNotes = FindObjectOfType<ReadNotes>(); // ReadNotes script'ini bul
        if (readNotes == null)
        {
            Debug.LogError("ReadNotes component is missing or not assigned.");
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isDrink)
        {
            if (readNotes != null && readNotes.isRead) 
            {
                drinkText.SetActive(true);
            }
            
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            drinkText.SetActive(false);
            inReach = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {
            drinkPotion();
            crawlNote.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerController>().enabled = false;

        }
    }

    void drinkPotion() 
    {
        isDrink = true;
        if (playerController != null)
        {
            playerController.EnableCrawling();
        }

        drinkText.SetActive(false);
    }

    public void ExitButton() 
    {
        crawlNote.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;

    }
}
