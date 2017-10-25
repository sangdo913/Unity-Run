using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static Score mscore;
    int score;
    float waitTime = 0;
    private Text text;

    //싱글톤
    public static Score instance
    {
        get
        {
            if (mscore == null)
                return FindObjectOfType<Score>();
            else return mscore;
        }
    }

    public void add()
    {
        score+=5;
    }

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        // 0.3초마다 스코어 1씩 증가
        waitTime += Time.deltaTime;
        if (waitTime > 0.3f)
        {
            score += (int)Game.speed/4;
            waitTime = 0;
        }

        string displayScore = score.ToString("0000");
        text.text = "Score : " + displayScore;
        
	}
}
