using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyBehaviour : MonoBehaviour
{
    [SerializeField]
    Button continueButton, quitbutton, levelSelectionButton;
    [SerializeField]
    GameObject levelSelectionPanel;
    [SerializeField]
    LevelSaver levelSaver;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(OnContinuePlayButtonPressed);
        quitbutton.onClick.AddListener(OnQuitButtonPressed);
        levelSelectionButton.onClick.AddListener(OnSelectLevelButtonPressed);
    }

    public void OnContinuePlayButtonPressed()
    {
        SceneManager.LoadScene(levelSaver.GetSavedLastLevel());
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnSelectLevelButtonPressed()
    {
        levelSelectionPanel.SetActive(true);
    }
}
