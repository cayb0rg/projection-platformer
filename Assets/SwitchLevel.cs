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
    public GameObject door;
    public GameObject textObject; 
    public Key key;
    bool canFlip = false;
    public GameObject image;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canFlip) {
            switchToLevel(1);
            canFlip = false;
        }
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

        // Show background
        if (image != null) {
            image.SetActive(true);
        }

        // Move player
        player.transform.position = door.transform.position;

        // Disable text object
        textObject.SetActive(false);
    }

    public void switchToLevel(int level)
    {
        StartCoroutine(transition(cameras[level]));
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (key.hasKey) {
            // Show text
            textObject.SetActive(true);
            canFlip = true;
        }
        // if (collision.gameObject.tag == "Player")
        // {
        //     switchToLevel(1);
        // }
    }

    void OnTriggerExit2D(Collider2D collision) {
        textObject.SetActive(false);
        canFlip = false;
    }
}