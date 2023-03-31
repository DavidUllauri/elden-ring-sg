using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace DU
{
    public class TitleScreenManager : MonoBehaviour
    {
        public void StartNetworkAskHost()
        {
            NetworkManager.Singleton.StartHost();
        }
    }
}
