using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ModelPlacement : MonoBehaviour
{
    public Transform modelSpot;

    public int selectedBatik = 0;
    public int previousSelectedBatik = 0;
    public int selectedColor = 0;
    public int previousSelectedColor = 0;

    public bool isPreviousManekin;
    public bool isManekin;
    public GameObject manekinUtil;

    public bool isPreviousLenganPanjang;
    public bool isLenganPanjang;

    [Header("Dependencies")]
    public BatikDatabase batikBase;
    public BatikListUI_Orginizer batikListOrginizer;

    private void Start()
    {
       for(int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            batikBase.bajuListBaru[i].batikMotifObjects.SetActive(false);
        }

        UPDATE_BATIK();
 
      
    }

    private void Update()
    {
        /*manekinUtil.SetActive(isManekin);*/

        /*if (batikDatabse.bajuListBaru[selectedBatik].isLenganUnique)
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

        }*/

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
        for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            batikBase.bajuListBaru[i].batikMotifObjects.SetActive(false);
        }

        batikBase.bajuListBaru[selectedBatik].batikMotifObjects.SetActive(true);

        batikListOrginizer.SmallPOP_Menu_Controller();
        UPDATE_BATIK();

        /*batikBase.bajuListBaru[selectedBatik].batikGameObject.SetActive(true);*/


        batikListOrginizer.CLOSE_DETAILWINDOW();
        batikListOrginizer.CLOSE_LISTWINDOW();

    }

    public void TOGGLE_LENGAN(Image thebutton)
    {
        isLenganPanjang = !isLenganPanjang;
        /*batikListOrginizer.SET_TOGGLELENGAN_COLOR_THISONLY(thebutton);*/
        batikListOrginizer.SET_TOGGLELENGAN_COLOR();
    }

    public void TOGGLE_LENGAN_INSTANT()
    {
        isLenganPanjang = !isLenganPanjang;
        batikListOrginizer.SET_TOGGLELENGAN_COLOR();
        UPDATE_BATIK();
    }


    public void TOGGLE_MANEKIN(Image thebutton)
    {
        isManekin = !isManekin;
        /*batikListOrginizer.SET_TOGGLEMANEKIN_COLOR_THISONLY(thebutton);*/
        batikListOrginizer.SET_TOGGLEMANEKIN_COLOR();
    }

    public void TOGGLE_MANEKIN_INSTANT()
    {
        isManekin = !isManekin;
        batikListOrginizer.SET_TOGGLEMANEKIN_COLOR();
        UPDATE_BATIK();
    }


    public void UPDATE_BATIK()
    {
        for(int i=0; i < batikBase.bajuListBaru.Length; i++)
        {
            for (int j = 0; j < batikBase.bajuListBaru[i].batikColorSets.Length; j++)
            {
                batikBase.bajuListBaru[i].batikColorSets[j].batikColorObjects.SetActive(false);
            }
        }

        batikBase.bajuListBaru[selectedBatik].batikColorSets[selectedColor].batikColorObjects.SetActive(true);
        batikBase.bajuListBaru[selectedBatik].batikColorSets[selectedColor].withLenganSet.SetActive(isLenganPanjang);
        batikBase.bajuListBaru[selectedBatik].batikColorSets[selectedColor].noLenganSet.SetActive(!isLenganPanjang);

        batikBase.bajuListBaru[selectedBatik].batikColorSets[selectedColor].kerahForManekin.SetActive(isManekin);

        manekinUtil.SetActive(isManekin);

        previousSelectedBatik = selectedBatik;
        previousSelectedColor = selectedColor;
        isPreviousLenganPanjang = isLenganPanjang;
        isPreviousManekin = isManekin;

        batikListOrginizer.SET_TOGGLEMANEKIN_COLOR();
        batikListOrginizer.SET_TOGGLELENGAN_COLOR();
    }


    public void CANCEL_DEPLOY()
    {
        selectedBatik = previousSelectedBatik;
        selectedColor = previousSelectedColor;
        isLenganPanjang = isPreviousLenganPanjang;
        isManekin = isPreviousManekin;

        batikListOrginizer.SET_TOGGLEMANEKIN_COLOR();
        batikListOrginizer.SET_TOGGLELENGAN_COLOR();
    }


    public void Instant_Choose_color(GameObject button)
    {
        for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            if (batikBase.bajuListBaru[selectedBatik].batikMotifObjects.activeSelf == true)
            {
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
                
            }
        }
        
    }
    /*public void UPDATE_BATIK()
    {
        
        for (int i = 0; i < batikDatabse.bajuListBaru.Length; i++)
        {
            if(i != selectedBatik)
            {
                //Ngilangin semua objek batik yang bukan selectedBatik
                batikDatabse.bajuListBaru[i].batikGameObject.SetActive(false);
                continue; //Ngeskip loop langsung ke iterasi batik selanjutnya
            }

            if (batikDatabse.bajuListBaru[selectedBatik].isLenganUnique)
            {
                for (int j = 0; j < batikDatabse.bajuListBaru[selectedBatik].colorObjectSet.Length; j++)
                {
                    if (j != selectedColor)
                    {
                        //Ngilangin semua object yang bukan color batik ini
                        batikDatabse.bajuListBaru[selectedBatik].colorObjectSet[i].SetActive(false);
                        continue; //ngeskip loop biar langsung ke iterasi colorObjectSet selanjutnya
                    }

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
    }*/

}
