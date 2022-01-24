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

    [System.Serializable]
    public class BajuList
    {
        public string name;
        public string deskripsi;
        public Sprite[] thumbnail;
        public GameObject[] batikPrefab;
        [Space(3)]
        public GameObject[] spawnedBatikModel;
    }

    public BajuList[] batikList;


    public RectTransform UIBajuDetailPanel;

    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab;
    public GameObject ColorSelectionButtonPrefab;


    [Header("Window Animation")]
    public Vector2 moveFrom;
    public Vector2 moveTo;
    public float durationMove;

    /*[Header("Color Window Animation")]
    public Vector2 moveFrom;*/


    public Transform listSpot;
    public Transform colorListSpot;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < batikList.Length; i++)
        {
            for(int j = 0; j < batikList[i].batikPrefab.Length; j++)
            {
                batikList[i].spawnedBatikModel[j] = Instantiate(batikList[i].batikPrefab[j],modelSpot).gameObject;
                batikList[i].spawnedBatikModel[j].transform.localPosition = Vector3.zero;
                batikList[i].spawnedBatikModel[j].transform.localRotation = Quaternion.Euler(Vector3.zero);
                batikList[i].spawnedBatikModel[j].SetActive(false);
            }

            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot);
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = batikList[i].name;
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().sprite = batikList[i].thumbnail[0];
            spawnedBatikButton.GetComponent<Button>().onClick.AddListener(() => CHOOSEBATIK(i));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CHOOSEBATIK(int index)
    {
        selectedBatik = index;

        UIBajuDetailPanel.GetChild(0).GetComponent<Text>().text = batikList[index].name;
        UIBajuDetailPanel.GetChild(1).GetComponent<Text>().text = batikList[index].deskripsi;

        UIBajuDetailPanel.GetChild(2).GetComponent<Image>().sprite = batikList[index].thumbnail[0];
        selectedColor = 0;

        for(int i = 0; i < colorListSpot.childCount; i++)
        {
            colorListSpot.GetChild(i).gameObject.SetActive(false);
        }


        for(int i = 0; i < batikList[index].thumbnail.Length; i++)
        {
            /*GameObject spawnedColorSelectButton = Instantiate(ColorSelectionButtonPrefab, colorListSpot);*/

            GameObject spawnedColorSelectButton = colorListSpot.GetChild(i).gameObject;
            spawnedColorSelectButton.GetComponent<Image>().sprite = batikList[index].thumbnail[i];
            spawnedColorSelectButton.GetComponent<Button>().onClick.AddListener(() => CHOOSECOLOR(i));

        }


        UIBajuDetailPanel.gameObject.SetActive(true);
        UIBajuDetailPanel.DOScale(1f,durationMove).From(0.5f);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f);


    }

    public void CHOOSECOLOR(int index)
    {
        UIBajuDetailPanel.GetChild(2).GetComponent<Image>().sprite = batikList[selectedBatik].thumbnail[index];

        selectedColor = index;
    }

    public void DEPLOY_MANEKIN()
    {
        for(int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(0).gameObject.SetActive(false);
        }

        batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(false);
        batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(true);

        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(()=> UIBajuDetailPanel.gameObject.SetActive(false));

        GameObject.FindObjectOfType<BatikMenuUISlide>().GetComponent<BatikMenuUISlide>().CLOSE_PANEL();
    }

    public void DEPLOY_COBA()
    {
        for (int i = 0; i < modelSpot.childCount; i++)
        {
            modelSpot.GetChild(0).gameObject.SetActive(false);
        }

        batikList[selectedBatik].spawnedBatikModel[selectedColor].SetActive(true);
        batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(0).gameObject.SetActive(true);
        batikList[selectedBatik].spawnedBatikModel[selectedColor].transform.GetChild(1).gameObject.SetActive(false);

        UIBajuDetailPanel.DOScale(0.3f, durationMove);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(0f, durationMove).OnComplete(() => UIBajuDetailPanel.gameObject.SetActive(false));

        GameObject.FindObjectOfType<BatikMenuUISlide>().GetComponent<BatikMenuUISlide>().CLOSE_PANEL();
    }
}