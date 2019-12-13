using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionDisplay : MonoBehaviour
{

    public Potion potion;
    public Image potionImage;

    public TextMeshProUGUI potionNameAndCostText;
    public TextMeshProUGUI potionDescriptionText;

    // Start is called before the first frame update
    void Start()
    {
        potionImage.sprite = potion.icon;
    }

    public void ShowDetailsOfPotion()
    {
        potionNameAndCostText.text = "<b>" + potion.potionName + "</b>" + 
            " " +  
            "<color=#ffa500ff>" + "<size=16>" + "$$" + potion.cost.ToString() +
            "</i>" + "</size=16>";
        potionDescriptionText.text = potion.description;
    }
}
