using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatikDatabase : MonoBehaviour
{
    [System.Serializable]
    public class BajuList
    {
        public string name;
        public string deskripsi;
        public Material[] thumbnail;
        public Material[] batikTexture;

        [Space(3)]
        public GameObject batikGameObject;

    }

    public BajuList[] batikList;

}
