using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    float playerMovementSpeed = 5f;
    [SerializeField]
    float playerJumpForce = 3f;
    [SerializeField]
    LayerMask platform_GroundLayer;
    [SerializeField]
    float raycastDistance = 0.25f;

    float speedInput;
    float jumpInput;
    bool isCrouching = false;
    Vector3 playerLocalScale;

    Rigidbody2D playerRigidBody2d;

    [SerializeField]
    ScoreController scoreControllerRefrence;

    [SerializeField]
    int playerHealth = 3;
    [SerializeField]
    TextMeshProUGUI playerHealthText;

    [SerializeField]
    GameOverController gameOverControllerrefrence;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
        ShowPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetAxisRaw("Vertical");

        PlayerMovementsFunctionality();
        PlayerJumpFunctionality();

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

    void PlayerJumpFunctionality()
    {
        if(jumpInput > 0)
        {
            if (Physics2D.Raycast(transform.position, -1 * transform.up, raycastDistance, platform_GroundLayer))
            {
                playerRigidBody2d.AddForce(transform.up * playerJumpForce, ForceMode2D.Force);
            }
        }
    }

    void PlayerCrouchFunctionality()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = !isCrouching;

            playerAnimator.SetBool("IsCrouched", isCrouching);
        }
    }

    public void OnKeyCollected(int pointsToAdd)
    {
        scoreControllerRefrence.AddScore(pointsToAdd);
    }

    public void ReducePlayerHealth()
    {
        playerHealth--;
        ShowPlayerHealth();

        if(playerHealth <= 0)
        {
            gameOverControllerrefrence.gameObject.SetActive(true);
            this.enabled = false;
        }
    }

    void ShowPlayerHealth()
    {
        playerHealthText.text = "Health : " + playerHealth;
    }

    public void ReloadTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
