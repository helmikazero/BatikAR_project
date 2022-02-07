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


    [Header("Dependencies")]
    public BatikDatabase batikDatabse;
    public BatikListUI_Orginizer batikListOrginizer;




    public void DEPLOY_MANEKIN()
    {
        for(int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(i).gameObject.SetActive(false);
        }

        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(false);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(true);

        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();

    }

    public void DEPLOY_COBA()
    {
        for (int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(i).gameObject.SetActive(false);
        }

        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(false);

        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();
    }

}
