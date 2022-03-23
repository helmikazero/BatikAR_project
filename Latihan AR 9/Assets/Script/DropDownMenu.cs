using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropDownMenu : MonoBehaviour
{
    public float fadeSpeed = 1f;

    public RectTransform dropMenu;
    public RectTransform dropButton;
    public RectTransform dropButtonFollowPos;

    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;

        dropMenu.anchoredPosition = new Vector3(0, dropMenu.rect.height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        dropButton.position = dropButtonFollowPos.position;
    }


    public void TOGGLE_DROP()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            dropMenu.DOAnchorPosY(0f, fadeSpeed, false);
        }
        else
        {
            dropMenu.DOAnchorPosY(dropMenu.rect.height, fadeSpeed, false);
        }
    }
}
