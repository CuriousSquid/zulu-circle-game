/* 
 * Copyright (c) Josh Mooney
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace Assets.Scripts.Game.Controllers {
    /*
     * @class MainMenuController
     * @brief What does this class do?
     */
    public class MainMenuController : MonoBehaviour {

        [Serializable]
        public class MenuEvent : UnityEvent<bool> { }

        #region Variables

        private bool mainMenuActive = true;
        public MenuEvent OnMennuChanged;

        #endregion

        #region Unity Methods

        [UsedImplicitly]
        private void Start () {
            //Toggle off the start of the game

        }
        
        [UsedImplicitly]
        private void Update () {
            
        }

        #endregion

        public bool onMainMenu {
            get { return mainMenuActive; }
            set {
                if (onMainMenu != value) {
                    mainMenuActive = value;
                    Time.timeScale = onMainMenu ? 0 : 1;
                    OnMennuChanged?.Invoke(onMainMenu);
                }
            }
        }

        public void ToggleMainMenu() {
            mainMenuActive = !mainMenuActive;

            GameObject spawner;
            GameObject defendGoal;
            GameObject gameObj;
            //GameObject gameObj;
            //Toggle on Pause button.
            /*gameObj = GameObject.FindGameObjectWithTag("PauseBrn");
            gameObj.SetActive(!mainMenuActive);*/

            //Toggle Game animation
            /*gameObj = GameObject.Find("/DefendGoal");
            gameObj = gameObj.transform.GetChild(0).gameObject;
            gameObj.SetActive(!mainMenuActive);*/

            //Toggle Spawners

            gameObj = GameObject.Find("/Spawners");
            gameObj = GameObject.Find("Spawners");
            gameObj = GameObject.FindGameObjectWithTag("Spawner");
            /*spawner = GameObject.Find("Spawners");
            spawner = GameObject.FindGameObjectWithTag("Spawner");
            spawner.SetActive(!mainMenuActive);*/

            //Toggle Main Menu
            //This is handled by the button onClick function
        }

        public void returnToMenu() {
            mainMenuActive = true;
        }

        public void leaveMenu() {
            mainMenuActive = false;
        }

        public void ToggleOptions() {
            //Toggle Main Menu

            //Toggle on the Options Menu
        }

        public void QuitGame() {
            //Quits the Game, unverified to work on android
            Application.Quit();
        }
    }
}