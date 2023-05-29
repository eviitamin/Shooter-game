using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Weapon2 weapon2;

    //
    [SerializeField] private Transform weaponParent;
    public Vector3 aimDirection;
    private float aimAngle;

    Vector2 moveDirection;
    Vector2 mousePosition;


    //Animation
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;  //added
    private const string IS_IDLE = "idle";
    private const string IS_RUN = "run";

    //swap weapon
    private bool _isGun = true;
    public SpriteRenderer pistolSprite;
    public SpriteRenderer knifeSprite;

    //start screen
    public GameObject gameStartScreen;

    //end screen
    public GameObject endScreen;

    private void Awake()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();  //added
    }

    private void Start()
    {
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //
        AimInput();

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            _isGun = true;
            weapon.Fire();
        }
        if(Input.GetMouseButtonDown(1)){
            _isGun = false;
            weapon2.Fire();
        }

        if (_isGun)
        {
            pistolSprite.enabled = true;
            knifeSprite.enabled = false;
        }
        else
        {
            pistolSprite.enabled = false;
            knifeSprite.enabled = true;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   
    }   

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;  //faces towards target
        weaponParent.eulerAngles = new Vector3(0, 0, aimAngle);

        //animation
        if (rb.velocity == Vector2.zero)
        {
            _animator.Play(IS_IDLE);
        }
        else
        {
            //added
            if (moveDirection.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (moveDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }

            _animator.Play(IS_RUN);
        }

        //FlipWeapon();

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Bullet")){
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    //
    private void AimInput()
    {
        Vector3 adjustedMousePosition = mousePosition;
        aimDirection = (adjustedMousePosition - transform.position).normalized;
    }

    public void StartGame() //added
    {
        gameStartScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("goal"))
        {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    // private void FlipWeapon()   
    // {
    //     //flip weapon image if aiming to left or right
    //     Vector3 aimLocalScale = Vector3.one;
    //     if (aimAngle > 90 || aimAngle < -90)
    //     {
    //         aimLocalScale.y = -1f;
    //     }
    //     else
    //     {
    //         aimLocalScale.y = +1f;
    //     }
    //     pistolSprite.transform.localScale = aimLocalScale;
    // }
}
