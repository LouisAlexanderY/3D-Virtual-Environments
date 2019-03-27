using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlowersY : MonoBehaviour
{

    float dirY, moveSpeed = 3f;
    bool moveDown = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4f)
            moveDown = false;
        if (transform.position.y < -4f)
            moveDown = true;

        if (moveDown)
            transform.position = new Vector2(transform.position.y + moveSpeed * Time.deltaTime, transform.position.x);
        else
            transform.position = new Vector2(transform.position.y - moveSpeed * Time.deltaTime, transform.position.x);
    }
}
