using UnityEngine;

public class PlayerStuff : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField] bool grounded;
    [SerializeField] Transform myCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 camForward = myCamera.forward;
        Vector3 camRight = myCamera.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelativeMovementVector = yInput * camForward;
        Vector3 rightRelativeMovementVector = xInput * camRight;


        movement = new Vector3(xInput, 0, yInput) * speed * Time.deltaTime;
        movement.y = rb.linearVelocity.y;

        grounded = Physics.Raycast(transform.position, Vector3.down, 1);


        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


        if(xInput != 0 && yInput != 0)
        {
        transform.forward = new Vector3(xInput, 0, yInput);
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }


}
