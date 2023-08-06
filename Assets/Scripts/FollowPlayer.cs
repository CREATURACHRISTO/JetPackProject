using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private float horizontalInput;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jetpack");
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Mouse X");

        gameObject.transform.position = player.transform.position;

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
