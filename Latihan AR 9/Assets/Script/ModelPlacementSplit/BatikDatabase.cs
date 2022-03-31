using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatikDatabase : MonoBehaviour
{
    [System.Serializable]
    public class batikColorSet
    {
        public Material thumbnail;
        public Material[] materialSet;
    }

   /* [System.Serializable]
    public class BajuList
    {
        public string name;
        public string deskripsi;
        public Material[] thumbnail;
        public Material[] batikTexture;



        [Space(3)]
        public GameObject batikGameObject;

    }*/


    [System.Serializable]
    public class BajuListBaru
    {
        public string name;
        public string deskripsi;

        public bool isLenganUnique;

        //Untuk lengan texture tidak unik
        public batikColorSet[] colorSets;
        [Space(3)]
        public GameObject batikGameObject;


        //Untuk lengan texture unik
        public GameObject[] colorObjectSet;

    }

    /*public BajuList[] batikList;*/

    public BajuListBaru[] bajuListBaru;
}
