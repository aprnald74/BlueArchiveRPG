using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ButtonType
{
    End,
    Return
}
public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public ButtonType CurrentType;

    private Button btn;
    private Vector3 originalScale;

    private float scaleFactor = 0.9f;
    private bool isButtonDown;

    void Start()
    {
        btn = this.gameObject.GetComponent<Button>();
        originalScale = btn.transform.localScale;
    }

    public void OnPointerDown(PointerEventData evetnData)
    {
        BtnEvent();
        isButtonDown = true;
    }
    
    public void OnPointerUp(PointerEventData evetnData)
    {
        if (isButtonDown)
        {
            isButtonDown = false;
            switch (CurrentType)
            {
                case ButtonType.End:
                    GameManager.Instance.Previous();
                    break;
            
                case ButtonType.Return:
                    GameManager.Instance.PopUpHide();
                    break;
            }
        }
    }

    void BtnEvent()
    {
        LeanTween.scale(btn.gameObject, originalScale * scaleFactor, 0.2f)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(btn.gameObject, originalScale, 0.2f)
                    .setEase(LeanTweenType.easeInQuad);
            });
    }
}
