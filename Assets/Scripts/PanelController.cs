using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemStory;
    [SerializeField]
    private Image itemDisplay;

    public void SetItemName(string _name)
    {
        itemName.text=_name;
    }

    public void SetItemStory(string _story)
    {
        itemStory.text=_story;
    }

    public void SetItemImage(Sprite _sprite)
    {
        
    }
}
