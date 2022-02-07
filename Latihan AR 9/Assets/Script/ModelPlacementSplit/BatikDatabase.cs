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
        public Sprite[] thumbnail;

        [Space(3)]
        public GameObject[] spawnedBatikModel;
    }

    public BajuList[] batikList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
