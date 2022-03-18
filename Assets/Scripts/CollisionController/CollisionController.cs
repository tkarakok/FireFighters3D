using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum TypeOfObstacle
{
    door,
    defaultObstacle
}

public class CollisionController : MonoBehaviour
{
    public ParticleSystem[] fireEffect;
    public TypeOfObstacle typeOfObstacle;
    public Image bar;

    private int _collisonCounter;
    private bool _fire = true;

    private void Start() {
        bar.fillAmount = 1;
    }

    private void OnParticleCollision(GameObject other)
    {
        
        if (_fire)
        {
            _collisonCounter++;
            bar.fillAmount = 1 - ((float)_collisonCounter / (float)GameManager.Instance.CollisionForFire);
            if (_collisonCounter >= GameManager.Instance.CollisionForFire)
            {
                for (int i = 0; i < fireEffect.Length; i++)
                {
                    fireEffect[i].gameObject.SetActive(false);
                    GameObject confetti = Instantiate(GameManager.Instance.Confetti.gameObject);
                    confetti.transform.position = fireEffect[0].transform.position;
                    confetti.GetComponent<ParticleSystem>().Play();
                    _fire = false;
                }
                if (typeOfObstacle == TypeOfObstacle.door)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(gameObject, 1);

                }
            }
        }

    }
}
