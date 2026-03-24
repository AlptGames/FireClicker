using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Reclama3 : MonoBehaviour
{
     public string idAdv;
    public Menu script; // Убедись, что в инспекторе перетащил объект со скриптом Menu

    void Start()
    {
        if (script == null) script = GetComponent<Menu>();
    }

    private void OnEnable() => YG2.onRewardAdv += Rewarded;
    private void OnDisable() => YG2.onRewardAdv -= Rewarded;

    private void Rewarded(string id)
    {
        if (id == idAdv)
        {
            SetReward();
        }
    }

    public void SetReward()
    {
        // 1. Увеличиваем деньги в самом скрипте Menu
        script.money *= 2; 
        
        // 2. Обновляем интерфейс
        script.UpdateUI();
        
        // 3. Сохраняем результат в PlayerPrefs один раз
        script.SaveData(); 

        Debug.Log("Награда получена! Деньги удвоены.");
    }

    public void ShowRewardAdv_UseCallback()
    {
        // Вызываем рекламу
        YG2.RewardedAdvShow(idAdv);
    }
}
