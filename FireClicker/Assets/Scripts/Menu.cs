using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using YG;

public class Menu : MonoBehaviour
{
     public int money; // это деньги за клик? нет
     public TMP_Text moneyText;
     public int totalMoney;
     public GameObject effect;
     public GameObject button;
     public AudioSource sound;
     public AudioSource soundGrafiti;
     bool chlen = true;
     public GameObject graffiti;//
     public GameObject graffiti2;//
     public GameObject graffiti3;// там где комментарии

     public int gr;

     bool chlen2 = true;
     bool chlen3 = true;
     bool chlenS = true;
     public Sprite skin;
     public Image buttonImage;
     public AudioSource SkinSound;
     public AudioSource soundBoost;
     
     public Sprite skin1; // ПОГНААААААААА

     public int sk;

     public Sprite skin2;
     bool chlen4 = true;

     public Sprite skin3;
     bool chlen5 = true;

     public Sprite skin4;
     bool chlen6 = true;

     bool bool1 = true;
     bool bool2 = true;
     bool bool3 = true;
     public Image bgImage; // это тоже? да пiH
     public Sprite bgSkin0;
     public Sprite bgSkin1;
     public Sprite bgSkin2;
     public Sprite bgSkin3;

     public int bgSk;

     public int moneyForClcik = 1;
     public Slider slider;
     public int currentLevel;
     private int n = 1;
     public TextMeshProUGUI levelText;
     public float nuzhnodenegchtoburovenapnut = 100;
     public int levelPoints;
     public AudioSource soundSliderLevel;

     public GameObject shopContent;
     public GameObject shopButton;
     public bool canShop = true;
     public bool canSkins = true;
     public bool canGraffities = true;
     public bool canWalls = true;
     public GameObject skinsShopContent;
     public GameObject graffitiesShopContent;
     public GameObject wallsShopContent;

     public bool isSkin1Bought, isSkin2Bought, isSkin3Bought, isSkin4Bought;
     private int activeSkinIndex; 

     public bool isGrafffity1 = false;
     public bool isGrafffity2 = false;
     public bool isGrafffity3 = false;

     public bool isWall1 = false;
     public bool isWall2 = false;
     public bool isWall3 = false;


     public GameObject skin1CostText;
     public GameObject skin2CostText;
     public GameObject skin3CostText;
     public GameObject skin4CostText;

     public GameObject bgSkin1CostText;
     public GameObject bgSkin2CostText;
     public GameObject bgSkin3CostText;

     public GameObject graffity1CostText;
     public GameObject graffity2CostText;
     public GameObject graffity3CostText;

     public AudioSource bomzh;

     public bool isBG1Bought, isBG2Bought, isBG3Bought;
     private int activeBGIndex;

      

