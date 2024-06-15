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
        public CharacterSaveData characterSlot02;
        public CharacterSaveData characterSlot03;
        public CharacterSaveData characterSlot04;
        public CharacterSaveData characterSlot05;
        public CharacterSaveData characterSlot06;
        public CharacterSaveData characterSlot07;
        public CharacterSaveData characterSlot08;
        public CharacterSaveData characterSlot09;
        public CharacterSaveData characterSlot10;

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
            LoadAllCharacterProfiles();
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

        public string DecideCharacterFileName(CharacterSlot characterSlot)
        {
            switch (characterSlot)
            {
                case CharacterSlot.CharacterSlot_01:
                    return "characterSlot_01";
                case CharacterSlot.CharacterSlot_02:
                    return "characterSlot_02";
                case CharacterSlot.CharacterSlot_03:
                    return "characterSlot_03";
                case CharacterSlot.CharacterSlot_04:
                    return "characterSlot_04";
                case CharacterSlot.CharacterSlot_05:
                    return "characterSlot_05";
                case CharacterSlot.CharacterSlot_06:
                    return "characterSlot_06";
                case CharacterSlot.CharacterSlot_07:
                    return "characterSlot_07";
                case CharacterSlot.CharacterSlot_08:
                    return "characterSlot_08";
                case CharacterSlot.CharacterSlot_09:
                    return "characterSlot_09";
                case CharacterSlot.CharacterSlot_10:
                    return "characterSlot_10";
                default:
                    return "";
            }
        }

        public void CreateNewGame()
        {
            saveFileName = DecideCharacterFileName(currentCharacterSlotBeingUsed);

            currentCharacterData = new CharacterSaveData();
        }

        public void LoadGame()
        {
            saveFileName = DecideCharacterFileName(currentCharacterSlotBeingUsed);

            saveFileDataWriter = new SaveFileDataWriter();

            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileDataWriter.saveFileName = saveFileName;
            currentCharacterData = saveFileDataWriter.LoadSaveFile();

            StartCoroutine(LoadWorldScene());    
        }

        public void SaveGame()
        {
            saveFileName = DecideCharacterFileName(currentCharacterSlotBeingUsed);

            saveFileDataWriter = new SaveFileDataWriter();

            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileDataWriter.saveFileName = saveFileName;

            player.SaveGameDataToCurrentCharacterData(ref currentCharacterData);

            saveFileDataWriter.CreateNewCharacterSaveFile(currentCharacterData);
        }    

        private void LoadAllCharacterProfiles()
        {
            saveFileDataWriter = new SaveFileDataWriter();
            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_01);
            characterSlot01 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_02);
            characterSlot02 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_03);
            characterSlot03 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_04);
            characterSlot04 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_05);
            characterSlot05 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_06);
            characterSlot06 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_07);
            characterSlot07 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_08);
            characterSlot08 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_09);
            characterSlot09 = saveFileDataWriter.LoadSaveFile();

            saveFileDataWriter.saveFileName = DecideCharacterFileName(CharacterSlot.CharacterSlot_10);
            characterSlot10 = saveFileDataWriter.LoadSaveFile();
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
