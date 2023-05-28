using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform character_pos;
    public float speed = 0.025f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y + (speed * 2));
            }
            else
            {
                character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y + speed);
            }
            
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y - (speed * 2));
            }
            else
            {
                character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y - speed);
            }

                
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                character_pos.position = new Vector2(character_pos.position.x + (speed * 2), character_pos.position.y);
            }
            else
            {
                character_pos.position = new Vector2(character_pos.position.x + speed, character_pos.position.y);
            }
                
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                character_pos.position = new Vector2(character_pos.position.x - (speed * 2), character_pos.position.y);
            }
            else
            {
                character_pos.position = new Vector2(character_pos.position.x - speed, character_pos.position.y);
            }
                
        }
    }
}
