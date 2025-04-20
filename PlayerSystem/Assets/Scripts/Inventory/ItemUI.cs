using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemUI : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemCountText;

    public void SetUI(Item item)
    {
        itemImage.sprite = item.sprite;
        itemCountText.text = item.count.ToString();
        itemImage.color = new Color(255, 255, 255, 1);
    }

    public void ClearUI()
    {
        itemImage.sprite = defaultSprite;
        itemImage.color = new Color(255, 255, 255, 0);
        itemCountText.text = "";
    }
}
