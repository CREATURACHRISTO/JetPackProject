using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSequencer1 : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject playerCam;

    void Start()
    {
        StartCoroutine(CutsceneSequencer());
    }

    IEnumerator CutsceneSequencer ()
    {
        yield return new WaitForSeconds(3);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(2);
        playerCam.SetActive(true);
        cam2.SetActive(false);
    }
}
