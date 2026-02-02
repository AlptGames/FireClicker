using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CursorUpgrade : MonoBehaviour, IPointerDownHandler
{
    [Header("Настройки улучшения")]
    public string upgradeID; 
    public int plusClickPower = 1;
    public float startPrice = 10;
    public bool isFirstUpgrade = false;

    [Header("Ссылки")]
    public Menu osnScript;
    public TMP_Text costText;
    public Button thisButton;
    public Button nextUpgradeButton; // Ссылка на СЛЕДУЮЩУЮ кнопку (как в Booster)

    [Header("Звуки")]
    public AudioSource buySound;
    public AudioSource failSound;

    private float currentPrice;

    void Start()
    {
        LoadData();
        UpdateUI();
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        // Проверяем interactable вручную, так как IPointerDown срабатывает даже на выключенной кнопке
        if (!thisButton.interactable) return;

        if(osnScript.money >= currentPrice)
        {
            osnScript.money -= (int)currentPrice;
            osnScript.moneyForClcik += plusClickPower;
            
            currentPrice *= 2; // Удорожание

            // РАЗБЛОКИРОВКА СЛЕДУЮЩЕГО
            UnlockNext();

            SaveData();
            UpdateUI();
            if (buySound != null) buySound.Play();
        }
        else
        {
            if (failSound != null) failSound.Play();
        }
    }

    public void UpdateUI()
    {
        if (costText != null)
            costText.text = FormatNumber(currentPrice) + " $";

        // Кнопка активна если: она первая, или уже куплена/разблокирована
        bool isUnlocked = PlayerPrefs.GetInt(upgradeID + "_Unlocked", 0) == 1;
        thisButton.interactable = isFirstUpgrade || isUnlocked;
    }

    public void UnlockNext()
    {
        if (nextUpgradeButton != null)
        {
            // Пытаемся найти на следующей кнопке либо скрипт Курсора, либо скрипт Бустера
            var nextCursor = nextUpgradeButton.GetComponent<CursorUpgrade>();
            var nextBooster = nextUpgradeButton.GetComponent<Booster>();

            if (nextCursor != null)
            {
                PlayerPrefs.SetInt(nextCursor.upgradeID + "_Unlocked", 1);
                nextCursor.UpdateUI();
            }
            else if (nextBooster != null)
            {
                PlayerPrefs.SetInt(nextBooster.boosterID + "_Unlocked", 1);
                nextBooster.SendMessage("UpdateUI"); // Вызов метода UpdateUI у бустера
            }
        }
        PlayerPrefs.Save();
    }

    void SaveData()
    {
        PlayerPrefs.SetFloat(upgradeID + "_Price", currentPrice);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        currentPrice = PlayerPrefs.GetFloat(upgradeID + "_Price", startPrice);
    }

    public string FormatNumber(float num) 
    { 
        if (num >= 1000000) return (num / 1000000).ToString("0.##") + "M"; 
        else if (num >= 1000) return (num / 1000).ToString("0.##") + "K"; 
        else return num.ToString("0"); 
    }
}