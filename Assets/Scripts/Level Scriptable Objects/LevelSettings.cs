using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Level Settings" , fileName = "Level Settings")]
public class LevelSettings : ScriptableObject
{
    public int totalFire;
    public ParticleSystem confetti;
    public int collisionForFire;
}
