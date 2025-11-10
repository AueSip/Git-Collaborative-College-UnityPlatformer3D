using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Script_UI_Handler : MonoBehaviour
{
    public Image SliderBar;

    private float sliderSize;
    private float sliderMinSize;

    private float currentFlashlightPercent;

    public TextMeshProUGUI generatorCount;

    public TextMeshProUGUI vampireCount;

    public TextMeshProUGUI npcWants;

    public TextMeshProUGUI itemInHand;

    float ogSize = 120;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSliderPercentage(float flashlightPercent)
    {
        currentFlashlightPercent = flashlightPercent;
        float minSize = 0;
        SliderBar.rectTransform.sizeDelta = new Vector2(ogSize * currentFlashlightPercent, SliderBar.rectTransform.sizeDelta[1]);
        print("NEW SIZE: " + SliderBar.rectTransform.sizeDelta);
    }

    public void SetCountForText(float count, float total, TextMeshProUGUI vtext)
    {
        vtext.text = (count + "/" + total).ToString();
    }

    public TextMeshProUGUI GetGeneratorText()
    {
        return generatorCount;
    }

    public TextMeshProUGUI GetVampireCount()
    {
        return vampireCount;
    }

    public void SetNPCWant(string textotuse)
    {
        npcWants.text = textotuse;
    }

     public void SetItemInHand(string textotuse)
    {
        itemInHand.text = textotuse;
    }

}
