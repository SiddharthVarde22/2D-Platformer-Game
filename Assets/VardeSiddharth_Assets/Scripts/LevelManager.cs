using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelStatus
{
    locked, unlocked, completed
}

public class LevelManager : MonoBehaviour
{
    static LevelManager levelManagerInstance;

    [SerializeField]
    string[] namesOfTheLevels;

    public static LevelManager LevelManagerInstance
    {
        get 
        { 
            return levelManagerInstance; 
        }
    }

    private void Awake()
    {
        if(levelManagerInstance == null)
        {
            levelManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /*
        //Only for testing
        //PlayerPrefs.DeleteAll();
        */
        SetFirstLevelStatus();
    }

    public void MarkLevelComplete()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, (int)LevelStatus.completed);
        index++;
        if(index < namesOfTheLevels.Length)
        {
            PlayerPrefs.SetInt(namesOfTheLevels[index], (int)LevelStatus.unlocked);
        }
    }

    void SetFirstLevelStatus()
    {
        if (PlayerPrefs.HasKey(namesOfTheLevels[0]) == false)
        {
            PlayerPrefs.SetInt(namesOfTheLevels[0], (int)LevelStatus.unlocked);
            PlayerPrefs.SetInt(namesOfTheLevels[1], (int)LevelStatus.unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string nameOfLevel)
    {
        return (LevelStatus)PlayerPrefs.GetInt(nameOfLevel, 0);
    }
}
