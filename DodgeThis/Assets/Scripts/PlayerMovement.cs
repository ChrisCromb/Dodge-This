using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float x;
    public float y;
    public Vector3 position;

    public float width;
    public float height;

    public float moveSpeed = 1f;

    void Awake()
    {
        width = (float)Screen.width/2f;
        height = (float)Screen.height/2f;

        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            /*Touch touch = Input.GetTouch(1);

            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;
            pos.y = (pos.y - height) / height;*/

            //Ray ray = new Ray 

            x = Input.mousePosition.x;
            y = Input.mousePosition.y;

            position = new Vector3((x - width) * 2.3474f / width, (y - height) * 5f / height, 0.0f);

            //Position the ship
            //transform.position = position;

            /*if(transform.position.x != position.x)
            {
                if(transform.position.x > position.x)
                {
                    transform.position = new Vector3(transform.position.x - (moveSpeed * 5 * Time.deltaTime), transform.position.y, 0);
                }
                else if(transform.position.x < position.x)
                {
                    transform.position = new Vector3(transform.position.x + (moveSpeed * 5 * Time.deltaTime), transform.position.y, 0);
                }
            }
            if (transform.position.y != position.y)
            {
                if (transform.position.y > position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - (moveSpeed * 5 * Time.deltaTime), 0);
                }
                else if (transform.position.y < position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * 5 * Time.deltaTime), 0);
                }
            }*/


            //Vector3.MoveTowards(transform.position, position, moveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * 5 * Time.deltaTime);
        }
    }

    
}
