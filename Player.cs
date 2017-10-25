using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //스피드 상수 정하기.
    public float m_center;
    public float jumpPower;

    public AudioClip jumpSound;
    public AudioClip dead;
    AudioSource sound;
    Game game;

    private bool isGround;
    private bool doubleJump = true;
    
    Animator ani;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider;
    RaycastHit2D ray;

    public LayerMask Ground;
    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        doubleJump = true;
	}
    //플레이어가 땅에 닿았는지 확인
    void CheckGround()
    {
        Vector2 chaGround;
        Vector2 areaGround;
        game = Game.game;

        ray = Physics2D.Raycast(transform.position - new Vector3(0, m_center * transform.localScale.y, 0)
            , Vector2.down,100,Ground);

        ani.SetFloat("height", ray.distance);

        chaGround = new Vector2(transform.position.x, transform.position.y - m_center * transform.localScale.y);
        areaGround = new Vector2(boxCollider.offset.x * 0.5f, 0.1f);

        isGround = Physics2D.OverlapArea(chaGround + areaGround, chaGround - areaGround, Ground);
        ani.SetBool("isGround", isGround);

        //땅에 닿으면 더블점프를 다시 사용 할 수 있도록 합니다.
        if (isGround && (!doubleJump)) doubleJump = true;
    }

    void CheckVelocity()
    {
        ani.SetFloat("velocityY", rigid.velocity.y);
    }
	
	// Update is called once per frame
	void Update () {
        CheckGround();
        CheckVelocity();

        if (transform.position.y < -4f)
        {
            if (sound.clip != dead)
            {
                sound.clip = dead;
                sound.Play();
            }
            game.gameOver(gameObject);
        }
        

        //스페이스바가 눌리면 점프 발동!
        if (Input.GetButtonDown("SPACE")&& isGround)
        {
            jump();
            sound.Stop();
            sound.clip  =jumpSound;
            sound.volume = 0.3f;
            sound.Play();
        }

        //더블점프
        else if (Input.GetButtonDown("SPACE") && doubleJump)
        {
            doubleJump = false;
            jump();
        }
    }

    //점프
    void jump()
    {
        Vector3 tmpVelocity;    
        tmpVelocity = rigid.velocity;
        tmpVelocity.y = jumpPower;
        rigid.velocity = tmpVelocity;
        sound.Stop();
        sound.clip = jumpSound;
        sound.volume = 0.3f;
        sound.Play();
    }
}
