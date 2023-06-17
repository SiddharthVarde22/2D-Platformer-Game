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
        SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.ButtonClick);
        SceneManager.LoadScene(levelSaver.GetSavedLastLevel());
    }

    public void OnQuitButtonPressed()
    {
        SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.ButtonClick);
        Application.Quit();
    }

    public void OnSelectLevelButtonPressed()
    {
        SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.ButtonClick);
        levelSelectionPanel.SetActive(true);
    }
}
