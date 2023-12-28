using EthanTheHero;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PlayerConroller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidPlayer;
    Animator PlayerAnimation;
  
    public float hiz = 1f;
    bool facingRight = true;

    public float JumpSpeed = 1f,  JumpTime;
    public float JumpFrekans = 1f;
    public bool isGronded = false;
    public float attackdamage;
    public float AttackRange=0.5f;
    public LayerMask enemyLayer;

    public Transform groundposition;
    public Transform Attackpoint;
    public float cap;
    public LayerMask layercheck;

    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGraounded();
        rigidPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * hiz, rigidPlayer.velocity.y);

        if (rigidPlayer.velocity.x < 0 && facingRight)
        {
            flipFace();
        }
        else if (rigidPlayer.velocity.x > 0 && !facingRight)
        {
            flipFace();
        }
        if (Input.GetAxis("Vertical") > 0 && isGronded && (JumpTime < Time.timeSinceLevelLoad))
        {
            JumpTime = Time.timeSinceLevelLoad +JumpFrekans;
            PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerAnimation.SetTrigger("Attackanim");
            Attack();
        }

    }
    void HorizontalMove()
    {
        rigidPlayer.velocity = new Vector2(Input.GetAxis("Horizontal"), rigidPlayer.velocity.y);
        PlayerAnimation.SetFloat("PlayerSpeed", Mathf.Abs(rigidPlayer.velocity.x));
    }
    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocakScaele = transform.localScale;
        tempLocakScaele.x *= -1;
        transform.localScale = tempLocakScaele;
    }
    void PlayerJump()
    {
        rigidPlayer.AddForce(new Vector2(0f, JumpSpeed));
    }
    void OnGraounded()
    {
        isGronded = Physics2D.OverlapCircle(groundposition.position, cap, layercheck);
        PlayerAnimation.SetBool("isGrounded", isGronded);
    }


    // ReSharper disable Unity.PerformanceAnalysis
    void Attack()
    {
        // Düþmanlarý tespit et
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, AttackRange, enemyLayer);

        // Her tespit edilen düþmana hasar ver
        foreach (Collider2D enemy in hitEnemies)
        {
            // Düþmanýn saðlýk bileþenini al
            EnemyManager health = enemy.GetComponent<EnemyManager>();

            if (health != null)
            {
                // Hasarý düþmana uygula
                enemy.GetComponent<EnemyManager>().TakeDamage(attackdamage);
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position, AttackRange);
    }





}