     private void Start()
     {
         money = PlayerPrefs.GetInt("money");
         totalMoney = PlayerPrefs.GetInt("totalMoney");
         currentLevel = PlayerPrefs.GetInt("currentLevel");
         chlen = PlayerPrefs.GetInt("chlen") == 0;
         moneyForClcik = PlayerPrefs.GetInt("moneyForClcik", 1);
         levelPoints = PlayerPrefs.GetInt("levelPoints");

         isGrafffity1 = PlayerPrefs.GetInt("isGrafffity1", 0) == 1;
         isGrafffity2 = PlayerPrefs.GetInt("isGrafffity2", 0) == 1;
         isGrafffity3 = PlayerPrefs.GetInt("isGrafffity3", 0) == 1;

         isSkin1Bought = PlayerPrefs.GetInt("Skin1Bought", 0) == 1;
         isSkin2Bought = PlayerPrefs.GetInt("Skin2Bought", 0) == 1;
         isSkin3Bought = PlayerPrefs.GetInt("Skin3Bought", 0) == 1;
         isSkin4Bought = PlayerPrefs.GetInt("Skin4Bought", 0) == 1;

         activeSkinIndex = PlayerPrefs.GetInt("ActiveSkin", 0);
    
         ApplyLoadedSkin(activeSkinIndex);

         if (isSkin1Bought) skin1CostText.SetActive(false);
         if (isSkin2Bought) skin2CostText.SetActive(false);
         if (isSkin3Bought) skin3CostText.SetActive(false);
         if (isSkin4Bought) skin4CostText.SetActive(false);

         if (isGrafffity1)
         {
             graffiti.SetActive(true);
             graffity1CostText.SetActive(false);
         }
         if (isGrafffity2)
         {
             graffiti2.SetActive(true);
             graffity2CostText.SetActive(false);
         }
         if (isGrafffity3)
         {
             graffiti3.SetActive(true);
             graffity3CostText.SetActive(false);
         }

         isBG1Bought = PlayerPrefs.GetInt("BG1Bought", 0) == 1;
         isBG2Bought = PlayerPrefs.GetInt("BG2Bought", 0) == 1;
         isBG3Bought = PlayerPrefs.GetInt("BG3Bought", 0) == 1;

         activeBGIndex = PlayerPrefs.GetInt("ActiveBG", 0);
    
         if (isBG1Bought) bgSkin1CostText.SetActive(false);
         if (isBG2Bought) bgSkin2CostText.SetActive(false);
         if (isBG3Bought) bgSkin3CostText.SetActive(false);

         if (activeBGIndex == 1) bgImage.sprite = bgSkin1;
         else if (activeBGIndex == 2) bgImage.sprite = bgSkin2;
         else if (activeBGIndex == 3) bgImage.sprite = bgSkin3;
         else if (activeBGIndex == 5) bgImage.sprite = bgSkin0;

   
    
     }

