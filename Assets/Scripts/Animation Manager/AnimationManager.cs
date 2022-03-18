using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Singleton<AnimationManager>
{
    [Header("Player Animation")]
    public Animator playerAnimator;


    #region PlayerAnimations
        public void Walk(){
            playerAnimator.SetBool("Walk",true);
        }
        public void Idle(){
            playerAnimator.SetBool("Walk",false);
        }
    #endregion
}
