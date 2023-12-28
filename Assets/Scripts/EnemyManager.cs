using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    bool dead =false;
    Animator playerAnimation;
    private EnemyBehaviour enemyParent;
    

    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyBehaviour>();
    }
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AmIdead();
    }


    public void TakeDamage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;

        }
        else
        {
            health = 0;
        }
        AmIdead();
    }
    void AmIdead()
    {
        if (health <= 0)
        {
            dead = true;
            playerAnimation.SetTrigger("isDead");
            playerAnimation.SetBool("isWalk",false);
            playerAnimation.SetBool("isAttack",false);
            playerAnimation.SetBool("isBite",false);
            enemyParent.moveSpeed = 0;
            Destroy(gameObject, 5);
        }
    }
        


}