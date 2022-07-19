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

        [Header("Batik Utils - harus Urut di GameObject nya")]
        public GameObject kerahForManekin;
        public GameObject withLenganSet;
        public GameObject noLenganSet;

        // mengatur agar setiap motif batik (gameobject) masuk ke database
        public void SetUtils()
        {
            if(kerahForManekin == null) kerahForManekin = batikColorObjects.transform.GetChild(0).gameObject;
            if(withLenganSet == null) withLenganSet = batikColorObjects.transform.GetChild(1).gameObject;
            if(noLenganSet == null) noLenganSet = batikColorObjects.transform.GetChild(2).gameObject;
        }
    }


    [System.Serializable]
    public class BajuList
    {
        public string name = "New Batik";
        public string deskripsi = "Description here...";
        public string Harga = "Rp380.000";
        public string warnaDasar = "Biru, Merah, Hijau";
        public string ukuranTersedia = "S,M,L,XL";
        public string teknikProduksi = "Batik Tulis";

        public bool isFavorite;

        public GameObject batikMotifObjects;

        [Header("Link sosmed")]
        public string linkInstagram;
        public string linkWa;
        public string linkWebsite;

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
