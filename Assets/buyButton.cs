using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyButton : MonoBehaviour
{
    public enum ItemType
    {
        Coins200,
        Coins550,
        Coins1200,
        Coins2800,
        Coins4500,
        Coins10000,
        Coins30000,
        NoAds
    }

    public ItemType itemType;

    public Text priceText;

    private string defaultText;

    void Start()
    {
        defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void ClickBuy()
    {
        switch(itemType)
        {
            case ItemType.Coins200:
                IAPManager.Instance.Buy200Coins();
                break;
            case ItemType.Coins550:
                IAPManager.Instance.Buy550Coins();
                break;
            case ItemType.Coins1200:
                IAPManager.Instance.Buy1200Coins();
                break;
            case ItemType.Coins2800:
                IAPManager.Instance.Buy2800Coins();
                break;
            case ItemType.Coins4500:
                IAPManager.Instance.Buy4500Coins();
                break;
            case ItemType.Coins10000:
                IAPManager.Instance.Buy10000Coins();
                break;
            case ItemType.Coins30000:
                IAPManager.Instance.Buy30000Coins();
                break;
            case ItemType.NoAds:
                IAPManager.Instance.BuyNoAds();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while(!IAPManager.Instance.IsInitialized())
        {
            yield return null;
        }

        string loadedPrice = "";

        switch (itemType)
        {
            case ItemType.Coins200:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_200);
                break;
            case ItemType.Coins550:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_550);
                break;
            case ItemType.Coins1200:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_1200);
                break;
            case ItemType.Coins2800:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_2800);
                break;
            case ItemType.Coins4500:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_4500);
                break;
            case ItemType.Coins10000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_10000);
                break;
            case ItemType.Coins30000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.COINS_30000);
                break;
            case ItemType.NoAds:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.NO_ADS);
                break;
        }

        priceText.text = defaultText + " " + loadedPrice;


    }
}
