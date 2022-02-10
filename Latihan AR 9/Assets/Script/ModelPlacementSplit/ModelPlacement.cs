using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ModelPlacement : MonoBehaviour
{
    public Transform modelSpot;

    public int selectedBatik = 0;
    public int selectedColor = 0;


    public GameObject manekinEssential;
    public bool isManekin;
    public GameObject lenganPanjang;
    public bool isLenganPanjang;
    public GameObject batikUtama;
    

    [Header("Dependencies")]
    public BatikDatabase batikDatabse;
    public BatikListUI_Orginizer batikListOrginizer;


    private void Update()
    {
        manekinEssential.SetActive(manekinEssential);
        lenganPanjang.SetActive(isLenganPanjang);

        SET_MATERIAL(batikUtama, 0, batikDatabse.batikList[selectedBatik].batikMat[selectedColor]);
        SET_MATERIAL(lenganPanjang, 0, batikDatabse.batikList[selectedBatik].batikMat[selectedColor]);

        
    }

    public void SET_MATERIAL(GameObject theObject,int matElement, Material newMaterial)
    {
        theObject.GetComponent<MeshRenderer>().materials[matElement] = newMaterial;
    }

    public void DEPLOY_MANEKIN()
    {
        /*for(int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(i).gameObject.SetActive(false);
        }

        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(false);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(true);*/

        isManekin = true;

        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();

    }

    public void DEPLOY_COBA()
    {
        /*for (int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(i).gameObject.SetActive(false);
        }

        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(false);*/

        isManekin = false;

        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();
    }

}