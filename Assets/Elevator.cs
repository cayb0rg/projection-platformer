using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Elevator : MonoBehaviour
{
    public GameObject player;
    // public Rigidbody2D rb2D;
    public Vector2 velocity;
    public PlayableDirector directorUp;
    public PlayableDirector directorDown;
    // public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(1.75f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Player") {
            directorUp.Play();
        }
    }
    void OnCollisionExit2D(Collision2D collider) {
        if (collider.gameObject.tag == "Player") {
            directorDown.Play();
        }
    }
}
