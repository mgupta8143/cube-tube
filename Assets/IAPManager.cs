using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : Singleton<IAPManager>, IStoreListener
{
    // Start is called before the first frame update
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public string COINS_200 = "coins_200";
    public string COINS_550 = "coins_550";
    public string COINS_1200 = "coins_1200";
    public string COINS_2800 = "coins_2800";
    public string COINS_4500 = "coins_4500";
    public string COINS_10000 = "coins_10000";
    public string COINS_30000 = "coins_30000";
    public string NO_ADS = "no_ads";
    public AudioSource moneySound;
    public AudioClip moneys;

    public GameObject adButton;


    void Start()
    {
        if(PlayerPrefs.GetInt("AdPurchased") == 1)
        {
            adButton.SetActive(false);
            AdManager.setAds(false);
        }
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add a product to sell / restore by way of its identifier, associating the general identifier
        // with its store-specific identifiers.
        builder.AddProduct(COINS_200, ProductType.Consumable);
        builder.AddProduct(COINS_550, ProductType.Consumable);
        builder.AddProduct(COINS_1200, ProductType.Consumable);
        builder.AddProduct(COINS_2800, ProductType.Consumable);
        builder.AddProduct(COINS_4500, ProductType.Consumable);
        builder.AddProduct(COINS_10000, ProductType.Consumable);
        builder.AddProduct(COINS_30000, ProductType.Consumable);

        // Continue adding the non-consumable product.
        builder.AddProduct(NO_ADS, ProductType.NonConsumable);
       
        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
    }


    public bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void Buy200Coins() {BuyProductID(COINS_200);}
    public void Buy550Coins() { BuyProductID(COINS_550); }
    public void Buy1200Coins() { BuyProductID(COINS_1200); }
    public void Buy2800Coins() { BuyProductID(COINS_2800); }
    public void Buy4500Coins() { BuyProductID(COINS_4500); }
    public void Buy10000Coins() { BuyProductID(COINS_10000); }
    public void Buy30000Coins() { BuyProductID(COINS_30000); }

    public void BuyNoAds()
    {
        BuyProductID(NO_ADS);
    }

    public string GetProductPriceFromStore(string id)
    {
        if (m_StoreController != null && m_StoreController.products != null)
        {
            return m_StoreController.products.WithID(id).metadata.localizedPriceString;

        }
        else
            return "";
    }


 
    void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }


    // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
    // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
    /*
    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }
    */


    //  
    // --- IStoreListener
    //

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, COINS_200, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 200);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);



        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_550, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 550);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);


        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_1200, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 1200);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);


        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_2800, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 2800);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);


        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_4500, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 4500);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);


        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_10000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 10000);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);



        }
        else if (String.Equals(args.purchasedProduct.definition.id, COINS_30000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 30000);
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
            moneySound.PlayOneShot(moneys);

        }
        else if (String.Equals(args.purchasedProduct.definition.id, NO_ADS, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            // TODO: The subscription item has been successfully purchased, grant this to the player.
            if (PlayerPrefs.GetInt("AdPurchased", 0) == 0)
            {
                AdManager.setAds(false);
                adButton.SetActive(false);
                PlayerPrefs.SetInt("AdPurchased", 1);
                moneySound.PlayOneShot(moneys);

            }
            GameObject.Find("Count").GetComponent<Text>().text = PlayerPrefs.GetInt("CoinCount").ToString();
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        // Return a flag indicating whether this product has completely been received, or if the application needs 
        // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
        // saving purchased products to the cloud, and when that save is delayed. 
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
