using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class size : MonoBehaviour {
    const float scrWidth = 1280;
    const float scrHeight = 720;
    float scaleX;
    float scaleY;

    const float msgX = 670;
    const float msgY = 100;

    float msgPosX;
    float msgPosY;

    RectTransform rect;

    // Use this for initialization
    void Start () {
        calScale();
        rect = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        rect.position = new Vector3(msgPosX, msgPosY, 0);
        if(Input.GetButtonDown("SELECT"))
        {
            SceneManager.LoadScene("Stage");
        }
    }

    void calScale()
    {
        scaleX = Screen.width / scrWidth;
        scaleY = Screen.height / scrHeight;

        msgPosX = msgX * scaleX;
        msgPosY = msgY * scaleY;
    }
}
