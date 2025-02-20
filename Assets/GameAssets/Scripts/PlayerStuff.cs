using UnityEngine;

public class PlayerStuff : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    Rigidbody rb;
    Vector3 movement;


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

        movement = new Vector3(xInput, 0, yInput) * speed * Time.deltaTime;
        movement.y = rb.linearVelocity.y;

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }


}
