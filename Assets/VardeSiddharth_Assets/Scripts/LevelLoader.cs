using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    string levelName;

    Button buttonComponent;
    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(OnLoadLevelPressed);
    }

    public void OnLoadLevelPressed()
    {
        SceneManager.LoadScene(levelName);
    }
}
