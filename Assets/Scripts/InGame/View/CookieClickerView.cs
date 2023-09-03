using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CookieClickerView : MonoBehaviour
{
    public TextMeshProUGUI cookieCountText;
    public Button clickButton;

    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = "Cookies: " + count.ToString();
    }

    public void SetClickButtonAction(System.Action onClick)
    {
        clickButton.onClick.AddListener(() => 
        {
            Debug.Log("DebugLog");
            onClick?.Invoke();
        });
        
    }

    public void SetButtonImage(Sprite cookieSprite)
    {
        clickButton.image.sprite = cookieSprite;
    }
}
