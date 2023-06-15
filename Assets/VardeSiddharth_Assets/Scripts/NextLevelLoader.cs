using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public string nameOfTheLevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Mark this level as level complete and next level as unlocked level
            LevelManager.LevelManagerInstance.MarkLevelComplete();
            //Load the next level
            SceneManager.LoadScene(nameOfTheLevelToLoad);
        }
    }
}
