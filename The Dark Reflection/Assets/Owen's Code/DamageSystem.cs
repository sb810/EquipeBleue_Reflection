using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private Collider2D hurtingThing;
    [SerializeField] private GameObject theThingBeingHurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        if (collision == hurtingThing)
        
        {
            Debug.Log("hurt");
            HealthSystem healthSystem = theThingBeingHurt.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damageAmount);
            }
        }
    }
}