     void ApplyLoadedSkin(int index)
     {
         if (index == 5) { buttonImage.sprite = skin1; button.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 26); }
         if (index == 1) { buttonImage.sprite = skin; button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25); }
         if (index == 2) { buttonImage.sprite = skin2; button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25); }
         if (index == 3) { buttonImage.sprite = skin3; button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25); }
         if (index == 4) { buttonImage.sprite = skin4; button.GetComponent<RectTransform>().sizeDelta = new Vector2(93, 25); }
     }

     /*void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }*/
     public void ButtonClick() 
     {
         money = money + moneyForClcik;
         totalMoney++;
         levelPoints++;
         PlayerPrefs.SetInt("levelPoints", levelPoints);
         PlayerPrefs.SetInt("money", money);
         PlayerPrefs.SetInt("totalMoney", totalMoney);
         Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
         sound.Play();
         //soundus.Play();
     }
     
     public void ShopClick()
     {
         shopButton.SetActive(false);
         shopContent.SetActive(true);
     }

     public void ShopCloseClick()
     {
         shopButton.SetActive(true);
         shopContent.SetActive(false);
     }

     public void SkinsShopContent()
     {
         if (canSkins == true && canWalls == true && canGraffities == true)
         {
             skinsShopContent.SetActive(true);
             canSkins = false;
         }
         else if (canSkins == true && canGraffities == false)
         {
             graffitiesShopContent.SetActive(false);
             canGraffities = true;
             skinsShopContent.SetActive(true);
             canSkins = false;
         }
         else if (canSkins == true && canWalls == false)
         {
             wallsShopContent.SetActive(false);
             canWalls = true;
             skinsShopContent.SetActive(true);
             canSkins = false;
         }
     }
     public void GraffitiesShopContent()
     {
         if (canSkins == true && canWalls == true && canGraffities == true)
         {
             graffitiesShopContent.SetActive(true);
             canGraffities = false;
         }
         else if (canGraffities == true && canSkins == false)
         {
             skinsShopContent.SetActive(false);
             canSkins = true;
             graffitiesShopContent.SetActive(true);
             canGraffities = false;
         }
         else if (canGraffities == true && canWalls == false)
         {
             wallsShopContent.SetActive(false);
             canWalls = true;
             graffitiesShopContent.SetActive(true);
             canGraffities = false;
         }
     }
     public void WallsShopContent()
     {
         if (canSkins == true && canWalls == true && canGraffities == true)
         {
             wallsShopContent.SetActive(true);
             canWalls = false;
         }
         else if (canWalls == true && canSkins == false)
         {
             skinsShopContent.SetActive(false);
             canSkins = true;
             wallsShopContent.SetActive(true);
             canWalls = false;
         }
         else if (canWalls == true && canGraffities == false)
         {
             graffitiesShopContent.SetActive(false);
             canGraffities = true;
             wallsShopContent.SetActive(true);
             canWalls = false;
         }
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
     void Update()
     {
         
         moneyText.text = FormatNumber(PlayerPrefs.GetInt("money")) + " $";
         PlayerPrefs.SetInt("moneyForClcik", moneyForClcik);  
         if(money > 999)
         {
             moneyText.text = FormatNumber(money);
         }
         if(levelPoints >= nuzhnodenegchtoburovenapnut)
         {
             currentLevel++;
             levelPoints = 0;
             nuzhnodenegchtoburovenapnut = nuzhnodenegchtoburovenapnut * 1.5f;
             slider.maxValue = nuzhnodenegchtoburovenapnut;
             soundSliderLevel.Play();
             PlayerPrefs.SetInt("currentLevel", currentLevel);
         }
         slider.value = (levelPoints % nuzhnodenegchtoburovenapnut);

         levelText.text = currentLevel.ToString() + " Уровень";
     } 

     public void BuyGrafiti()
     {
         if (isGrafffity1) 
         {
             graffiti.SetActive(!graffiti.activeSelf);
             return;
         }
         if (money >= 90 && chlen == true)
         {
             money -= 90;
             isGrafffity1 = true;
             graffiti.SetActive(true);
             chlen = false;
             graffity1CostText.SetActive(false);
             soundGrafiti.Play();
         
             PlayerPrefs.SetInt("isGrafffity1", 1);
             PlayerPrefs.Save();
         }
         else if (money < 90)
         {
             bomzh.Play();
         }
     }

     public void BuyGrafiti2()
     {
         if (isGrafffity2) 
         {
             graffiti2.SetActive(!graffiti2.activeSelf);
             return;
         }
         if (money >= 120 && chlen2 == true)
         {
             money -= 120;
             isGrafffity2 = true;
             graffiti2.SetActive(true);
             chlen2 = false;
             graffity2CostText.SetActive(false);
             soundGrafiti.Play();
         
             PlayerPrefs.SetInt("isGrafffity2", 1);
             PlayerPrefs.Save();
         }
         else if (money < 120)
         {
             bomzh.Play();
         }
     }

     public void BuyGrafiti3()
     {
         if (isGrafffity3) 
         {
             graffiti3.SetActive(!graffiti3.activeSelf);
             return;
         }
         if (money >= 170 && chlen3 == true)
         {
             money -= 170;
             isGrafffity3 = true;
             graffiti3.SetActive(true);
             chlen3 = false;
             graffity3CostText.SetActive(false);
             soundGrafiti.Play();
         
             PlayerPrefs.SetInt("isGrafffity3", 1);
             PlayerPrefs.Save();
         }
         else if (money < 170)
         {
             bomzh.Play();
         }
     }
     public void BuySkin1Button()
     {
         PlayerPrefs.SetInt("ActiveSkin", 5); 
         button.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 26);
         buttonImage.sprite = skin1;
         return;
     }

     public void BuySkin()
     {
         if (isSkin1Bought)
         {
             buttonImage.sprite = skin;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             PlayerPrefs.SetInt("ActiveSkin", 1); 
             return;
         }
         if (money >= 99 && chlenS == true)
         {
             money -= 99;
             isSkin1Bought = true;
             buttonImage.sprite = skin;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             skin1CostText.SetActive(false);
             soundBoost.Play();
 
             PlayerPrefs.SetInt("Skin1Bought", 1);
             PlayerPrefs.SetInt("ActiveSkin", 1);
             PlayerPrefs.Save();
         }
         else if (money < 99)
         {
             bomzh.Play();
         }
     }

     public void BuySkin2()
     {
         if (isSkin2Bought)
         {
             buttonImage.sprite = skin2;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             PlayerPrefs.SetInt("ActiveSkin", 2);
             return;
         }

         if (money >= 150 && chlen4 == true)
         {
             money -= 150;
             isSkin2Bought = true;
             buttonImage.sprite = skin2;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             skin2CostText.SetActive(false);
             soundBoost.Play();

             PlayerPrefs.SetInt("Skin2Bought", 1);
             PlayerPrefs.SetInt("ActiveSkin", 2);
             PlayerPrefs.Save();
         }    
         else if (money < 150)
         {
             bomzh.Play();
         }
     }

     public void BuySkin3()
     {
         if (isSkin3Bought)
         {
             buttonImage.sprite = skin3;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             PlayerPrefs.SetInt("ActiveSkin", 3);
             return;
         }

         if (money >= 200 && chlen5 == true)
         {
             money -= 200;
             isSkin3Bought = true;
             buttonImage.sprite = skin3;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(157, 25);
             skin3CostText.SetActive(false);
             soundBoost.Play();

             PlayerPrefs.SetInt("Skin3Bought", 1);
             PlayerPrefs.SetInt("ActiveSkin", 3);
             PlayerPrefs.Save();
         }    
         else if (money < 200)
         {
             bomzh.Play();
         }
     }

     public void BuySkin4()
     {
         if (isSkin4Bought)
         {
             buttonImage.sprite = skin4;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(93, 25);
             PlayerPrefs.SetInt("ActiveSkin", 4);
             return;
         }

         if (money >= 250 && chlen6 == true)
         {
             money -= 250;
             isSkin4Bought = true;
             buttonImage.sprite = skin4;
             button.GetComponent<RectTransform>().sizeDelta = new Vector2(93, 25);
             skin4CostText.SetActive(false);
             soundBoost.Play();

             PlayerPrefs.SetInt("Skin4Bought", 1);
             PlayerPrefs.SetInt("ActiveSkin", 4);
             PlayerPrefs.Save();
         }    
         else if (money < 250)
         {
             bomzh.Play();
         }
     }

     public void BuyBGSkin0() 
     {
         PlayerPrefs.SetInt("BG0Bought", 1);
         SetBG(4, bgSkin0);
     }

     public void BuyBGSkin1() 
     {
         if (isBG1Bought) { SetBG(1, bgSkin1); return; }
    
         if (money >= 200 && bool1) 
         {
             money -= 200;
             isBG1Bought = true;
             bgSkin1CostText.SetActive(false);
             PlayerPrefs.SetInt("BG1Bought", 1);
             SetBG(1, bgSkin1);
         }        
         else if (money < 200) bomzh.Play();
     }

     public void BuyBGSkin2() 
     {
         if (isBG2Bought) { SetBG(2, bgSkin2); return; }
    
         if (money >= 300 && bool2) 
         { 
             money -= 300;
             isBG2Bought = true;
             bgSkin2CostText.SetActive(false);
             PlayerPrefs.SetInt("BG2Bought", 1);
             SetBG(2, bgSkin2);
         } 
         else if (money < 300) bomzh.Play();
     }

     public void BuyBGSkin3() 
     {
         if (isBG3Bought) { SetBG(3, bgSkin3); return; }
    
         if (money >= 500 && bool3) 
         { 
             money -= 500;
             isBG3Bought = true;
             bgSkin3CostText.SetActive(false);
             PlayerPrefs.SetInt("BG3Bought", 1);
             SetBG(3, bgSkin3);
         } 
         else if (money < 500) bomzh.Play();
     }

     // Общий метод для смены спрайта и сохранения выбора
     void SetBG(int index, Sprite skin)
     {
         bgImage.sprite = skin;
         PlayerPrefs.SetInt("ActiveBG", index);
         PlayerPrefs.Save();
         soundBoost.Play();
     }

    /*  private void OnEnable()
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
        int money = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetInt("money", money * 2);
      }

      public void ShowRewardAdv_UseCallback()
      {
        YG2.RewardedAdvShow(idAdv, () =>
        {

            SetReward();
        });
      }*/

      public void ShowAdvReward()
{
    string id = "money"; // Передача id требуется для внутренней работы плагина
    YG2.RewardedAdvShow(id, Reward);
}

public void Reward()
{
    // Выдаём вознаграждение
    money = money * 2;
}

}