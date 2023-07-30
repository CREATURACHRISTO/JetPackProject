using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jetpack");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = player.transform.position;

        Transform.Rotate(Vector3.up, );
    }
}
