using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
    private static Game mgame;
    public static float speed = 5f;

    public GameObject character;

    float waitTime = 0;

    int score;

    //기준 해상도 설정
    float chaXAxis = -7;
    float chaYAxis = 1;

    //사용자 지정 해상도 설정
    float CXAxis;
    //싱글톤
    public static Game game
    {
        get
        {
            if (mgame == null)
            {
                mgame = FindObjectOfType<Game>();
            }
            return mgame;
        }
        set
        { }
    }
    
    // Use this for initialization
    void Start()
    {
        Instantiate(character, new Vector2(chaXAxis, chaYAxis), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //시간이 지날때마다 속도 상승
        waitTime += Time.deltaTime;
        if (waitTime > 10f)
        {
            speed += 1;
            waitTime = 0;
        }
    }

    //게임오버 함수
    public void gameOver(GameObject character)
    {
        AudioSource sound = character.GetComponent<AudioSource>();        
        if(!sound.isPlaying)
            SceneManager.LoadScene("GameOver");
    }
}
