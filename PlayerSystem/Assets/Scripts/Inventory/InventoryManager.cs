using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;




public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private List<Item> items = new List<Item>();
    [SerializeField] private List<ItemUI> itemUis;
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] TextMeshProUGUI moneyText;

    private int money;
    
    //Debug
    [SerializeField] private Crop strawberry;
    private Item strawberrySeeds;
    
    public void PurchaseItem(Crop crop)
    {
        if(money >= crop.seedPrice)
        {
            money -= crop.seedPrice;
            moneyText.text = money.ToString();

            Item seed = new Item();
            //seed.crop = crop;
            seed.count = 1;
            seed.sprite = crop.seedSprite;
            AddItem(seed);
        }
    }
    public void AddItem(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].sprite == item.sprite)
            {
                items[i].count += item.count;
                UpdateUI();
                return;
            }
        }
        items.Add(item);
        UpdateUI();
        // if(items.Contains(item))
        // {
        //     items[items.IndexOf(item)].count += item.count;
        // }
        // else
        // {
        //     items.Add(item);
        // }
        // UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        int removeIndex = -1;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].sprite == item.sprite)
            {
                items[i].count -= 1;
                if(items[i].count <= 0) { removeIndex = i;}
                break;
            }
        }
        if(removeIndex != -1)
        {
            items.RemoveAt(removeIndex);
        }
        UpdateUI();


        // if(items.Contains(item))
        // {
        //     if(items[items.IndexOf(item)].count > 0)
        //     {
        //         items[items.IndexOf(item)].count -= 1;
        //         if(items[items.IndexOf(item)].count == 0)
        //         {
        //             items.RemoveAt(items.IndexOf(item));
        //         }
        //     }
        //     UpdateUI();
        // }
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
        strawberrySeeds = new Item();
        //strawberrySeeds.crop = strawberry;
        strawberrySeeds.count = 5;
        strawberrySeeds.sprite = strawberry.seedSprite;
        AddItem(strawberrySeeds);
        money = 500;
        moneyText.text = money.ToString();
        //items.Add(strawberrySeeds);

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
        if(Input.GetKeyDown(KeyCode.O))
        {
            RemoveItem(strawberrySeeds);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            shopCanvas.SetActive(!shopCanvas.activeSelf);
        }
    }
}
