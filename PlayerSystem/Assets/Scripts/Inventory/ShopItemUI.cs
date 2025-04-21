using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private CropType crop;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI sellPriceText;
    [SerializeField] private TextMeshProUGUI unlockPriceText;
    [SerializeField] private TextMeshProUGUI cropNameText;
    [SerializeField] private TextMeshProUGUI cropInbagText;
    [SerializeField] private GameObject lockPanel;
    private bool isUnlock = false;
    //[SerializeField] private Button purchaseButton;
    // Start is called before the first frame update
    void Start()
    {
        SetupCrop();
        InventoryManager.OnAddItem += OnUpdateItem;
        InventoryManager.OnRemoveItem += OnUpdateItem;
    }

    private void OnUpdateItem(Item item)
    {
        if(item is Harvest)
        {
            Harvest harvest = item as Harvest;
            if(harvest.crop == crop)
            {
                cropInbagText.text = "In bag : " + harvest.count.ToString();
                Debug.Log("UPDATE SHOP");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Unlock()
    {
        if(InventoryManager.Instance.Unlock(crop.unlockPrice))
        {
            lockPanel.SetActive(false);
            isUnlock = true;
        }
    }

    public void SetupCrop()
    {
        itemImage.sprite = crop.shopSprite;
        priceText.text = "X " + crop.seedPrice.ToString();
        cropNameText.text = crop.name;
        sellPriceText.text = "X " + crop.harvestPrice.ToString();
        unlockPriceText.text = "X " + crop.unlockPrice.ToString();
    }

    public void Purchase()
    {
        InventoryManager.Instance.PurchaseItem(crop);
    }

    public void Sell()
    {
        InventoryManager.Instance.SellItem(crop);
    }
}
