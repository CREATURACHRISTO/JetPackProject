using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float thrust;
    public float torqueY;
    public float torqueX;

    private Rigidbody rb;

    private float currentSpeed;
    public float topSpeed;

    private GameObject respawnAnchor;

    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        respawnAnchor = GameObject.Find("RespawnAnchor");
        gameObject.transform.position = respawnAnchor.transform.position;
        rb.centerOfMass = new Vector3(0, 0.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;

        rb.drag = (currentSpeed / topSpeed);
        rb.AddRelativeForce(Vector3.up * thrust, ForceMode.Force);

        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.AddRelativeTorque(Vector3.right * torqueY * verticalInput);
        rb.AddRelativeTorque(Vector3.up * torqueX * horizontalInput);
    }

    private void Respawn()
    {
        transform.position = respawnAnchor.transform.position;
        transform.eulerAngles = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Respawn")
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log("Next level!");
        }
    }
}
