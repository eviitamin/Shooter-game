using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject Bullet;
    public Rigidbody2D rb;
    public int damage = 1;

    public Transform enemyVisual;
    private Animator _animator;
    private Vector3 _pos;
    private Vector2 _velocity;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        if (enemyVisual != null)
        {
            _animator = enemyVisual.GetComponent<Animator>();
            _spriteRenderer = enemyVisual.GetComponent<SpriteRenderer>();
            _pos = transform.position;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyVisual != null)
        {
            enemyVisual.rotation = Quaternion.Euler(0.0f, 0.0f, transform.rotation.z * -1.0f);

            //getting velocity without rigidbody
            _velocity = (transform.position - _pos) / Time.deltaTime;
            _pos = transform.position;
        }

        

    }

    private void FixedUpdate()
    {

        if (enemyVisual != null)
        {
            //animation
            if (_velocity == Vector2.zero)
            {
                _animator.speed = 0;
            }
            else
            {
                _animator.speed = 1f;
                if (_velocity.x < 0)
                {
                    _spriteRenderer.flipX = true;
                }
                else if (_velocity.x > 0)
                {
                    _spriteRenderer.flipX = false;
                }

            }
        }
            
    }
}