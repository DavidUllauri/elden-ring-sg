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
            saveFileWriter.saveDataDirectoryPath = Application.persistentDataPath; ;

            switch (characterSlot)
            {
                case CharacterSlot.CharacterSlot_01:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
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
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_03:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_04:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_05:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
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
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_07:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_08:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_09:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                    break;
                case CharacterSlot.CharacterSlot_10:
                    saveFileWriter.saveFileName = WorldSaveGameManager.Instance.DecideCharacterFileName(characterSlot);
                    if (saveFileWriter.FileExists())
                    {
                        characterName.text = WorldSaveGameManager.Instance.characterSlot01.characterName;
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
    }
}
