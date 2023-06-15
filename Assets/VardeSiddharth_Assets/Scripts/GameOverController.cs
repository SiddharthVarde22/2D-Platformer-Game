using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(OnRestartButtonPressed);
    }

    public void OnPlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
