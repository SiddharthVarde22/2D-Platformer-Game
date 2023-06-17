using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteDetector : MonoBehaviour
{
    [SerializeField]
    GameObject LevelCompletePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //play level complete sound
            SoundManager.SoundManagerInstance.PlaySoundEffects(SoundType.LevelComplete);
            //Mark this level as level complete and next level as unlocked level
            LevelManager.LevelManagerInstance.MarkLevelComplete();
            //load the level complete panel
            LevelCompletePanel.SetActive(true);
        }
    }
}
