using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyBehaviour : MonoBehaviour
{
    [SerializeField]
    Button playButton, quitbutton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonPressed);
        quitbutton.onClick.AddListener(OnQuitButtonPressed);
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
