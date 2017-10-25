using UnityEngine;
using System.Collections;

public class backGround : MonoBehaviour {

    void Move()
    {
        transform.Translate(Game.speed * Vector2.left * Time.deltaTime);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Destroy(gameObject, Game.speed*1.5f);
	}
}
