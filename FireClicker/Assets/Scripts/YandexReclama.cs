using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class YandexReclama : MonoBehaviour
{
   public string rewardID;
   
   public Menu scripts;

     void Start()
    {
      scripts = GetComponent<Menu>();
    }
	// Вызов рекламы за вознаграждение
    public void MyRewardAdvShow()
    {
        YG2.RewardedAdvShow(rewardID, () =>
        {
            // Получение вознаграждения
           scripts.money = scripts.money * 2;

			// По желанию, воспользуйтесь ID вознаграждения
			if (rewardID == "money")
				  scripts.money = scripts.money * 2;
        });
    }
}
