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
    public TextMeshProUGUI Upgrade1CostText;
    public TextMeshProUGUI Upgrade2Am;
    public TextMeshProUGUI Upgrade2CostText;

    [Header("Upgrades")]
    public ulong Upgrade1 = 0;
    public ulong Upgrade2 = 0;

    [Header("Upgrade Checkers")]
    public bool ownedAm1 = false;
    public bool hasUpgrades = false;
    public bool ownedAm2 = false;

    [Header("Variable Values")]
    public ulong clicks = 0;
    public double Upgrade1CostMult;
    public ulong Upgrade1Cost = 100;
    public double Upgrade2CostMult;
    public ulong Upgrade2Cost = 2500;

    [Header("Other")]
    public bool shouldtrigger = false;
    public bool shouldtRiggerII = false;

    #endregion

    // In Start(), remove any existing listeners before adding the new one
    void Start()
    {
        ClickButton.onClick.AddListener(OnButtonClicked); 
        Upgrade1button.onClick.AddListener(PurchaseUpgrade1);
    }


    // Update is called once per frame. Here checks for upgrade ownership and adds the amount of clicks per second to the total clicks
    void Update()
    {
        ClickText.text = clicks.ToString();
        Upgrade1CostText.text = Upgrade1Cost.ToString();
        Upgrade1Am.text = Upgrade1.ToString();
        Upgrade2Am.text = Upgrade2.ToString();

        if (hasUpgrades)
        {
            if (ownedAm1)
            {
                if (Upgrade1 == 1)
                {
                    Upgrade1CostMult = 1.4;
                }
                else
                {
                    Upgrade1CostMult = 1.4 * (Upgrade1 * 1.05);
                }
                Upgrade1Cost = (ulong)(100 * (Upgrade1CostMult * Upgrade1));
                if (shouldtrigger == true)
                {
                    clicks = clicks + Upgrade1;
                    shouldtrigger = false;
                }
                if (ownedAm2)
                {
                    if (Upgrade2 == 1)
                    {
                        Upgrade2CostMult = 1.4;
                    }
                    else
                    {
                        Upgrade2CostMult = 1.4 * (Upgrade2 * 1.05);
                    }
                    Upgrade2Cost = (ulong)(2500 * (Upgrade2CostMult * Upgrade2));

                    if (shouldtRiggerII == true)
                    {
                        clicks = clicks + 10;
                    }

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
        Debug.Log("This is triggered");
        if (hasUpgrades == true)
        {
           shouldtrigger = true; 
        }
    }

    public void PurchaseUpgrade1()
    {
        if (clicks < Upgrade1Cost)
        {
            return;
        }
        else
        {
            hasUpgrades = true;
            ownedAm1 = true;
            clicks = clicks - Upgrade1Cost;
            Upgrade1 = Upgrade1 + 1;
        }

    }

    private System.Collections.IEnumerator OneSecond(bool shouldtRiggerII)
    {
        yield return new WaitForSeconds(1);
         shouldtRiggerII = true;
    }
}

