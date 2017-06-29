/* 
 * Copyright (c) Josh Mooney
 * http://github.com/CuriousSquid
 */

using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace insertNamespaceHere
{
    /*
     * @class MainMenuController
     * @brief What does this class do?
     */
    public class MainMenuController : MonoBehaviour {

        #region Variables

        private bool mainMenuActive;

        #endregion

        #region Unity Methods

        [UsedImplicitly]
        private void Start () {
            //Set the Main Menu to active 

            //Toggle off the start of the game
        }
        
        [UsedImplicitly]
        private void Update () {
            
        }

        #endregion

        public bool onMainMenu {
            get { return mainMenuActive; }
            set {
                // ?
            }
        }

        public void ToggleMainMenu() {
            mainMenuActive = !mainMenuActive;

            //Toggle on Pause button.

            //Start Game animation

            //Hide Main Menu
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