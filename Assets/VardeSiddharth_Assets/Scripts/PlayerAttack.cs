using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_PetrolBehaviour enemy_PetrolBehaviour = null;

        if(collision.TryGetComponent<Enemy_PetrolBehaviour>(out enemy_PetrolBehaviour))
        {
            enemy_PetrolBehaviour.EnemyDie();
        }
    }
}
