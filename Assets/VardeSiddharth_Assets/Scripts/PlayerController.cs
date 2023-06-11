using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public BoxCollider2D playerBoxCollider;
    public Vector2 boxColliderSizeWhenCrouched, boxColliderSizeWhenStanding, offsetWhileCrouched, offsetWhileStanding;

    float speed;
    float jump;
    bool isCrouching = false;
    Vector3 playerLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Speed", Mathf.Abs(speed));
        playerAnimator.SetFloat("Jump", jump);

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

        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = !isCrouching;

            playerAnimator.SetBool("IsCrouched", isCrouching);

            if(isCrouching)
            {
                playerBoxCollider.size = boxColliderSizeWhenCrouched;
                playerBoxCollider.offset = offsetWhileCrouched;
            }
            else
            {
                playerBoxCollider.size = boxColliderSizeWhenStanding;
                playerBoxCollider.offset = offsetWhileStanding;
            }
        }
    }
}
