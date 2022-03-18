using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void State();
    public State MainMenu;
    public State InGame;
    public State EndGame;

    public delegate void Fire();
    public Fire OffFire;

    private void Start()
    {
        MainMenu += SubscribeAllEvent;
        MainMenu();
    }

    void SubscribeAllEvent()
    {
        #region InGame
        InGame += () => StateManager.Instance.state = global::State.InGame;
        InGame += UIManager.Instance.UpdateLevelProgressBar;
        InGame += PlayerController.Instance.StartForceWater;
        #endregion

        #region EndGame
        EndGame += () => StateManager.Instance.state = global::State.EndGame;
        EndGame += UIManager.Instance.EndGame;
        #endregion

        #region Off Fire
        OffFire += GameManager.Instance.UpdateActiveFire;
        OffFire += UIManager.Instance.UpdateLevelProgressBar;
        EndGame += PlayerController.Instance.EndForceWater;
        #endregion
    }
}
