using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;

    float speed;
    Vector3 playerLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal");

        playerAnimator.SetFloat("Speed", Mathf.Abs(speed));

        playerLocalScale = transform.localScale;

        if(speed < 0)
        {
            playerLocalScale.x = -1 * Mathf.Abs(playerLocalScale.x);
        }
        else if(speed > 0)
        {
            playerLocalScale.x = Mathf.Abs(playerLocalScale.x);
        }

        transform.localScale = playerLocalScale;
    }
}
