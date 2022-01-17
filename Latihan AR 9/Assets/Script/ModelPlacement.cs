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
        public GameObject[] spawnedBatikModel;
    }

    public BajuList[] batikList;

    


    public RectTransform UIBajuDetailPanel;

    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab;
    public GameObject ColorSelection;


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
        UIBajuDetailPanel.GetChild(0).GetComponent<Text>().text = batikList[index].name;
        UIBajuDetailPanel.GetChild(1).GetComponent<Text>().text = batikList[index].deskripsi;


        UIBajuDetailPanel.gameObject.SetActive(true);
        UIBajuDetailPanel.DOScale(1f,durationMove).From(0.5f);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f);


    }

    public void CHOOSECOLOR(int index)
    {
        UIBajuDetailPanel.GetChild(2).GetComponent<Image>().sprite = batikList[selectedBatik].thumbnail[index];

        selectedColor = index;
    }
}
