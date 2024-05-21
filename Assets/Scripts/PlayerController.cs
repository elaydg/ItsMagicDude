using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 2f;
    public float rotationSpeed = 10.0f;
    private Rigidbody rb;
    private Animator animator;

    private PlayerInputController input;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;
    public float rotationSpeedMultiplier = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        input = GetComponent<PlayerInputController>();
        if (input == null)
        {
            Debug.LogError("PlayerInputController component is missing on this GameObject.");
        }

        if (cameraFollowTarget == null)
        {
            Debug.LogError("cameraFollowTarget is not assigned!");
        }

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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrawling", true);
        }
        else
        {
            animator.SetBool("isCrawling", false);
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
}
