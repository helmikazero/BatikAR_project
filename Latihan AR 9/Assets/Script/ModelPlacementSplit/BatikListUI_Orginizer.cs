using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BatikListUI_Orginizer : MonoBehaviour
{
    [Header("Detail Panel Elements")]
    public RectTransform UIBajuDetailPanel; //UI Detail Baju
    public Text dpBatikName;
    public Text dpDeskripsi;
    public Image dpThumbnailBatik;
    public Button btInsta;
    public Button btWA;
    public Button btWebsite;






    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab; //Template Tombol Batik di list
    public GameObject ColorSelectionButtonPrefab; //Template Tombol Warna

    [Header("Window Animation")]
    public float durationMove; //Kecepatan smoothing UI


    public Transform listSpot;
    public Transform[] colorListSpot;




    [Header("Dependencies")]
    public BatikDatabase batikBase; //Script database nyimpen batik
    public ModelPlacement modelPlacement; //Posisi titik batik


    [Header("Lengan ON/OFF")]
    public Image[] lenganOnOffButton;
    public Sprite lenganIsOn;
    public Sprite lenganIsOff;

    [Header("Manekin ON/OFF")]
    public Image[] manekinOnOffButton;
    public Sprite manekinIsOn;
    public Sprite manekinIsOff;




    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            /*for (int j = 0; j < batikDatabase.batikList[i].spawnedBatikModel.Length; j++)
            {
                batikDatabase.batikList[i].spawnedBatikModel[j].SetActive(false); //Ngenonaktifin semua batik biar tersembunyi semua
            }*/


            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot); //Ngespawn tombol UI batik
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = batikBase.bajuListBaru[i].name; //Nge update nama batik di tombol
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().sprite = batikBase.bajuListBaru[i].batikColorSets[0].thumbnail; //Ngisi thumbnail pakai gambar batik pertama
            int batikIndexNew = i;
            spawnedBatikButton.GetComponent<Button>().onClick.AddListener(() => CHOOSEBATIK(batikIndexNew)); //Masang fungsi tombol untuk milih batik kalau mencet tombol batik

        }

        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(() => UIBajuDetailPanel.gameObject.SetActive(false));

        SET_COLOR_BUTTON(modelPlacement.selectedBatik);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CHOOSEBATIK(int index)
    {

        Debug.Log("Choose batik selected");

        Debug.Log("the output is =" + index.ToString());

        modelPlacement.selectedBatik = index; //Ngisi jenis batik yang akan di deploy


        dpBatikName.text = batikBase.bajuListBaru[index].name; //Ngeupdate nama
        dpDeskripsi.text = batikBase.bajuListBaru[index].deskripsi + "\n\n\n" + "Warna Dasar \t : " + batikBase.bajuListBaru[index].warnaDasar + "\n Ukuran Tersedia \t : " + batikBase.bajuListBaru[index].ukuranTersedia + "\n Jenis Kain \t : "+ batikBase.bajuListBaru[index].jenisKain + "\n Asal Daerah \t : "+ batikBase.bajuListBaru[index].asalDaerah + "\n Teknik Produksi \t : "+ batikBase.bajuListBaru[index].teknikProduksi + "\n Cara Perawatan \t :"+ batikBase.bajuListBaru[index].caraPerawatan; //Ngeupdate detail untuk deskrpsi
        Debug.Log("rename dan deskripsi selesai");
        dpThumbnailBatik.sprite = batikBase.bajuListBaru[index].batikColorSets[0].thumbnail; //Ngeupdate detail untuk thumbnail




        //MASANG LINK
        btInsta.interactable = batikBase.bajuListBaru[index].linkInstagram != "";
        btInsta.onClick.RemoveAllListeners();
        btInsta.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[index].linkInstagram));

        btWA.interactable = batikBase.bajuListBaru[index].linkWa != "";
        btWA.onClick.RemoveAllListeners();
        btWA.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[index].linkWa));

        btWebsite.interactable = batikBase.bajuListBaru[index].linkWebsite != "";
        btWebsite.onClick.RemoveAllListeners();
        btWebsite.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[index].linkWebsite));




        modelPlacement.selectedColor = 0; //Ngedefault jenis warnanya langsung warna pertama 


        SET_COLOR_BUTTON(modelPlacement.selectedBatik);


        OPEN_DETAILPANEL();

        
    }

    void SET_COLOR_BUTTON(int index)
    {
        Debug.Log("selesai select color");
        for (int i = 0; i < colorListSpot.Length; i++)
        {
            Debug.Log("iteras color List Spot =" + i);
            Debug.Log("Name of colorList Object" + colorListSpot[i].name);
            for (int j = 0; j < colorListSpot[i].childCount; j++)
            {
                Debug.Log("i = " + i + " j = " + j);
                Debug.Log("Index =" + index + " batikBase.bajuListBaru[index].batikColorSets.Length = " + batikBase.bajuListBaru[index].batikColorSets.Length + " j = " + j);
                if (j < batikBase.bajuListBaru[index].batikColorSets.Length)
                {
                    Debug.Log("Name of color button Object" + colorListSpot[i].GetChild(j).name);
                    Debug.Log("ganti warna dan dinyalain");

                    colorListSpot[i].GetChild(j).GetComponent<Image>().sprite = batikBase.bajuListBaru[index].batikColorSets[j].thumbnail;
                    colorListSpot[i].GetChild(j).gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("ini di mmatiin");
                    colorListSpot[i].GetChild(j).gameObject.SetActive(false);
                }

                Debug.Log("i = " + i + " j = " + j + "ENDING ITERASI");
            }
        }
    }


    public void OPEN_DETAILPANEL()
    {
        UIBajuDetailPanel.gameObject.SetActive(true); //dari tidak ada jadi muncul
        UIBajuDetailPanel.DOScale(1f, durationMove).From(0.5f); //dari kecil ke besar
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f); //dari ilang ke muncul warna pelan2
    }

    public void CHOOSECOLOR(int index)
    {
        Debug.Log("choose color yes =" + index);
        /*Material targetMaterial = UIBajuDetailPanel.GetChild(5).GetComponent<Image>().material;*/
        UIBajuDetailPanel.GetChild(4).GetComponent<Image>().sprite = batikBase.bajuListBaru[modelPlacement.selectedBatik].batikColorSets[index].thumbnail; //waktu mencet warna, thumbnail batik diganti warna
        Debug.Log(batikBase.bajuListBaru[modelPlacement.selectedBatik].batikColorSets[index].thumbnail.name);
        modelPlacement.selectedColor = index; //Ngisi jenis warna yang di deploy
    }

    public void CHOOSECOLOR_INSTANT(int index)
    {
        Debug.Log("choose color yes =" + index);
        modelPlacement.selectedColor = index;
        modelPlacement.UPDATE_BATIK();
    }

    public void CLOSE_DETAILWINDOW()
    {
        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(() => UIBajuDetailPanel.gameObject.SetActive(false));
    }

    public void CLOSE_LISTWINDOW()
    {
        GameObject.FindObjectOfType<BatikPanelSlider>().GetComponent<BatikPanelSlider>().CLOSE_PANEL();
    }


    public void SET_TOGGLELENGAN_COLOR_THISONLY(Image thebutton)
    {
        if (modelPlacement.isLenganPanjang)
        {
            thebutton.sprite = lenganIsOn;
        }
        else
        {
            thebutton.sprite = lenganIsOff;
        }
    }

    public void SET_TOGGLELENGAN_COLOR()
    {
        for (int i = 0; i < lenganOnOffButton.Length; i++)
        {
            if (modelPlacement.isLenganPanjang)
            {
                lenganOnOffButton[i].sprite = lenganIsOn;
            }
            else
            {
                lenganOnOffButton[i].sprite = lenganIsOff;
            }
        } 
    }

    public void SET_TOGGLEMANEKIN_COLOR_THISONLY(Image thebutton)
    {
        if (modelPlacement.isManekin)
        {
            thebutton.sprite = manekinIsOn;
        }
        else
        {
           thebutton.sprite = manekinIsOff;
        }
    }

    public void SET_TOGGLEMANEKIN_COLOR()
    {
        for(int i = 0; i < manekinOnOffButton.Length; i++)
        {
            if (modelPlacement.isManekin)
            {
                manekinOnOffButton[i].sprite = manekinIsOn;
            }
            else
            {
                manekinOnOffButton[i].sprite = manekinIsOff;
            }
        }
    }

    /*public void SET_TOGGLELENGAN_COLOR(bool isLenganPanjang, Image tombolToggleLengan)
    {
        if (isLenganPanjang)
        {
            tombolToggleLengan.sprite = lenganIsOn;
        }
        else
        {
            tombolToggleLengan.sprite = lenganIsOff;
        }
    }

    public void SET_TOGGLEMANEKIN_COLOR(bool isManekin, Image tombolToggleManekin)
    {
        if (isManekin)
        {
            tombolToggleManekin.sprite = lenganIsOn;
        }
        else
        {
            tombolToggleManekin.sprite = lenganIsOff;
        }
    }*/

    public void SMALLPOP_MENU(GameObject popMenuObject)
    {
        if (!popMenuObject.activeSelf)
        {
            popMenuObject.SetActive(true);
            popMenuObject.GetComponent<CanvasGroup>().DOFade(1f, durationMove*0.5f).From(0f);
        }
        else
        {
            popMenuObject.GetComponent<CanvasGroup>().DOFade(0f, durationMove * 0.5f).OnComplete(()=> popMenuObject.SetActive(false));
        }
    }

    public void SMALLPOP_CLOSE(GameObject popMenuObject)
    {
        if (popMenuObject.activeSelf)
        {
            popMenuObject.GetComponent<CanvasGroup>().DOFade(0f, durationMove * 0.5f).OnComplete(() => popMenuObject.SetActive(false));
        }
    }

    public void OPEN_LINK(string link)
    {
        Application.OpenURL(link);
    }
}
