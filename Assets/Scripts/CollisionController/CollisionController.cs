using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfObstacle{
    door,
    defaultObstacle
}

public class CollisionController : MonoBehaviour
{
    public ParticleSystem[] fireEffect;
    public TypeOfObstacle typeOfObstacle;

    private int _collisonCounter;


    private void OnParticleCollision(GameObject other) {
        _collisonCounter++;

        if (_collisonCounter >= 100)
        {
            for (int i = 0; i < fireEffect.Length; i++)
            {
                fireEffect[i].gameObject.SetActive(false);
            }
            if (typeOfObstacle == TypeOfObstacle.door)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject,1);

            }
        }
    }
}
