using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DU
{
public class CharacterManager : MonoBehaviour
{
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}