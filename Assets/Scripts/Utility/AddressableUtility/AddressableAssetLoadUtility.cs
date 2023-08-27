using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetLoadUtility : SingletonMonoBehaviour<AddressableAssetLoadUtility>
{
    private AsyncOperationHandle assetOperation = new AsyncOperationHandle();

    public T LoadAssetAsync<T>(string address) where T : Object
    {
        assetOperation = Addressables.LoadAssetAsync<T>(address);
        var asset = assetOperation.WaitForCompletion();
        return (T)asset;
    }

    private void OnDestroy()
    {
        if(assetOperation.IsValid())
        {
            Addressables.Release(assetOperation);
        }
    }
}
