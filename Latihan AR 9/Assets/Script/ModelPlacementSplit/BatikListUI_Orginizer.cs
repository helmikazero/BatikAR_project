using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BatikListUI_Orginizer : MonoBehaviour
{
    public RectTransform UIBajuDetailPanel; //UI Detail Baju
    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab; //Template Tombol Batik di list
    public GameObject ColorSelectionButtonPrefab; //Template Tombol Warna

    [Header("Window Animation")]
    public float durationMove; //Kecepatan smoothing UI


    public Transform listSpot;
    public Transform colorListSpot;




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


        UIBajuDetailPanel.GetChild(2).GetComponent<Text>().text = batikBase.bajuListBaru[index].name; //Ngeupdate nama
        UIBajuDetailPanel.GetChild(3).GetComponent<Text>().text = batikBase.bajuListBaru[index].deskripsi; //Ngeupdate detail untuk deskrpsi
        UIBajuDetailPanel.GetChild(4).GetComponent<Image>().sprite = batikBase.bajuListBaru[index].batikColorSets[0].thumbnail; //Ngeupdate detail untuk thumbnail

        modelPlacement.selectedColor = 0; //Ngedefault jenis warnanya langsung warna pertama 

        for (int i = 0; i < colorListSpot.childCount; i++) //Nyembunyiin semua tombol warna sebelum diatur ulang lagi
        {
            colorListSpot.GetChild(i).gameObject.SetActive(false);
        }


        for (int i = 0; i < batikBase.bajuListBaru[index].batikColorSets.Length; i++)
        {

            GameObject spawnedColorSelectButton = colorListSpot.GetChild(i).gameObject; //Ngambil tombol warna yang udh ada
            spawnedColorSelectButton.GetComponent<Image>().sprite = batikBase.bajuListBaru[index].batikColorSets[i].thumbnail; //Ngeupdate gambar tombol sesuai batik
            spawnedColorSelectButton.GetComponent<Button>().onClick.RemoveAllListeners(); //Ngehapus semua fungsi tombol biar seko 0
            int newInt = i;
            spawnedColorSelectButton.GetComponent<Button>().onClick.AddListener(() => CHOOSECOLOR(newInt)); //Masang fungsi milih warna
            spawnedColorSelectButton.SetActive(true); //Munculin tombol

        }

        OPEN_DETAILPANEL();
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
        Material targetMaterial = UIBajuDetailPanel.GetChild(5).GetComponent<Image>().material;
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
}
