using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
    public AudioClip get;
    AudioSource sound;
    Score score;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        score = Score.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            score.add();
            sound.clip = get;
            sound.volume = 0.1f;
            sound.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject,get.length);
        }
    }
}
