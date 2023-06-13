using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Key : MonoBehaviour
{
    [SerializeField]
    int poitntsToAdd = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerRefrence = null;

        if(collision.gameObject.TryGetComponent<PlayerController>(out playerRefrence))
        {
            //Add points to the player
            playerRefrence.OnKeyCollected(poitntsToAdd);
            //delete gameobject(Self)
            Destroy(gameObject);
        }
    }
}
