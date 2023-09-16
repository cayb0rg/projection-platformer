using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Transitions the camera between two different cameras
public class SwitchLevel : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    public int transitionTime = 0;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator transition(CinemachineVirtualCamera camera)
    {
        yield return new WaitForSeconds(transitionTime);

        // Enable POV camera
        if (camera != null)
            camera.enabled = true;
        
        foreach (CinemachineVirtualCamera cam in cameras)
        {
            if (cam != camera) {
                cam.enabled = false;
            }
        }
    }

    public void switchToLevel(int level)
    {
        StartCoroutine(transition(cameras[level]));
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Door")
        {
            switchToLevel(1);
        }
    }
}