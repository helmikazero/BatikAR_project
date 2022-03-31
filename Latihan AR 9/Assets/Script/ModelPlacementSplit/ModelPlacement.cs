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


        batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;
        batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).GetComponent<MeshRenderer>().materials = batikDatabse.bajuListBaru[selectedBatik].colorSets[selectedColor].materialSet;

        batikDatabse.bajuListBaru[selectedBatik].batikGameObject.transform.GetChild(1).gameObject.SetActive(isLenganPanjang);

        /*SET_MATERIAL(batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(0).gameObject, 0, batikDatabse.batikList[selectedBatik].batikTexture[selectedColor]);
        SET_MATERIAL(batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(1).gameObject, 0, batikDatabse.batikList[selectedBatik].batikTexture[selectedColor]);

        batikDatabse.batikList[selectedBatik].batikGameObject.transform.GetChild(1).gameObject.SetActive(isLenganPanjang);*/
    }

    public void SET_MATERIAL(GameObject theObject, int matElement, Material newMaterial)
    {
        MeshRenderer targetMeshRenderer = theObject.GetComponent<MeshRenderer>();
        Material[] targetMaterials = targetMeshRenderer.materials;

        targetMaterials[matElement] = newMaterial;

        targetMeshRenderer.materials = targetMaterials;

        Debug.Log("OBJECT NAME =" + theObject.name + "MAT ELEMENT =" + matElement + " NEW MATERIAL=" + newMaterial.name);
        /*theObject.GetComponent<MeshRenderer>().materials[matElement] = newMaterial;*/
    }

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

        /*batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(isLenganPanjang);*/

        /*batikDatabse.batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(true);*/

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

}
