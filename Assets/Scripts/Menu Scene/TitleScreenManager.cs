using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

namespace DU
{
    public class TitleScreenManager : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] GameObject titleScreenMainMenu;
        [SerializeField] GameObject titleScreenLoadMenu;

        [Header("Buttons")]
        [SerializeField] Button loadMenuReturnButton;
        [SerializeField] Button mainMenuLoadGameButton;

        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            WorldSaveGameManager.Instance.CreateNewGame();
            StartCoroutine(WorldSaveGameManager.Instance.LoadWorldScene());
        }

        public void OpenLoadGameMenu()
        {
            titleScreenMainMenu.SetActive(false);
            titleScreenLoadMenu.SetActive(true);

            // Focus on return button
            loadMenuReturnButton.Select();
        }
        public void CloseLoadGameMenu()
        {
            titleScreenMainMenu.SetActive(true);
            titleScreenLoadMenu.SetActive(false);

            // Focus on load game button
            mainMenuLoadGameButton.Select();
        }
    }
}
