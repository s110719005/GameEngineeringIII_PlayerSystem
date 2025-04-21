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
    [SerializeField] private TextMeshProUGUI cropNameText;
    //[SerializeField] private Button purchaseButton;
    // Start is called before the first frame update
    void Start()
    {
        SetupCrop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupCrop()
    {
        itemImage.sprite = crop.shopSprite;
        priceText.text = "X " + crop.seedPrice.ToString();
        cropNameText.text = crop.name;
    }

    public void Purchase()
    {
        InventoryManager.Instance.PurchaseItem(crop);
    }
}
