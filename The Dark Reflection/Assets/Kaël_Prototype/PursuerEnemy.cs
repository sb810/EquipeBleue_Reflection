using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuerEnemy : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Pursuit", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pursuit(Transform enemy)
    {
        

        while (enemy.position != target.position)
        {
            while (enemy.position.x != target.position.x)
            {
                if(target.position.x < 0f) 
                {
                    enemy.position = new Vector2(enemy.position.x - 1, enemy.position.y);
                }

                else
                {
                    enemy.position = new Vector2(enemy.position.x + 1, enemy.position.y);
                }
                
            }

            
        }
    }
}
