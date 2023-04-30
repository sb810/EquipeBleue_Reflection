using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int currentHealth = 50;
    public GameObject enemy; 
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
            // TODO: Add death or defeat logic here
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            TakeDamage(collision.gameObject.GetComponent<AttackDamage>().damageAmount);
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
