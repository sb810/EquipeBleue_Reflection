using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    
    [SerializeField] private int currentHealth = 100;
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            // TODO: Add game over or death logic here
        }
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthSystem health = GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}
