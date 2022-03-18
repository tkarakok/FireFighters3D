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
    #endregion

    #region EnCapsullation
    public int TotalFire { get => _totalFire; set => _totalFire = value; }
    public ParticleSystem Confetti { get => _confetti; set => _confetti = value; }
    public int CollisionForFire { get => _collisionForFire; set => _collisionForFire = value; }
    #endregion

    private void Start()
    {
        Confetti = levelSettings.confetti;
        TotalFire = levelSettings.totalFire;
        CollisionForFire = levelSettings.collisionForFire;
    }

}
