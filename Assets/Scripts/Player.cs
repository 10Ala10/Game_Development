using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float jumpSpeed = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float moveForce = 10f;
    private float movementX = 0f;
    [SerializeField]
    private Rigidbody2D rigidBody;
    private SpriteRenderer sr;
    private Collider2D cd;
    private Animator anim;
    private bool isGround = true;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    public GameOver gameOver;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cd = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        playerMovement();
        animePlayer();
        playerJump();

    }
    //  private void FixedUpdate()
    //  {
    //     playerJump();
    // }
    void playerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }
    void animePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            //transform.localScale = new Vector3(1, 1, 1);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            //transform.localScale = new Vector3(-1, 1, 1);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isGround = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            gameOver.gameover();



        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            gameOver.gameover();


        }

    }
}
