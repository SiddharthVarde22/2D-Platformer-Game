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
    [SerializeField]
    float footStepsSoundLoopTime = 0.3f;
    float currentTimeToCallFootStepSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
        ShowPlayerHealth();
        currentTimeToCallFootStepSound = footStepsSoundLoopTime;
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
        if (speedInput != 0)
        {
            currentTimeToCallFootStepSound += Time.deltaTime;
            if (currentTimeToCallFootStepSound >= footStepsSoundLoopTime)
            {
                SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.PlayerMove);
                currentTimeToCallFootStepSound = 0;
            }
        }
    }

    void PlayerJumpFunctionality()
    {
        if(jumpInput > 0)
        {
            if (Physics2D.Raycast(transform.position, -1 * transform.up, raycastDistance, platform_GroundLayer))
            {
                playerRigidBody2d.AddForce(transform.up * playerJumpForce, ForceMode2D.Force);
                SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.PlayerJump);
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
            SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.PlayerDeth);
            gameOverControllerrefrence.gameObject.SetActive(true);
            this.enabled = false;
        }
        else
        {
            SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.PlayerHurt);
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
