using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermanager : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    bool dead =false;
    Animator playerAnimation;
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AmIdead();
    }


        public void Getdamage(float damage)
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
            playerAnimation.SetBool("deadAnim", dead);
        }
    }


}