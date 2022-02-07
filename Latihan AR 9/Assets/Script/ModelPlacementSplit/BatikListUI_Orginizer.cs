using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BatikListUI_Orginizer : MonoBehaviour
{
    public RectTransform UIBajuDetailPanel;
    [Header("UI Prefabs")]
    public GameObject UIBajuListPrefab;
    public GameObject ColorSelectionButtonPrefab;

    [Header("Window Animation")]
    public float durationMove;


    public Transform listSpot;
    public Transform colorListSpot;




    [Header("Dependencies")]
    public BatikDatabase bdb;
    public ModelPlacement mdlplc;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bdb.batikList.Length; i++)
        {
            for (int j = 0; j < bdb.batikList[i].spawnedBatikModel.Length; j++)
            {
                bdb.batikList[i].spawnedBatikModel[j].SetActive(false);
            }

            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot);
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = bdb.batikList[i].name;
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().sprite = bdb.batikList[i].thumbnail[0];
            int batikIndexNew = i;
            spawnedBatikButton.GetComponent<Button>().onClick.AddListener(() => CHOOSEBATIK(batikIndexNew));

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
        mdlplc.selectedBatik = index;
        Debug.Log("the output is =" + index.ToString());


        UIBajuDetailPanel.GetChild(0).GetComponent<Text>().text = bdb.batikList[index].name;
        UIBajuDetailPanel.GetChild(1).GetComponent<Text>().text = bdb.batikList[index].deskripsi;

        UIBajuDetailPanel.GetChild(2).GetComponent<Image>().sprite = bdb.batikList[index].thumbnail[0];
        mdlplc.selectedColor = 0;

        for (int i = 0; i < colorListSpot.childCount; i++)
        {
            colorListSpot.GetChild(i).gameObject.SetActive(false);
        }


        for (int i = 0; i < bdb.batikList[index].thumbnail.Length; i++)
        {
            /*GameObject spawnedColorSelectButton = Instantiate(ColorSelectionButtonPrefab, colorListSpot);*/

            GameObject spawnedColorSelectButton = colorListSpot.GetChild(i).gameObject;
            spawnedColorSelectButton.GetComponent<Image>().sprite = bdb.batikList[index].thumbnail[i];
            spawnedColorSelectButton.GetComponent<Button>().onClick.RemoveAllListeners();
            int newInt = i;
            spawnedColorSelectButton.GetComponent<Button>().onClick.AddListener(() => CHOOSECOLOR(newInt));
            spawnedColorSelectButton.SetActive(true);

        }


        UIBajuDetailPanel.gameObject.SetActive(true);
        UIBajuDetailPanel.DOScale(1f, durationMove).From(0.5f);
        UIBajuDetailPanel.GetComponent<CanvasGroup>().DOFade(1f, durationMove).From(0f);


    }

    public void CHOOSECOLOR(int index)
    {
        Debug.Log("choose color yes");
        UIBajuDetailPanel.GetChild(2).GetComponent<Image>().sprite = bdb.batikList[mdlplc.selectedBatik].thumbnail[index];

        mdlplc.selectedColor = index;
    }
}
