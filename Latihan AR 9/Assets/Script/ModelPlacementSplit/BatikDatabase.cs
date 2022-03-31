using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatikDatabase : MonoBehaviour
{
    [System.Serializable]
    public class BatikColorSet
    {
        public Sprite thumbnail;
        public GameObject batikColorObjects;

        [Space(2)]
        public GameObject kerahforManekin;
        public GameObject withLenganSet;
        public GameObject noLenganSet;

        public void SetUtils()
        {
            kerahforManekin = batikColorObjects.transform.GetChild(0).gameObject;
            withLenganSet = batikColorObjects.transform.GetChild(1).gameObject;
            noLenganSet = batikColorObjects.transform.GetChild(2).gameObject;
        }
    }


    [System.Serializable]
    public class BajuList
    {
        public string name;
        public string deskripsi;


        public BatikColorSet[] batikColorSets;
    }

    public BajuList[] bajuListBaru;


    private void Start()
    {
        for(int i = 0; i < bajuListBaru.Length; i++)
        {
            for(int j = 0; j < bajuListBaru[i].batikColorSets.Length; j++)
            {
                bajuListBaru[i].batikColorSets[j].SetUtils();
            }
        }
    }
}
