using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    
    public GameObject hand; 
    private Animator anim;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Punch");
        }
        
    }

    void Start()
    {
        anim = hand.GetComponent<Animator>();
    }

    public void AttackEnemy(GameObject enemy)
    {
        Ennemy enemyHealth = enemy.GetComponent<Ennemy>();
        if (enemyHealth != null)
        {
        enemyHealth.TakeDamage(1);
        }
    }

}