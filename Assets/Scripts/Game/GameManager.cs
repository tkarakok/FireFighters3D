using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public LevelSettings levelSettings;

    #region Private Fields
    private int _totalFire;
    private ParticleSystem _confetti;
    private int _collisionForFire;
    private int _activeFireCounter;
    #endregion

    #region EnCapsullation
    public int TotalFire { get => _totalFire; set => _totalFire = value; }
    public ParticleSystem Confetti { get => _confetti; set => _confetti = value; }
    public int CollisionForFire { get => _collisionForFire; set => _collisionForFire = value; }
    public int ActiveFireCounter { get => _activeFireCounter; set => _activeFireCounter = value; }
    #endregion

    private void Start()
    {
        Confetti = levelSettings.confetti;
        TotalFire = levelSettings.totalFire;
        CollisionForFire = levelSettings.collisionForFire;
        ActiveFireCounter = 0;
    }

    public void UpdateActiveFire(){
        ActiveFireCounter += 1;
        // WE CHECK TOTAL FIRE FOR END GAME
        if (ActiveFireCounter == TotalFire)
        {
            EventManager.Instance.EndGame();
        }
    }

}
