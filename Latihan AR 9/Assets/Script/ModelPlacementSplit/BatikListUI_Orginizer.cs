using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




    ["Dependencies"]
    public BatikDatabase bdb;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < batikList.Length; i++)
        {
            for (int j = 0; j < batikList[i].spawnedBatikModel.Length; j++)
            {
                batikList[i].spawnedBatikModel[j].SetActive(false);
            }

            GameObject spawnedBatikButton = Instantiate(UIBajuListPrefab, listSpot);
            spawnedBatikButton.transform.GetChild(0).GetComponent<Text>().text = batikList[i].name;
            spawnedBatikButton.transform.GetChild(1).GetComponent<Image>().sprite = batikList[i].thumbnail[0];
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
}
