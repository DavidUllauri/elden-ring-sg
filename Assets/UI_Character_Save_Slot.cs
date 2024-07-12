using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DU 
{
    public class UI_Character_Save_Slot : MonoBehaviour
    {
        SaveFileDataWriter saveFileWriter;

        [Header("Game Slot")]
        public CharacterSlot characterSlot;

        [Header("Character Info")]
        public TextMeshProUGUI characterName;
        public TextMeshProUGUI timePlayed;

        private void OnEnable()
        {
            LoadSaveSlot();
        }

        private void LoadSaveSlot()
        {
            saveFileWriter = new SaveFileDataWriter();
            saveFileWriter.saveDataDirectoryPath = Application.persistentDataPath;
            saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);

            switch (characterSlot)
            {
                case CharacterSlot.CharacterSlot_01:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        Debug.Log("Slot01 does not have any save data");
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_02:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot02.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_03:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot03.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_04:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot04.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_05:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot05.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_06:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot06.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_07:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot07.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_08:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot08.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_09:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot09.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_10:
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot10.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);

                    }
                    break;
                default:
                    Debug.Log("Default Case In UI_Character_Save_Slot.cs, LoadSaveSlot()");
                    break;
            }
        }

        public void LoadGameFromCharacterSlot()
        {
            WorldSaveGameManager.Instance.currentCharacterSlotBeingUsed = characterSlot;
            WorldSaveGameManager.Instance.LoadGame();
        }
    }
}
