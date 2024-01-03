using EthanTheHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float damage;
    public float maxHealth = 100; // D��man�n maksimum sa�l�k de�eri
    private float currentHealth; // Mevcut sa�l�k de�eri
    public int comboAttack = 0;

    Animator Enemyanim;

    // D��man�n maksimum sa�l�k de�eri


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
        // D��man�n �l�m i�lemleri burada yap�l�r
        Debug.Log("Enemy died!");
    
        Enemyanim.SetTrigger("dead");

       
    }
}
