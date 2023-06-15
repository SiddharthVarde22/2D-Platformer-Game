using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaver : MonoBehaviour
{
    string lastPlayedLevelKey = "lastPlayedLevelKey";

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SetLastPlayedLevel();
        }
    }

    public int GetSavedLastLevel()
    {
        if(PlayerPrefs.HasKey(lastPlayedLevelKey))
        {
            return PlayerPrefs.GetInt(lastPlayedLevelKey);
        }
        else
        {
            return 1;
        }
    }

    public void SetLastPlayedLevel()
    {
        PlayerPrefs.SetInt(lastPlayedLevelKey, SceneManager.GetActiveScene().buildIndex);
    }
}
