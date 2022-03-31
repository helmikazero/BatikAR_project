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
    public BatikDatabase batikDatabase; //Script database nyimpen batik
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
        for (int i = 0; i < batikDatabase.bajuListBaru.Length; i++)
        {
            /*for (int j = 0; j < batikDatabase.batikList[i].spawnedBatikModel.Length; j++)
            {
                batikDatabase.batikList[i].spawnedBatikModel[j].SetActive(false); //Ngenonaktifin semua batik biar tersembunyi semua
            }*/

            
            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot); //Ngespawn tombol UI batik
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = batikDatabase.bajuListBaru[i].name; //Nge update nama batik di tombol
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().material = batikDatabase.bajuListBaru[i].colorSets[0].thumbnail; //Ngisi thumbnail pakai gambar batik pertama
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


        UIBajuDetailPanel.GetChild(2).GetComponent<Text>().text = batikDatabase.bajuListBaru[index].name; //Ngeupdate nama
        UIBajuDetailPanel.GetChild(3).GetComponent<Text>().text = batikDatabase.bajuListBaru[index].deskripsi; //Ngeupdate detail untuk deskrpsi
        UIBajuDetailPanel.GetChild(4).GetComponent<Image>().material = batikDatabase.bajuListBaru[index].colorSets[0].thumbnail; //Ngeupdate detail untuk thumbnail

        modelPlacement.selectedColor = 0; //Ngedefault jenis warnanya langsung warna pertama 

        for (int i = 0; i < colorListSpot.childCount; i++) //Nyembunyiin semua tombol warna sebelum diatur ulang lagi
        {
            colorListSpot.GetChild(i).gameObject.SetActive(false);
        }


        for (int i = 0; i < batikDatabase.bajuListBaru[index].colorSets.Length; i++)
        {

            GameObject spawnedColorSelectButton = colorListSpot.GetChild(i).gameObject; //Ngambil tombol warna yang udh ada
            spawnedColorSelectButton.GetComponent<Image>().material = batikDatabase.bajuListBaru[index].colorSets[i].thumbnail; //Ngeupdate gambar tombol sesuai batik
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
        UIBajuDetailPanel.GetChild(4).GetComponent<Image>().material = batikDatabase.bajuListBaru[modelPlacement.selectedBatik].colorSets[index].thumbnail; //waktu mencet warna, thumbnail batik diganti warna
        Debug.Log(batikDatabase.bajuListBaru[modelPlacement.selectedBatik].colorSets[index].thumbnail.name);
        modelPlacement.selectedColor = index; //Ngisi jenis warna yang di deploy
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

    public void SET_TOGGLELENGAN_COLOR(bool isLenganPanjang)
    {
        if (isLenganPanjang)
        {
            for(int i = 0; i < manekinOnOffButton.Length; i++)
            {
                lenganOnOffButton[i].sprite = lenganIsOn;
            }
        }
        else
        {
            for (int i = 0; i < manekinOnOffButton.Length; i++)
            {
                lenganOnOffButton[i].sprite = lenganIsOff;
            }
        }
    }

    public void SET_TOGGLEMANEKIN(bool isManekin)
    {
        if (isManekin)
        {
            for(int i= 0; i< manekinOnOffButton.Length; i++)
            {
                manekinOnOffButton[i].sprite = lenganIsOn;
            }
        }
        else
        {
            for (int i = 0; i < manekinOnOffButton.Length; i++)
            {
                manekinOnOffButton[i].sprite = lenganIsOff;
            }
        }
    }
}
