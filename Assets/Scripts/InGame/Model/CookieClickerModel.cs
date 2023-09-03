using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CookieClickerModel
{
    private int cookieClickCount;

    public int GetCookieClickCount()
    {
        return cookieClickCount;
    }

    private Sprite cookieImageSprite;

    public Sprite GetCookieImageSprite
    {
        get
        {
            return cookieImageSprite;
        }
    }

    public void AddCookieClickCount(int amount)
    {
        cookieClickCount += amount;
    }

    public void SaveCookieClickCount()
    {
        var saveData = new PlayerSaveData(string.Empty, cookieClickCount);
        JsonSaveUtility.Save(saveData);
    }

    public void LoadCookieClickCount()
    {
        var loadPlayerData = JsonSaveUtility.Load<PlayerSaveData>();
        // 保存しているデータがある場合
        if (loadPlayerData != null)
        {
            cookieClickCount = loadPlayerData.PlayerScore;
            return;
        }
        cookieClickCount = 0;
    }

    public bool LoadedAsset = false;

    public async UniTask AssetsLoad()
    {
        LoadedAsset = false;
        IEnumerable assetslabel = new string[]
        {
            "CookieImages"
        };

        await AddressableAssetLoadUtility.Instance.CheckCatalogUpdates();
        await AddressableAssetLoadUtility.Instance.GetDownloadSize(assetslabel);
        LoadedAsset = true;
    }

    public void LoadCookieImage()
    {
        //var cookieSprite = AddressableAssetLoadUtility.Instance.LoadAssetAsync<Sprite>("CookieImage_0");
        //cookieImageSprite = cookieSprite;

    }
}