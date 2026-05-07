using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;
public class ClickingButton : MonoBehaviour
{
    #region //Variables

    [Header("Buttons")]
    public Button ClickButton;
    public Button Upgrade1button;

    [Header("Texts")]
    public TextMeshProUGUI ClickText;
    public TextMeshProUGUI Upgrade1Am;

    [Header("Upgrades")]
    public ulong Upgrade1 = 0;

    [Header("Upgrade Checkers")]
    public bool ownedAm1 = false;
    public bool hasUpgrades = false;

    [Header("Variable Values")]
    public ulong clicks = 0;

    [Header("Other")]
    public bool shouldtrigger = false;

    #endregion
    //Establishes the buttons and their functions
    void Start()
    {
        ClickButton.onClick.AddListener(OnButtonClicked);
        Upgrade1button.onClick.AddListener(PurchaseUpgrade1);
    }


    // Update is called once per frame. Here checks for upgrade ownership and adds the amount of clicks per second to the total clicks
    void Update()
    {
        ClickText.text = clicks.ToString();
        if (hasUpgrades)
        {
            if (ownedAm1)
            {
                if (shouldtrigger == true)
                {
                    clicks = clicks + Upgrade1;
                    shouldtrigger = false;
                }
            }
            shouldtrigger = false;
        }
        else
        {
            clicks = clicks + 0;
        }
    }

    // Converts clicks to string and adds 1 click per click
    public void OnButtonClicked()
    {
        clicks++;
        shouldtrigger = true;
    }

    public void PurchaseUpgrade1()
    {
        if (clicks < 100)
        {
            return;
        }
        else
        {
            hasUpgrades = true;
            ownedAm1 = true;
            clicks = clicks - 100;
            Upgrade1 = Upgrade1 + 1;
            Upgrade1Am.text = Upgrade1.ToString();
            

        }

    }


}