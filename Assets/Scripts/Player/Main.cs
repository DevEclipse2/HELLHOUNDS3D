using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Main : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    public Transform groundCheck;
    public GameObject weapon;
    Gun gun;
    public TextMeshProUGUI speedTMP;
    public float moveSpeed;
    public float JumpF;
    public bool movable;
    public bool jumping;
    public float CurrentSpeed;
    public float AirStrafespeed;
    public bool airstrafing;
    public bool grounded;
    public Vector2 movedir;
    public LayerMask groundLayer;
    float verticalRotation;
    float verticalRotationLim = 180;
    public GameObject camera;
    public int minFov;
    public int maxFov;
    public float speedMaxFov;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gun = weapon.GetComponent<Gun>();
    }
    public void OnMove(InputValue value)
    {
        if (value != null)
        {
            movedir = value.Get<Vector2>();
        }
    }
    public void OnAttack(InputValue val)
    {
        if (val.isPressed)
        {
            gun.Shoot();


        }
    }
    public void OnLook(InputValue value)
    {
        //Debug.Log("look");
        float mouseX = value.Get<Vector2>().x;
        float mouseY = value.Get<Vector2>().y;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLim, verticalRotationLim);
        camera.transform.localRotation = Quaternion.Euler(verticalRotation * 0.4f + camera.transform.localRotation.x, 0, 0);
        transform.Rotate(0, mouseX * 0.4f, 0);
    }

    public bool GroundCheck()
    {
        
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.5f, groundLayer) || Physics.Raycast(groundCheck.position, Vector3.up, 0.5f, groundLayer);
    }
    public void OnJump(InputValue value)
    {
        if (value != null) 
        {
            if (value.isPressed)
            {
                if (grounded)
                {
                    Debug.Log("Jump");
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, JumpF, rb.linearVelocity.z);
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void ApplyMovement()
    {

        Vector3 playerSpeed = Quaternion.Inverse(transform.rotation) * rb.linearVelocity;
        if (grounded)
        {
            playerSpeed.z += movedir.y * moveSpeed;
            playerSpeed.x += movedir.x * moveSpeed;

            if (movedir.y == 0)
            {
                playerSpeed.z = playerSpeed.z * 0.92f;
            }
            else
            {
                playerSpeed.z -= playerSpeed.z * 0.4f;
            }
            if (movedir.x == 0)
            {
                playerSpeed.x = playerSpeed.x * 0.92f;
            }
            else
            {
                playerSpeed.x -= playerSpeed.x * 0.4f;
            }
        }
        else
        {
        }
        rb.linearVelocity = transform.rotation * playerSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        speedTMP.text = ("Speed : " + Mathf.FloorToInt( rb.linearVelocity.magnitude * 1000) + " m/s");
        grounded = GroundCheck();
        ApplyMovement();
    }
}
