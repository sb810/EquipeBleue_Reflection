using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int HPLeft;
    [SerializeField] private GameObject livingThing;


    public void TakeDamage(int damageAmout)
    {

        Debug.Log("HPLeft before taking damage: " + HPLeft);

        HPLeft -= damageAmout;

        Debug.Log("HPLeft after taking damage: " + HPLeft);

        if (HPLeft <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
       livingThing.SetActive(false);
    }
    
    void Start()
    {
        livingThing.SetActive(true);
        GetComponent<DamageSystem>();
    }

    public void Damage()
    {
        TakeDamage(1);
    }
    // Update is called once per frame
    
    
}
