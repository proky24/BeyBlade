using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text useButtonLabel;
    [SerializeField]
    private ShopManager shopManager;
    private int currentIndex = 0;
    private List<BeybladePart> currentParts = new List<BeybladePart>();
    public void ChangePartsMenu(string partName)
    {
        currentParts = shopManager.GetBeybladeParts(partName);
    }
    private void UpdateInfo()
    {
        if (currentParts[currentIndex].IsBought)
            useButtonLabel.text = "USE";
        else
            useButtonLabel.text = "BUY";
    }
    public void Next()
    {
        if (currentIndex + 1 >= currentParts.Count)
            return;

        currentIndex++;

        UpdateInfo();
    }
    public void Previous()
    {
        if (currentIndex - 1 < 0)
            return;

        currentIndex--;

        UpdateInfo();
    }
}