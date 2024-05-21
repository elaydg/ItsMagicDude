using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float rotationSpeed = 10.0f;
    public float originalSpeed;

    private Rigidbody rb;
    private Animator animator;
    private CapsuleCollider capsuleCollider;

    private PlayerInputController input;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;
    public float rotationSpeedMultiplier = 0.1f;

    private bool canCrawl = false;
    private bool canFaster = false;
    private float originalColliderHeight;
    private Vector3 originalColliderCenter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        input = GetComponent<PlayerInputController>();
        if (input == null)
        {
            Debug.LogError("PlayerInputController component is missing on this GameObject.");
        }

        if (cameraFollowTarget == null)
        {
            Debug.LogError("cameraFollowTarget is not assigned!");
        }

        // Orijinal collider boyutlarýný ve merkezini kaydet
        if (capsuleCollider != null)
        {
            originalColliderHeight = capsuleCollider.height;
            originalColliderCenter = capsuleCollider.center;
        }

        originalSpeed = movementSpeed;

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        var movementDirection = cameraForward * vertical + Camera.main.transform.right * horizontal;
        movementDirection.Normalize();

        //var movementDirection = new Vector3(horizontal, 0, vertical);

        animator.SetBool("isWalking", movementDirection != Vector3.zero);

        if (Input.GetKey(KeyCode.LeftControl) && canCrawl)
        {
            animator.SetBool("isCrawling", true);
            capsuleCollider.height = 0.27f;
            capsuleCollider.center = new Vector3(-0.006540656f, 0.72f, 0.00657028f);
        }
        else
        {
            animator.SetBool("isCrawling", false);
            capsuleCollider.height = originalColliderHeight;
            capsuleCollider.center = originalColliderCenter;
        }

        if (Input.GetKey(KeyCode.LeftShift) && canFaster)
        {
            movementSpeed = 4f; // Hýz artýr
        }
        else
        {
            movementSpeed = originalSpeed; // Orijinal hýza dön
        }

        if (movementDirection == Vector3.zero)
        {
            Debug.Log("input doesn't exist.");
            rb.velocity = Vector3.zero;
            return;
        }

        rb.velocity = movementDirection * movementSpeed;

        var rotationDirection = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);


    }


    private void LateUpdate()
    {
        cameraRotation();
    }
    void cameraRotation()
    {
        if (input == null)
        {
            Debug.LogError("PlayerInputController is not assigned.");
            return;
        }
        xRotation += input.look.y * rotationSpeedMultiplier;
        yRotation += input.look.x * rotationSpeedMultiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cameraFollowTarget.rotation = rotation;
    }

    public void EnableCrawling() 
    {
        canCrawl = true;
    }

    public void Faster() 
    {
        canFaster = true;
    }

}
