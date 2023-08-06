using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSequencer1 : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject playerCam;
    public GameObject focalPoint;

    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Jetpack");
        rb = player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(CutsceneSequencer());
    }

    IEnumerator CutsceneSequencer ()
    {
        yield return new WaitForSeconds(3);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(2);
        focalPoint.SetActive(true);
        playerCam.SetActive(true);
        cam2.SetActive(false);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}
