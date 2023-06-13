using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PetrolBehaviour : MonoBehaviour
{
    [SerializeField]
    float maxLeftDiatanceToTravel = 2, maxRightDistanceToTravel = 2, moveSpeed = 2;

    float maxLeftXPosition, maxRightXPosition;
    bool isMovingLeft;
    // Start is called before the first frame update
    void Start()
    {
        maxLeftXPosition = transform.position.x - maxLeftDiatanceToTravel;
        maxRightXPosition = transform.position.x + maxRightDistanceToTravel;
    }

    // Update is called once per frame
    void Update()
    {
        Petrol();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerControllerRefrence = null;

        if(collision.gameObject.TryGetComponent<PlayerController>(out playerControllerRefrence))
        {
            //Reload the level
            playerControllerRefrence.ReloadTheLevel();
        }
    }

    void Petrol()
    {
        if(isMovingLeft == true)
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;

            if(transform.position.x <= maxLeftXPosition)
            {
                isMovingLeft = false;
            }
        }
        else
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;

            if(transform.position.x >= maxRightXPosition)
            {
                isMovingLeft = true;
            }
        }
    }
}
