// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class attackzoneCheck : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private PlayerConroller playerParent;
//     
//     public int damageAmount ; // Hasar miktarını ayarlayın
//
//     private void Awake()
//     {
//         playerParent = GetComponentInParent<PlayerConroller>();
//     }
//         public void OnTriggerEnter2D(Collider2D collider)
//         {
//             if (collider.gameObject.CompareTag("Enemy"))
//             {
//                 DealDamage(collider.gameObject);
//             }
//         }
//
//         private void DealDamage(GameObject player)
//         {
//             // Oyuncuya hasar verme kodu buraya gelecek
//             // Örneğin:
//             player.GetComponent<EnemyBehaviour>().TakeDamage(damageAmount);
//         }
//     }
//
//
