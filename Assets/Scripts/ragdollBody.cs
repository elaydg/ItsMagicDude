using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollBody : MonoBehaviour
{
    private Rigidbody[] ragdollRigidBodies;
    private Animator animator;
    private PlayerController playerController;
    private Rigidbody mainRigidbody;
    void Awake()
    {
        ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        mainRigidbody = GetComponent<Rigidbody>();

        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            EnableRagdoll();
        }
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = true;
        }

        if (animator != null)
        {
            animator.enabled = true;
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        if (mainRigidbody != null)
        {
            mainRigidbody.isKinematic = false;
        }
    }

    private void EnableRagdoll() 
    {
        foreach (var rigidbody in ragdollRigidBodies) 
        {
            rigidbody.isKinematic = false;
        }

        if (animator != null)
        {
            animator.enabled = false;
        }

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (mainRigidbody != null)
        {
            mainRigidbody.isKinematic = true;
        }
    }
}
