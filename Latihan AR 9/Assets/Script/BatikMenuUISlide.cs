using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BatikMenuUISlide : MonoBehaviour
{
    public RectTransform batikPanel;
    public float smoothDuration = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CLOSE_PANEL()
    {
        batikPanel.DOAnchorPosX(batikPanel.rect.width, smoothDuration, false);
    }

    public void OPEN_PANEL()
    {
        batikPanel.DOAnchorPosX(0f, smoothDuration, false);
    }
}
