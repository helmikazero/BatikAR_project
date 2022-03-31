using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ModelPlacement : MonoBehaviour
{
    public Transform modelSpot;

    public int selectedBatik = 0;
    public int targetSelectedBatik = 0;
    public int selectedColor = 0;
    public int targetSelectedColor = 0;

    public bool isManekin;
    public GameObject manekinUtil;

    public bool isLenganPanjang;

    [Header("Dependencies")]
    public BatikDatabase batikDatabse;
    public BatikListUI_Orginizer batikListOrginizer;


    private void Update()
    {
        manekinUtil.SetActive(isManekin);

        if (batikDatabse.bajuListBaru[selectedBatik].isLenganUnique)
        {
            for(int i = 0; i < batikDatabse.bajuListBaru[selectedBatik].colorObjectSet.Length; i++)
            {
                if(i == selectedColor)
                {
                    if (isLenganPanjang)
                    {
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(0).gameObject.SetActive(false); //matiin yang lengan pendek
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(1).gameObject.SetActive(true); //nyalain yang lengan panjang
                    }
                    else
                    {
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(0).gameObject.SetActive(true); //nyalain yang lengan pendek
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(1).gameObject.SetActive(false); //matiin yang lengan panjang
                    }

                    continue;
                }

                batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].SetActive(false);
                //HASIL LOOP = ngematiin semua set warna batik yang ngk kepilih dan ngeset lengan panjang atau pendek
            }
        }
        else
        {
            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;
            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;

            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).gameObject.SetActive(isLenganPanjang);

        }

        /*SET_MATERIAL(batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(0).gameObject, 0, batikDatabse.batikList[selectedBatik].batikTexture[selectedColor]);
        SET_MATERIAL(batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(1).gameObject, 0, batikDatabse.batikList[selectedBatik].batikTexture[selectedColor]);

        batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(1).gameObject.SetActive(isLenganPanjang);*/
    }

    /*public void SET_MATERIAL(GameObject theObject, int matElement, Material newMaterial)
    {
        MeshRenderer targetMeshRenderer = theObject.GetComponent<MeshRenderer>();
        Material[] targetMaterials = targetMeshRenderer.materials;

        targetMaterials[matElement] = newMaterial;

        targetMeshRenderer.materials = targetMaterials;

        Debug.Log("OBJECT NAME =" + theObject.name + "MAT ELEMENT =" + matElement + " NEW MATERIAL=" + newMaterial.name);
        *//*theObject.GetComponent<MeshRenderer>().materials[matElement] = newMaterial;*//*
    }*/

    public void DEPLOY()
    {
        for (int i = 0; i < batikDatabse.bajuListBaru.Length; i++)
        {

            batikDatabse.bajuListBaru[i].batikGameObject.SetActive(false);
            /*for(int j = 0; j < batikDatabse.batikList[i].spawnedBatikModel.Length; j++)
            {
                batikDatabse.batikList[i].spawnedBatikModel[j].SetActive(false);
            }*/
        }

        batikDatabse.bajuListBaru[selectedBatik].batikGameObject.SetActive(true);


        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();

    }

    public void TOGGLE_LENGAN()
    {
        isLenganPanjang = !isLenganPanjang;

        batikListOrginizer.SET_TOGGLELENGAN_COLOR(isLenganPanjang);
    }

    public void TOGGLE_MANEKIN()
    {
        isManekin = !isManekin;

        batikListOrginizer.SET_TOGGLEMANEKIN(isManekin);
    }

    public void UPDATE_BATIK()
    {
        if (batikDatabse.bajuListBaru[selectedBatik].isLenganUnique)
        {
            for (int i = 0; i < batikDatabse.bajuListBaru[selectedBatik].colorObjectSet.Length; i++)
            {
                if (i == selectedColor)
                {
                    if (isLenganPanjang)
                    {
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(0).gameObject.SetActive(false); //matiin yang lengan pendek
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(1).gameObject.SetActive(true); //nyalain yang lengan panjang
                    }
                    else
                    {
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(0).gameObject.SetActive(true); //nyalain yang lengan pendek
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].transform.GetChild(1).gameObject.SetActive(false); //matiin yang lengan panjang
                    }

                    continue;
                }

                batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].SetActive(false);
                //HASIL LOOP = ngematiin semua set warna batik yang ngk kepilih dan ngeset lengan panjang atau pendek
            }
        }
        else
        {
            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;
            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;

            batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).gameObject.SetActive(isLenganPanjang);

        }
    }

}
