using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClickerPresenter : MonoBehaviour
{
    internal CookieClickerModel cookieClickerModel;
    internal CookieClickerView cookieClickerView;
    
    private InGameStateMachine stateMachine;

    internal InGameStateMachine GetMainGameState
    {
        get { return stateMachine; }
    }

    public InGameStateInit InGameStateInit;
    public InGameStateStart InGameStateStart;
    public InGameStateMain InGameStateMain;
    public InGameStateResult InGameStateResult;
    public InGameStateEnd InGameStateEnd;

    // Start is called before the first frame update
    private async void Start()
    {
        stateMachine = new InGameStateMachine();

        InGameStateInit = new InGameStateInit(stateMachine, this);
        InGameStateStart = new InGameStateStart(stateMachine, this);
        InGameStateMain = new InGameStateMain(stateMachine, this);
        InGameStateResult = new InGameStateResult(stateMachine, this);
        InGameStateEnd = new InGameStateEnd(stateMachine, this);

        stateMachine.ChangeState(InGameStateInit);

        cookieClickerModel = new CookieClickerModel();
        cookieClickerModel.LoadCookieClickCount();

        IEnumerable assetslabel = new string[]
        {
            "CookieImages"
        };

        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetslabel);

        cookieClickerModel.LoadCookieImage();

        cookieClickerView = GetComponent<CookieClickerView>();

        cookieClickerView.SetClickButtonAction(OnClickCookie);
        cookieClickerView.SetButtonImage(cookieClickerModel.GetCookieImageSprite);
        
        UpdateCookieUI();
    }

    public void OnClickCookie()
    {
        cookieClickerModel.AddCookieClickCount(1);
        UpdateCookieUI();
    }

    public void UpdateCookieUI()
    {
        cookieClickerView.UpdateCookieCount(cookieClickerModel.GetCookieClickCount());
    }

    private void OnDestroy()
    {
        cookieClickerModel.SaveCookieClickCount();
    }
}
