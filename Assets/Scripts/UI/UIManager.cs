using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject endGamePanel;
    [Header("In Game Fields")]
    public Slider levelProgressBar;

    #region Private Fields
        private GameObject _currentPanel;
    #endregion

    private void Start() {
        _currentPanel = mainMenuPanel;
        
    }

    #region Panel Change Function
    /// <summary>
    /// we changing panels
    /// </summary>
    /// <param name="openPanel"> opening panel </param>
        public void PanelChange(GameObject openPanel){
            _currentPanel.SetActive(false);
            openPanel.SetActive(true);
            _currentPanel = openPanel;
        }
    #endregion

    #region StartButton
        public void StartButton(){
            PanelChange(inGamePanel);
            EventManager.Instance.InGame();
            levelProgressBar.maxValue = GameManager.Instance.TotalFire;
        }
        
    #endregion

    #region In Game UI Text Update
        
        public void UpdateLevelProgressBar(){
            levelProgressBar.value = GameManager.Instance.ActiveFireCounter;
        }
    #endregion
    
    #region EndGame
        public void EndGame(){
            PanelChange(endGamePanel);
        }
    #endregion
}
