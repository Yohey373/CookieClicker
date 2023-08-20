using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClickerPresenter : MonoBehaviour
{
    private CookieClickerModel cookieClickerModel;
    private CookieClickerView cookieClickerView;
    
    // Start is called before the first frame update
    private void Start()
    {
        cookieClickerModel = new CookieClickerModel();
        cookieClickerModel.LoadCookieClickCount();
        cookieClickerModel.LoadCookieImage();

        cookieClickerView = GetComponent<CookieClickerView>();

        cookieClickerView.SetClickButtonAction(OnClickCookie);
        cookieClickerView.SetButtonImage(cookieClickerModel.GetCookieImageSprite);
        
        UpdateCookieUI();
    }

    private void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    private void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetCookieClickCount());
    }

    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
