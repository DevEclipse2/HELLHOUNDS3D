using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    Vector2 movedir;
    float verticalRotation;
    float verticalRotationLim = 180f;
    float jumpF = 6;
    public float moveSpeed = 18;
    public GameObject camera;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool grounded;
    Rigidbody rb;
    public TextMeshProUGUI speedTMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value)
    {
        if (value != null)
        {
            movedir = value.Get<Vector2>();
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
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpF, rb.linearVelocity.z);
                }
            }
        }
    }
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
        speedTMP.text = ("Speed : " + rb.linearVelocity.magnitude + " m/s");
        ApplyMovement();
        grounded = GroundCheck();
    }
}
