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

    public bool isManekin;
    public GameObject manekinUtil;

    public bool isLenganPanjang;

    [Header("Dependencies")]
    public BatikDatabase batikDatabse;
    public BatikListUI_Orginizer batikListOrginizer;


    private void Update()
    {
        manekinUtil.SetActive(isManekin);
    }

    public void DEPLOY()
    {
        for (int i = 0; i < batikDatabse.batikList.Length; i++)
        {
            for(int j = 0; j < batikDatabse.batikList[i].spawnedBatikModel.Length; i++)
            {
                batikDatabse.batikList[i].spawnedBatikModel[j].SetActive(false);
            }
        }

        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(false);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(true);

        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();

    }

}
