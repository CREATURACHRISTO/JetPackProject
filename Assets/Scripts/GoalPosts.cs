using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPosts : MonoBehaviour
{
    public GameObject nextPost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nextPost.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
