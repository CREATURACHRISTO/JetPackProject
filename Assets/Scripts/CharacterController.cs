using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float thrust;
    public float torque;

    private Rigidbody rb;

    private float currentSpeed;
    public float topSpeed;

    private GameObject respawnAnchor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        respawnAnchor = GameObject.Find("RespawnAnchor");
        gameObject.transform.position = respawnAnchor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;

        rb.drag = (currentSpeed / topSpeed);
        rb.AddRelativeForce(Vector3.up * thrust, ForceMode.Force);
    }
}
