using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class Reclama : MonoBehaviour
{
    public string idAdv;
    
      private void OnEnable()
      {
        YG2.onRewardAdv += Rewarded;
      } 

      private void OnDisable()
      {
        YG2.onRewardAdv -= Rewarded;
      }

      private void Rewarded(string id)
      {
        if(id == idAdv)
        {
            SetReward();
        }
      } 

      public void SetReward()
      {
        int totalMoney = PlayerPrefs.GetInt("totalMoney");
        PlayerPrefs.SetInt("totalMoney", totalMoney + 100);
      }

      public void ShowRewardAdv_UseCallback()
      {
        YG2.RewardedAdvShow(idAdv, () =>
        {

            SetReward();
        });
      }
   
    
}
