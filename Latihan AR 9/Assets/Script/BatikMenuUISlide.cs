using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BatikMenuUISlide : MonoBehaviour
{
    public RectTransform batikPanel;
    public float smoothDuration = 0.5f;

    public bool listOpened = false;


    // Start is called before the first frame update
    void Start()
    {
        CLOSE_PANEL();
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

    public void TOGGLE_PANEL()
    {
        if (!listOpened)
        {
            listOpened = true;
            OPEN_PANEL();
        }
        else
        {
            listOpened = false;
            CLOSE_PANEL();
        }
    }
}
