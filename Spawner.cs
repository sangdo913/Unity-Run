using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private GameObject[] block;

    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public LayerMask BG;
    private RaycastHit2D ray;

    public int numberOfGameObject;

	// Use this for initialization
	void Start () {
        block = new GameObject[numberOfGameObject];

        block[0] = block1;
        block[1] = block2;
        block[2] = block3;
        block[3] = block4;
    }

    void CheckDistance()
    {
        ray = Physics2D.Raycast(transform.position, Vector2.left, 100, BG);

        if(ray.distance>9.23576f)
        {
            Instantiate(block[Random.Range(0, numberOfGameObject)], transform.position + Vector3.left * Game.speed * Time.deltaTime, transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {

        CheckDistance();
        CheckDistance();
	}
}
