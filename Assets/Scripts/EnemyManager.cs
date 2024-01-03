using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damage;
    public float maxHealth = 100; // Düþmanýn maksimum saðlýk deðeri
    private float currentHealth; // Mevcut saðlýk deðeri
    public int comboAttack = 0;

    Animator Enemyanim;

    // Düþmanýn maksimum saðlýk deðeri


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Enemyanim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Playermanager>().Getdamage(damage);

        }


    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Enemyanim.SetTrigger("Hurtenemy");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Düþmanýn ölüm iþlemleri burada yapýlýr
        Debug.Log("Enemy died!");
    
        Enemyanim.SetTrigger("dead");

       
    }
}
