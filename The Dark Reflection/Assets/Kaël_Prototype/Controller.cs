using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform character_pos;
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
        while(Input.GetKey(KeyCode.UpArrow))
        {
            character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y + 1);
        }

        while(Input.GetKey(KeyCode.DownArrow))
        {
            character_pos.position = new Vector2(character_pos.position.x, character_pos.position.y- 1);
        }

        while(Input.GetKey(KeyCode.RightArrow))
        {
            character_pos.position = new Vector2(character_pos.position.x + 1, character_pos.position.y);
        }

        while(Input.GetKey(KeyCode.LeftArrow))
        {
            character_pos.position = new Vector2(character_pos.position.x - 1, character_pos.position.y);
        }
    }
}
