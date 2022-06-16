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
    public Text dpHarga;
    public Image dpThumbnailBatik;
    
    public Button btInsta;
    public Button btWA;
    public Button btWebsite;

    public GameObject btShopping;
    public Button btInsta2;
    public Button btWA2;
    public Button btWebsite2;


    public Toggle btnBajuListFavorit;
    public bool isFavoriteMode;





    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab; //Template Tombol Batik di list
    public GameObject ColorSelectionButtonPrefab; //Template Tombol Warna
    public RectTransform PeringatanPopUp;
    public GameObject PeringatanFav0;
    

    [Header("Window Animation")]
    public float durationMove; //Kecepatan smoothing UI


    public Transform listSpot;
    public Transform[] colorListSpot;




    [Header("Dependencies")]
    public BatikDatabase batikBase; //Script database nyimpen batik
    public ModelPlacement modelPlacement; //Posisi titik batik
    public MenuDropDown menudropdown;


    [Header("Lengan ON/OFF")]
    public Image[] lenganOnOffButton;
    public Sprite lenganIsOn;
    public Sprite lenganIsOff;

    [Header("Manekin ON/OFF")]
    public Image[] manekinOnOffButton;
    public Sprite manekinIsOn;
    public Sprite manekinIsOff;

    [Header("Favorit ON/OFF")]
    public GameObject JudulFavIsOn;
    public GameObject JudulFavIsOff;
    
    public Sprite favoritIsOn;
    public Sprite favoritIsOff;

    [Header("Interaction Button Access")]
    public GameObject btnColorInstant;
    public GameObject btnManekinInstant;
    public GameObject btnDropDown;

    [Header("SmallPOPUP Menu")]
    public GameObject menuWarna;
    public GameObject menuManekin;



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            /*for (int j = 0; j < batikDatabase.batikList[i].spawnedBatikModel.Length; j++)
            {
                batikDatabase.batikList[i].spawnedBatikModel[j].SetActive(false); //Ngenonaktifin semua batik biar tersembunyi semua
            }*/


            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot); //Mengspawn Tombol UI Batik
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = batikBase.bajuListBaru[i].name; //Mengupdate nama batik di tombol
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().sprite = batikBase.bajuListBaru[i].batikColorSets[0].thumbnail; //Mengupdate thumbnail pakai gambar batik pertama
            int batikIndexNew = i;
            spawnedBatikButton.GetComponent<Button>().onClick.AddListener(() => CHOOSEBATIK(batikIndexNew)); //Masang fungsi tombol untuk milih batik kalau mencet tombol batik

            //Ngeset toggle favorit
            Toggle theBatikButtonFavoriteToggle = spawnedBatikButton.GetComponentInChildren<Toggle>();
            theBatikButtonFavoriteToggle.onValueChanged.AddListener(delegate
            {
                FAVORITE_TOGGLE_BUTTON(theBatikButtonFavoriteToggle, batikIndexNew);
            });

        }

        //Animasi  UI Baju Detail Panel ditutup di awal
        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(() => UIBajuDetailPanel.gameObject.SetActive(false));

        SET_COLOR_BUTTON(modelPlacement.selectedBatik);
        SmallPOP_Menu_Controller();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (batikBase.bajuListBaru[modelPlacement.selectedBatik].batikMotifObjects.activeSelf == true)
        {
            btnColorInstant.GetComponent<Button>().interactable = true;
            btnManekinInstant.GetComponent<Button>().interactable = true;
            btnColorInstant.GetComponent<Button>().onClick.AddListener(() => SMALLPOP_MENU(menuWarna));
            btnManekinInstant.GetComponent<Button>().onClick.AddListener(() => SMALLPOP_MENU(menuManekin));
        }
        else
        {
            btnColorInstant.GetComponent<Button>().interactable = false;
            btnManekinInstant.GetComponent<Button>().interactable = false;
            btnColorInstant.GetComponent<Button>().onClick.RemoveAllListeners();
            btnManekinInstant.GetComponent<Button>().onClick.RemoveAllListeners();
        }*/
    }

    // Mengeset PopUp Baju Detail Panel beserta tombol dan isinya
    public void CHOOSEBATIK(int index)
    {

        Debug.Log("Choose batik selected");

        Debug.Log("the output is =" + index.ToString());

        modelPlacement.selectedBatik = index; //Ngisi jenis batik yang akan di deploy


        dpBatikName.text = batikBase.bajuListBaru[index].name; //Ngeupdate nama
        dpDeskripsi.text = batikBase.bajuListBaru[index].deskripsi + "\n\n\n" + "Warna Dasar \t : " + batikBase.bajuListBaru[index].warnaDasar + "\n Ukuran Tersedia \t : " + batikBase.bajuListBaru[index].ukuranTersedia + "\n Jenis Kain \t : "+ batikBase.bajuListBaru[index].jenisKain + "\n Asal Daerah \t : "+ batikBase.bajuListBaru[index].asalDaerah + "\n Teknik Produksi \t : "+ batikBase.bajuListBaru[index].teknikProduksi + "\n Cara Perawatan \t :"+ batikBase.bajuListBaru[index].caraPerawatan; //Ngeupdate detail untuk deskrpsi
        dpHarga.text = batikBase.bajuListBaru[index].Harga;
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


        //Ngeset Toggle Didalam UIListBatikDetailPanel
        Toggle BtnFavoritToggle = btnBajuListFavorit.GetComponent<Toggle>();
        BtnFavoritToggle.onValueChanged.RemoveAllListeners();
        BtnFavoritToggle.onValueChanged.AddListener(delegate
        {
            FAVORITE_TOGGLE_BUTTON(BtnFavoritToggle, index);
            FavoritToggleSlider_Controller();
        });
        
        FavoritToggleBajuList_Controller();


        OPEN_DETAILPANEL();

        
    }

    // Mengatur tombol warna di Batik Detail Panel dan di Tombol Instant Color sesuai database
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

    // Memunculkan Batik Detail Panel
    public void OPEN_DETAILPANEL()
    {
        UIBajuDetailPanel.gameObject.SetActive(true); //dari tidak ada jadi muncul
        UIBajuDetailPanel.DOScale(1f, durationMove).From(0.5f); //dari kecil ke besar
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f); //dari ilang ke muncul warna pelan2
    }

    // Mengatur Tombol warna dan Thumbnail di Batik Detail Panel
    public void CHOOSECOLOR(int index)
    {
        Debug.Log("choose color yes =" + index);
        /*Material targetMaterial = UIBajuDetailPanel.GetChild(5).GetComponent<Image>().material;*/
        UIBajuDetailPanel.GetChild(4).GetComponent<Image>().sprite = batikBase.bajuListBaru[modelPlacement.selectedBatik].batikColorSets[index].thumbnail; //waktu mencet warna, thumbnail batik diganti warna
        Debug.Log(batikBase.bajuListBaru[modelPlacement.selectedBatik].batikColorSets[index].thumbnail.name);
        modelPlacement.selectedColor = index; //Ngisi jenis warna yang di deploy
    }


    // mengatur tombol warna instant agar model batik dapat langsung berubah
    public void CHOOSECOLOR_INSTANT(int index)
    {
        Debug.Log("choose color yes =" + index);
        modelPlacement.selectedColor = index;
        modelPlacement.UPDATE_BATIK();
    }

    //Menutup Pop Up Baju detail Panel
    public void CLOSE_DETAILWINDOW()
    {
        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(() => UIBajuDetailPanel.gameObject.SetActive(false));
    }

    // Mengatur Panel Slider
    public void CLOSE_LISTWINDOW()
    {
        GameObject.FindObjectOfType<BatikPanelSlider>().GetComponent<BatikPanelSlider>().CLOSE_PANEL();
    }

    // Mengatur tampilan UI tombol Lengan
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

    // Mengatur tampilan UI tombol Lengan
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

    // Mengatur tampilan UI tombol Manekin
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

    // Mengatur tampilan UI tombol Manekin
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

    
    // Mengatur Animasi POPUP apabila gameobject yang dipilih tidak aktif sehingga diaktifkan
    public void SMALLPOP_MENU(GameObject popMenuObject)
    {  
        if (!popMenuObject.activeSelf)
        {
            popMenuObject.SetActive(true);
            popMenuObject.GetComponent<CanvasGroup>().DOFade(1f, durationMove * 0.5f).From(0f);
        }
        else
        {
            popMenuObject.GetComponent<CanvasGroup>().DOFade(0f, durationMove * 0.5f).OnComplete(() => popMenuObject.SetActive(false));
        }
    }

    //Mengatur interaksi tombol ketika tidak ada model batik yang dipilih
    public void SmallPOP_Menu_Controller()
    {
        if (batikBase.bajuListBaru[modelPlacement.selectedBatik].batikMotifObjects.activeSelf == true)
        {
            /*btnColorInstant.GetComponent<Button>().interactable = true;
            btnManekinInstant.GetComponent<Button>().interactable = true;*/
            btnColorInstant.GetComponent<Button>().onClick.RemoveAllListeners();
            btnManekinInstant.GetComponent<Button>().onClick.RemoveAllListeners();
            btnDropDown.GetComponent<Button>().onClick.RemoveAllListeners();
            btnColorInstant.GetComponent<Button>().onClick.AddListener(() => SMALLPOP_MENU(menuWarna));
            btnManekinInstant.GetComponent<Button>().onClick.AddListener(() => SMALLPOP_MENU(menuManekin));
            btnDropDown.GetComponent<Button>().onClick.AddListener(() => menudropdown.TOGGLE_DROP());
        }
        else
        {
            /*btnColorInstant.GetComponent<Button>().interactable = false;
            btnManekinInstant.GetComponent<Button>().interactable = false;*/
            btnColorInstant.GetComponent<Button>().onClick.RemoveAllListeners();
            btnManekinInstant.GetComponent<Button>().onClick.RemoveAllListeners();
            btnDropDown.GetComponent<Button>().onClick.RemoveAllListeners();
            btnColorInstant.GetComponent<Button>().onClick.AddListener(() => PopUP_Peringatan());
            btnManekinInstant.GetComponent<Button>().onClick.AddListener(() => PopUP_Peringatan());
            btnDropDown.GetComponent<Button>().onClick.AddListener(() => PopUP_Peringatan());
        }
    }

    // Menonaktifkan POPup bila sedang dibuka
    public void SMALLPOP_CLOSE(GameObject popMenuObject)
    {
        if (popMenuObject.activeSelf)
        {
            popMenuObject.GetComponent<CanvasGroup>().DOFade(0f, durationMove * 0.5f).OnComplete(() => popMenuObject.SetActive(false));
        }
    }


    //Membuka link yang dipilih
    public void OPEN_LINK(string link)
    {
        Application.OpenURL(link);
    }

    //Mengatur tampilan menu batik favorit yang telah dipilih
    public void CHANGE_FAVORITE_PAGE(GameObject ButtonFavorit)
    {
        isFavoriteMode = !isFavoriteMode;

        if (isFavoriteMode)
        {
            for(int i = 0; i < batikBase.bajuListBaru.Length; i++)
            {
                listSpot.GetChild(i).gameObject.SetActive(batikBase.bajuListBaru[i].isFavorite == true);
                JudulFavIsOn.SetActive(true);
                JudulFavIsOff.SetActive(false);
                ButtonFavorit.GetComponent<Image>().sprite = favoritIsOn;
            }
            
            for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
            {
                if (batikBase.bajuListBaru[i].isFavorite == true)
                {
                    PeringatanFav0.SetActive(false);
                    break;
                }
                else
                {
                    PeringatanFav0.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
            {
                listSpot.GetChild(i).gameObject.SetActive(true);
                JudulFavIsOn.SetActive(false);
                JudulFavIsOff.SetActive(true);
                ButtonFavorit.GetComponent<Image>().sprite = favoritIsOff;
            }

            PeringatanFav0.SetActive(false);
        }
    }

    // Mengatur apakah batik termasuk favorit di toggle atau tidak
    public void FAVORITE_TOGGLE_BUTTON(Toggle thisToggle, int batikIndex)
    {
        batikBase.bajuListBaru[batikIndex].isFavorite = thisToggle.isOn;
    }


    // memunculkan popup peringatan
    public void PopUP_Peringatan()
    {
        PeringatanPopUp.gameObject.SetActive(true);
        PeringatanPopUp.DOScale(1f, durationMove).From(0.5f);
        PeringatanPopUp.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f);
       
    }


    // menghapus objek yang ditampilkan
    public void DeleteAll_Object()
    {
        for (int i = 0; i < batikBase.bajuListBaru.Length; i++)
        {
            batikBase.bajuListBaru[i].batikMotifObjects.SetActive(false);
        }
        modelPlacement.isManekin = false;
        modelPlacement.isLenganPanjang = false;
        modelPlacement.UPDATE_BATIK();
        menudropdown.TOGGLE_DROP();
        SmallPOP_Menu_Controller();
        
    }


    // Untuk ngatur favorit di slider
    public void FavoritToggleSlider_Controller() 
    {
        if (batikBase.bajuListBaru[modelPlacement.selectedBatik].isFavorite)
        {
            listSpot.GetChild(modelPlacement.selectedBatik).GetComponentInChildren<Toggle>().isOn = true;
        }
        else
        {
            listSpot.GetChild(modelPlacement.selectedBatik).GetComponentInChildren<Toggle>().isOn = false;
        }


    }

    // Untuk Tombol Favorit di UIBAjuDetaiPanel apakah sudah disukai atau belum
    public void FavoritToggleBajuList_Controller()
    {
        if (batikBase.bajuListBaru[modelPlacement.selectedBatik].isFavorite)
        {
            btnBajuListFavorit.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            btnBajuListFavorit.GetComponent<Toggle>().isOn = false;
        }
    }


    //Mengatur Agar Tombol Shopping di MenuAR dapat langsung terhubung link sosmed dari penjual
    public void BtnShopping ()
    {
        btShopping.gameObject.SetActive(true);
        btInsta2.interactable = batikBase.bajuListBaru[modelPlacement.selectedBatik].linkInstagram != "";
        btInsta2.onClick.RemoveAllListeners();
        btInsta2.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[modelPlacement.selectedBatik].linkInstagram));

        btWA2.interactable = batikBase.bajuListBaru[modelPlacement.selectedBatik].linkWa != "";
        btWA2.onClick.RemoveAllListeners();
        btWA2.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[modelPlacement.selectedBatik].linkWa));

        btWebsite2.interactable = batikBase.bajuListBaru[modelPlacement.selectedBatik].linkWebsite != "";
        btWebsite2.onClick.RemoveAllListeners();
        btWebsite2.onClick.AddListener(() => OPEN_LINK(batikBase.bajuListBaru[modelPlacement.selectedBatik].linkWebsite));
    }

    public void SetNonActiveObject (GameObject Button)
    {
        Button.gameObject.SetActive(false);
    }
}
