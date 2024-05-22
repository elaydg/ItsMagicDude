using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollSwitch : MonoBehaviour    
{
    public CapsuleCollider mainCollider;
    public GameObject playerRig;
    public Animator playerAnim;

    private void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hitter") 
        {
            RagdollModeOn();
        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits() 
    {
        ragDollColliders = playerRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = playerRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn() 
    {   
        playerAnim.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

    }
    void RagdollModeOff() 
    {
        foreach (Collider col in ragDollColliders) 
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies) 
        {
            rigid.isKinematic = true;
        }

        playerAnim.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
