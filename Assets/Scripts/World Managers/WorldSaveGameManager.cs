using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DU
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager Instance;

        [SerializeField] PlayerManager player;

        [Header("SAVE/LOAD")]
        [SerializeField] bool saveGame;
        [SerializeField] bool loadGame;

        [Header("World Scene Index")]
        [SerializeField] int worldSceneIndex = 1;

        [Header("Save Data Writer")]
        private SaveFileDataWriter saveFileDataWriter;

        [Header("Current Character Data")]
        public CharacterSlot currentCharacterSlotBeingUsed;
        public CharacterSaveData currentCharacterData;
        private string saveFileName;
        
        [Header("Character Slots")]
        public CharacterSaveData characterSlot01;
        //public CharacterSaveData characterSlot02;
        //public CharacterSaveData characterSlot03;
        //public CharacterSaveData characterSlot04;
        //public CharacterSaveData characterSlot05;
        //public CharacterSaveData characterSlot06;
        //public CharacterSaveData characterSlot07;
        //public CharacterSaveData characterSlot08;
        //public CharacterSaveData characterSlot09;
        //public CharacterSaveData characterSlot10;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (saveGame)
            {
                saveGame = false;
                SaveGame();
            }

            if (loadGame)
            {
                loadGame = false;
                LoadGame();
            }
        }

        private void DecideCharacterFileNameBasedOnCharacterSlotBeingUsed()
        {
            switch (currentCharacterSlotBeingUsed)
            {
                case CharacterSlot.CharacterSlot_01:
                    saveFileName = "characterSlot_01";
                    break;
                case CharacterSlot.CharacterSlot_02:
                    saveFileName = "characterSlot_02";
                    break;
                case CharacterSlot.CharacterSlot_03:
                    saveFileName = "characterSlot_03";
                    break;
                case CharacterSlot.CharacterSlot_04:
                    saveFileName = "characterSlot_04";
                    break;
                case CharacterSlot.CharacterSlot_05:
                    saveFileName = "characterSlot_05";
                    break;
                case CharacterSlot.CharacterSlot_06:
                    saveFileName = "characterSlot_06";
                    break;
                case CharacterSlot.CharacterSlot_07:
                    saveFileName = "characterSlot_07";
                    break;
                case CharacterSlot.CharacterSlot_08:
                    saveFileName = "characterSlot_08";
                    break;
                case CharacterSlot.CharacterSlot_09:
                    saveFileName = "characterSlot_09";
                    break;
                case CharacterSlot.CharacterSlot_10:
                    saveFileName = "characterSlot_10";
                    break;
                default:
                    break;
            }
        }

        public void CreateNewGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();

            currentCharacterData = new CharacterSaveData();
        }

        public void LoadGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();

            saveFileDataWriter = new SaveFileDataWriter();

            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileDataWriter.saveFileName = saveFileName;
            currentCharacterData = saveFileDataWriter.LoadSaveFile();

            StartCoroutine(LoadWorldScene());    
        }

        public void SaveGame()
        {
            DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();

            saveFileDataWriter = new SaveFileDataWriter();

            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileDataWriter.saveFileName = saveFileName;

            player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

            saveFileDataWriter.CreateNewCharacterSaveFile(currentCharacterData);
        }    

        public IEnumerator LoadWorldScene()
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);

            yield return null;
        }

        public int GetWorldSceneIndex()
        {
            return worldSceneIndex;
        }
    }
}
