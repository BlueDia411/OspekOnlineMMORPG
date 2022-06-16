using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Camera _mainCamera;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        MovementHandle();

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Mouse looking left & right
        Vector3 rotationY = transform.localEulerAngles;
        rotationY.y += mouseX;
        transform.localRotation = Quaternion.AngleAxis(rotationY.y, Vector3.up);

        // Mouse looking up & down
        Vector3 rotationX = _mainCamera.gameObject.transform.localEulerAngles;
        rotationX.x -= mouseY;
        _mainCamera.gameObject.transform.localRotation = Quaternion.AngleAxis(rotationX.x, Vector3.right);
    }

    void movement() {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    private void MovementHandle()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Mag", 1f);
        }
        else
        {
            anim.SetFloat("Mag", 0f);
        }
    }
}
