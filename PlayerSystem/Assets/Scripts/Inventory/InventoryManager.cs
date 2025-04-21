using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;




public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private List<Item> items = new List<Item>();
    [SerializeField] private List<ItemUI> itemUis;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] TextMeshProUGUI moneyText;



    private int money;

    private ItemUI currentSelection;
    private int currentSelectionIndex = 0;
    
    //Debug
    [SerializeField] private CropType startCrop;
    private Seed startSeeds;

    public delegate void OnItemChange(Item item);
    public static OnItemChange OnAddItem;
    public static OnItemChange OnRemoveItem;
    
    public void PurchaseItem(CropType cropType)
    {
        if(money >= cropType.seedPrice)
        {
            money -= cropType.seedPrice;
            moneyText.text = money.ToString();

            Seed seed = new Seed
            {
                crop = cropType,
                count = 1,
                sprite = cropType.seedSprite,
            };
            AddItem(seed);
        }
    }

    public void PickUpHarvest()
    {

    }
    public void AddItem(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].sprite == item.sprite)
            {
                items[i].count += item.count;
                UpdateUI();
                OnAddItem?.Invoke(items[i]);
                return;
            }
        }
        items.Add(item);
        OnAddItem?.Invoke(item);
        UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        int removeIndex = -1;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].sprite == item.sprite)
            {
                items[i].count -= 1;
                OnRemoveItem?.Invoke(items[i]);
                if(items[i].count <= 0) { removeIndex = i;}
                break;
            }
        }
        if(removeIndex != -1)
        {
            items.RemoveAt(removeIndex);
        }
        UpdateUI();
    }
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startSeeds = new Seed();
        startSeeds.crop = startCrop;
        startSeeds.count = 5;
        startSeeds.sprite = startCrop.seedSprite;
        AddItem(startSeeds);
        money = 50;
        moneyText.text = money.ToString();
        //items.Add(strawberrySeeds);
        currentSelection = itemUis[currentSelectionIndex];
        currentSelection.Select();

        shopCanvas.SetActive(true);
        shopCanvas.SetActive(false);

    }

    private void UpdateUI()
    {
        for(int i = 0; i < itemUis.Count; i++)
        {
            if(i < items.Count)
            {
                itemUis[i].SetUI(items[i]);
            }
            else
            {
                itemUis[i].ClearUI();
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            shopCanvas.SetActive(!shopCanvas.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentSelection.Deselect();
            currentSelectionIndex --;
            if(currentSelectionIndex < 0) { currentSelectionIndex = itemUis.Count - 1; }
            currentSelection = itemUis[currentSelectionIndex];
            currentSelection.Select();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSelection.Deselect();
            currentSelectionIndex ++;
            if(currentSelectionIndex >= itemUis.Count) { currentSelectionIndex = 0; }
            currentSelection = itemUis[currentSelectionIndex];
            currentSelection.Select();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            ExecuteSelection();
        }

        //debug
        if(Input.GetKeyDown(KeyCode.O))
        {
            RemoveItem(startSeeds);
        }
    }

    private void ExecuteSelection()
    {
        if(items.Count < currentSelectionIndex) { return;}
        if(items.Count <= 0) { return;}
        if(items[currentSelectionIndex] is Seed)
        {
            Seed seed = items[currentSelectionIndex] as Seed;
            Vector3Int currentSelection = new Vector3Int(PlayerStateManager.Instance.SelectionGridX, PlayerStateManager.Instance.SelectionGridY - 1, 0);
            if(CropManager.Instance.PlantCrop(currentSelection, seed.crop))
            {
                RemoveItem(seed);
            }
        }
    }

    public void SellItem(CropType crop)
    {
        foreach (var item in items)
        {
            if(item is Harvest)
            {
                Harvest harvest = item as Harvest;
                if(harvest.crop == crop)
                {
                    RemoveItem(harvest);
                    money += harvest.crop.harvestPrice;
                    moneyText.text = money.ToString();
                    return;
                }
            }
        }
    }

    public bool Unlock(int unlockPrice)
    {
        if(money >= unlockPrice)
        {
            money -= unlockPrice;
            moneyText.text = money.ToString();
            return true;
        }
        return false;
    }
}
