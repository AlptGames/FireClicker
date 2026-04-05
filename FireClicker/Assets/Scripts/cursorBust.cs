using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CursorUpgrade : MonoBehaviour, IPointerDownHandler
{
    [Header("��������� ���������")]
    public string upgradeID; 
    public int plusClickPower = 1;
    public float startPrice = 10;
    public bool isFirstUpgrade = false;

    [Header("������")]
    public Menu osnScript;
    public TMP_Text costText;
    public Button thisButton;
    public Button nextUpgradeButton; // ������ �� ��������� ������ (��� � Booster)

    [Header("�����")]
    public AudioSource buySound;
    public AudioSource failSound;

    private float currentPrice;

    public Image cursor;
    public Sprite customCursor;

    void Start()
    {
        LoadData();
        UpdateUI();
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        // ��������� interactable �������, ��� ��� IPointerDown ����������� ���� �� ����������� ������
        if (!thisButton.interactable) return;

        if(osnScript.money >= currentPrice)
        {
            osnScript.money -= (int)currentPrice;
            osnScript.moneyForClcik += plusClickPower;
            
            currentPrice *= 2; // ����������

            // ������������� ����������
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
            costText.text = FormatNumber(currentPrice);

        // ������ ������� ����: ��� ������, ��� ��� �������/��������������
        bool isUnlocked = PlayerPrefs.GetInt(upgradeID + "_Unlocked", 0) == 1;
        thisButton.interactable = isFirstUpgrade || isUnlocked;
        cursor.sprite = customCursor;
    }

    public void UnlockNext()
    {
        if (nextUpgradeButton != null)
        {
            // �������� ����� �� ��������� ������ ���� ������ �������, ���� ������ �������
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
                nextBooster.SendMessage("UpdateUI"); // ����� ������ UpdateUI � �������
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