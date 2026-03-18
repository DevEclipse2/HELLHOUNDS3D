using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class Main : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    public Transform groundCheck;
    public Transform GCheckArea;
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
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.5f, groundLayer);
        return Physics.BoxCast(groundCheck.position, GCheckArea.localScale, Vector3.zero , Quaternion.LookRotation(Vector3.down), 0, groundLayer);
    }
    public void OnJump(InputValue value)
    {
        if (value != null) 
        {
            if (value.isPressed)
            {
                Debug.Log("Jump");
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, JumpF , rb.linearVelocity.z);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 horispeed = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z);
        Debug.Log(horispeed.magnitude);
        camera.GetComponent<Camera>().fieldOfView = ((maxFov - minFov) * horispeed.magnitude / speedMaxFov) + minFov;
        if (grounded = GroundCheck())
        {
            Vector3 movement = transform.forward * movedir.y * moveSpeed + transform.right * movedir.x * moveSpeed;

            if (horispeed.magnitude < moveSpeed)
            {
                //Debug.Log("accelerate");
                rb.AddForce(movement * 8 * 0.33f);
            }
            //else
            //{
            //    rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
            //}
        }
        else
        {
            rb.AddForce(transform.forward * AirStrafespeed * Time.deltaTime);
        }
    }
}
