using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Booster : MonoBehaviour
{
    [Header("Настройки бустера")]
    public string boosterID;
    public float startCost = 100;
    public int incomeBonus = 50;
    public float duration = 0f; // 0 = вечный
    public float tickSpeed = 0.5f;
    public bool isFirstBooster = false;

    [Header("Ссылки на объекты")]
    public TMP_Text costText; 
    public Button thisButton;
    public Button nextBoosterButton;
    public AudioSource soundBoost;

    private float currentCost;
    private int currentCPS;
    private float currentTimer;
    private Coroutine activeCoroutine;
    private Menu menuScript;

    void Start()
    {
        // УДАЛЕНО: PlayerPrefs.DeleteAll(); <- Это удаляло ваше сохранение при старте!
        menuScript = FindObjectOfType<Menu>();
        
        LoadData();
        UpdateUI();

        if (currentCPS > 0)
        {
            activeCoroutine = StartCoroutine(IncomeLoop());
        }
    }

    public void TryBuy()
    {
        if (menuScript.money >= currentCost)
        {
            menuScript.money -= (int)currentCost;
            currentCPS += incomeBonus;
            currentCost *= 1.5f; 
        
            if (duration > 0) currentTimer = duration;

            // --- УНИВЕРСАЛЬНАЯ РАЗБЛОКИРОВКА СЛЕДУЮЩЕГО ОБЪЕКТА ---
            if (nextBoosterButton != null)
            {
                // Пытаемся найти ЛЮБОЙ из двух скриптов на следующей кнопке
                var nextB = nextBoosterButton.GetComponent<Booster>();
                var nextC = nextBoosterButton.GetComponent<CursorUpgrade>(); // Наш скрипт на клики

                if (nextB != null)
                {
                    PlayerPrefs.SetInt(nextB.boosterID + "_Unlocked", 1);
                    nextB.UpdateUI(); // Метод должен быть public!
                }
                else if (nextC != null)
                {
                    PlayerPrefs.SetInt(nextC.upgradeID + "_Unlocked", 1);
                    nextC.UpdateUI(); // Метод должен быть public!
                }
            
                nextBoosterButton.interactable = true;
                PlayerPrefs.Save();
            }
            // -------------------------------------------------------

            if (activeCoroutine == null)
                activeCoroutine = StartCoroutine(IncomeLoop());

            SaveData();
            UpdateUI();
            if (soundBoost != null) soundBoost.Play();
        }
        else
        {
            if (menuScript.bomzh != null) menuScript.bomzh.Play();
        }
    }

    IEnumerator IncomeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickSpeed);
            menuScript.money += currentCPS;
            
            if (duration > 0)
            {
                currentTimer -= tickSpeed;
                if (currentTimer <= 0)
                {
                    currentCPS = 0;
                    activeCoroutine = null;
                    SaveData();
                    UpdateUI(); // Обновить текст, если доход пропал
                    yield break;
                }
            }
        }
    }

    public void UpdateUI()
    {
        // Обновляем текст цены
        if (costText != null)
        {
            costText.text = FormatNumber(currentCost).ToString() + "$";
        }

        // Проверка разблокировки для текущей кнопки
        bool isUnlocked = PlayerPrefs.GetInt(boosterID + "_Unlocked", 0) == 1;
        thisButton.interactable = (isFirstBooster || isUnlocked || currentCPS > 0);
    }

    void SaveData()
    {
        PlayerPrefs.SetFloat(boosterID + "_Cost", currentCost);
        PlayerPrefs.SetInt(boosterID + "_CPS", currentCPS);
        PlayerPrefs.SetFloat(boosterID + "_Timer", currentTimer);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        currentCost = PlayerPrefs.GetFloat(boosterID + "_Cost", startCost);
        currentCPS = PlayerPrefs.GetInt(boosterID + "_CPS", 0);
        currentTimer = PlayerPrefs.GetFloat(boosterID + "_Timer", 0);
    }

    public string FormatNumber(float num) 
    { 
        if (num >= 1000000) 
            return (num / 1000000).ToString("0.##") + "M"; 
        else if (num >= 1000) 
            return (num / 1000).ToString("0.##") + "K"; 
        else 
            return num.ToString(); 
    } 
}