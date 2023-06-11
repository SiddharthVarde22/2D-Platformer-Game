using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public BoxCollider2D playerBoxCollider;
    public Vector2 boxColliderSizeWhenCrouched, boxColliderSizeWhenStanding, offsetWhileCrouched, offsetWhileStanding;

    public float playerMovementSpeed = 5f;

    float speedInput;
    float jumpInput;
    bool isCrouching = false;
    Vector3 playerLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetAxisRaw("Vertical");

        PlayerMovementsFunctionality();

        MovementAnimation();
        PlayerCrouchFunctionality();
        
    }

    void MovementAnimation()
    {
        playerAnimator.SetFloat("Speed", Mathf.Abs(speedInput));
        playerAnimator.SetFloat("Jump", jumpInput);

        playerLocalScale = transform.localScale;

        if (speedInput < 0)
        {
            playerLocalScale.x = -1 * Mathf.Abs(playerLocalScale.x);
        }
        else if (speedInput > 0)
        {
            playerLocalScale.x = Mathf.Abs(playerLocalScale.x);
        }

        transform.localScale = playerLocalScale;
    }

    void PlayerMovementsFunctionality()
    {
        transform.position += (transform.right * speedInput * playerMovementSpeed * Time.deltaTime);
    }

    void PlayerCrouchFunctionality()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = !isCrouching;

            playerAnimator.SetBool("IsCrouched", isCrouching);

            if (isCrouching)
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
