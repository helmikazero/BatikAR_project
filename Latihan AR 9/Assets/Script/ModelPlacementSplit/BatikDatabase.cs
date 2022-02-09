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
        /*public Sprite[] thumbnail;

        [Space(3)]
        public GameObject[] spawnedBatikModel;*/

        public Material[] batikMat;
        public Material[] tempMaterialUI;
    }

    public BajuList[] batikList;


    /*private void Start()
    {
        for(int i = 0; i < batikList.Length; i++)
        {
            for(int j = 0; j < batikList[i].batikMat.Length; j++)
            {
                Material newUIMat = batikList[i].batikMat[j];
                newUIMat.shader = Shader.Find("Sprites/Default");
                batikList[i].tempMaterialUI,[j] = newUIMat;
            }
        }
    }*/

    private void Awake()
    {
        for (int i = 0; i < batikList.Length; i++)
        {
            for (int j = 0; j < batikList[i].batikMat.Length; j++)
            {
                Material newUIMat = batikList[i].batikMat[j];
                newUIMat.shader = Shader.Find("Sprites/Default");
                batikList[i].tempMaterialUI[j] = newUIMat;
            }
        }
    }
}
