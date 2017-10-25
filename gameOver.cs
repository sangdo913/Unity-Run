using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameOver : MonoBehaviour {
    float waitTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        waitTime += Time.deltaTime;
        //게임오버 화면 3초 뒤부터 작동, 엔터를 누르면 로딩화면으로 이동
        if (Input.GetButtonDown("SELECT")&& waitTime > 3f)
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
