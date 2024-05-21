using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPotion : MonoBehaviour
{
    public GameObject player;
    public GameObject speedText;
    //public GameObject speedNote;

    public bool inReach = false;


    private PlayerController playerController;

    private void Start()
    {
        speedText.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        //crawlNote.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            speedText.SetActive(true);
        }

        inReach = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            speedText.SetActive(false);
            inReach = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {
            potionSpeed();
            /*speedNote.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerController>().enabled = false;*/

        }
    }

    void potionSpeed()
    {
        if (playerController != null)
        {
            playerController.Faster();
        }

        speedText.SetActive(false);
    }

    /*public void ExitButton()
    {
        crawlNote.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;

    }*/
}

