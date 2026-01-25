using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Menu : MonoBehaviour
{
     public int money;
     public TMP_Text moneyText;
     public int totalMoney;
     public GameObject effect;
     public GameObject button;
     public AudioSource sound;
     public AudioSource soundGrafiti;
     bool chlen = true;
     public GameObject graffiti;
     public GameObject graffiti2;
     public GameObject graffiti3;
     bool chlen2 = true;
     bool chlen3 = true;
     bool chlenS = true;
     public Sprite skin;
     public Image buttonImage;
     public AudioSource SkinSound;
     public AudioSource soundBoost;
     public Sprite skin2;
     bool chlen4 = true;


     public Sprite skin3;
     bool chlen5 = true;

     public Sprite skin4;
     bool chlen6 = true;


     bool bool1 = true;
     bool chlen7 = true;
     bool chlen8 = true;
     public Image bgImage;
     public Sprite bgSkin1;
     public Sprite bgSkin2;
     public Sprite bgSkin3;

     public int cpsFPM1 = 0;
     public int costFPM1 = 15;
     public TMP_Text costFPM1Text;

     public int cpsFPM2 = 0;
     public int costFPM2 = 100;
     public TMP_Text costFPM2Text;

     public int cpsFPM3 = 0;
     public int costFPM3 = 500;
     public TMP_Text costFPM3Text;

     public int cpsFPM4 = 0;
     public int costFPM4 = 2500;
     public TMP_Text costFPM4Text;

     public int cpsFPM5 = 0;
     public int costFPM5 = 5000;
     public TMP_Text costFPM5Text;


     public int cpsTPM1 = 0;
     public int costTPM1 = 5;
     public TMP_Text costTPM1Text;

     public int cpsTPM2 = 0;
     public int costTPM2 = 150;
     public TMP_Text costTPM2Text;

     public int cpsTPM3 = 0;
     public int costTPM3 = 500;
     public TMP_Text costTPM3Text;

     public int cpsTPM4 = 0;
     public int costTPM4 = 2000;
     public TMP_Text costTPM4Text;

     public int cpsTPM5 = 0;
     public int costTPM5 = 5000;
     public TMP_Text costTPM5Text;

     public int moneyForClcik= 1;
     public Slider slider;
     public int currentLevel;
     private int n = 1;
     public TextMeshProUGUI levelText;
     public float nuzhnodenegchtoburovenapnut = 100;
     public float levelPoints;
     public AudioSource soundSliderLevel;

     public GameObject shopContent;
     public bool canShop = true;
     public bool canSkins = true;
     public bool canGraffities = true;
     public bool canWalls = true;
     public GameObject skinsShopContent;
     public GameObject graffitiesShopContent;
     public GameObject wallsShopContent;

     private void Start()
     {
         money = PlayerPrefs.GetInt("money");
         totalMoney = PlayerPrefs.GetInt("totalMoney");
         graffiti.SetActive(false);
     }

     public void ButtonClick()
     {
         money = money + moneyForClcik;
         totalMoney++;
         levelPoints++;
         PlayerPrefs.SetInt("money", money);
         PlayerPrefs.SetInt("totalMoney", totalMoney);
         Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
         sound.Play();
     }
     
     public void ShopClick()
     {
         if (canShop == true)
         {
             shopContent.SetActive(true);
             canShop = false;
         }
         else
         {
             shopContent.SetActive(false);
             canShop = true;
         }
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
     public static string FormatNumber(float num) 
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
        // moneyText.text = money.ToString() + " $";
          moneyText.text = FormatNumber(money) + " $";

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
          }
          slider.value = (levelPoints % nuzhnodenegchtoburovenapnut);

          levelText.text = currentLevel.ToString() + " Уровень";
     } 

     public void startBoostTPM1()
     {
         StartCoroutine(boosterTPM1());
     }

     public void startBoostTPM2()
     {
         StartCoroutine(boosterTPM2());
     }

     public void startBoostTPM3()
     {
         StartCoroutine(boosterTPM3());
     }

     public void startBoostTPM4()
     {
         StartCoroutine(boosterTPM4());
     }

     public void startBoostTPM5()
     {
         StartCoroutine(boosterTPM5());
     }


     public void startBoostFPM1()
     {
         StartCoroutine(boosterFPM1());
     }

     public void startBoostFPM2()
     {
         StartCoroutine(boosterFPM2());
     }

     public void startBoostFPM3()
     {
         StartCoroutine(boosterFPM3());
     }

     public void startBoostFPM4()
     {
         StartCoroutine(boosterFPM4());
     }

     public void startBoostFPM5()
     {
         StartCoroutine(boosterFPM5());
     }

     IEnumerator boosterTPM1()
     {
         float timer = 0f;
         if (money >= costTPM1)
         {
             money -= costTPM1;
             costTPM1 = costTPM1 * 2; 
             costTPM1Text.text = FormatNumber(costTPM1) + " $";
             cpsTPM1 += 1;
             soundBoost.Play();
             while (timer <= 60)
             {
                 money += cpsTPM1;
                 yield return new WaitForSeconds(0.5f); // пауза 2 секунды
                 timer += 1f;
             }
         }
     }

     IEnumerator boosterTPM2()
     {
         float timer = 0f;
         if (money >= costTPM2)
         {
             money -= costTPM2;
             costTPM2 = costTPM2 * 2; 
             costTPM2Text.text = FormatNumber(costTPM2) + " $";
             cpsTPM2 += 1;
             soundBoost.Play();
             while (timer <= 60)
             {
                 money += cpsTPM2;
                 yield return new WaitForSeconds(0.5f); // пауза 2 секунды
                 timer += 1f;
             }
         }
     }

     IEnumerator boosterTPM3()
     {
         float timer = 0f;
         if (money >= costTPM3)
         {
             money -= costTPM3;
             costTPM3 = costTPM3 * 2; 
             costTPM3Text.text = FormatNumber(costTPM3) + " $";
             cpsTPM3 += 1;
             soundBoost.Play();
             while (timer <= 60)
             {
                 money += cpsTPM3;
                 yield return new WaitForSeconds(0.5f); // пауза 2 секунды
                 timer += 1f;
             }
         }
     }

     IEnumerator boosterTPM4()
     {
         float timer = 0f;
         if (money >= costTPM4)
         {
             money -= costTPM4;
             costTPM4 = costTPM4 * 2; 
             costTPM4Text.text = FormatNumber(costTPM4) + " $";
             cpsTPM4 += 1;
             soundBoost.Play();
             while (timer <= 60)
             {
                 money += cpsTPM4;
                 yield return new WaitForSeconds(0.5f); // пауза 2 секунды
                 timer += 1f;
             }
         }
     }

     IEnumerator boosterTPM5()
     {
         float timer = 0f;
         if (money >= costTPM5)
         {
             money -= costTPM5;
             costTPM5 = costTPM5 * 2; 
             costTPM5Text.text = FormatNumber(costTPM5) + " $";
             cpsTPM5 += 1;
             soundBoost.Play();
             while (timer <= 60)
             {
                 money += cpsTPM5;
                 yield return new WaitForSeconds(0.5f); // пауза 2 секунды
                 timer += 1f;
             }
         }
     }

     IEnumerator boosterFPM1()
     {
         if (money >= costFPM1)
         {
             money -= costFPM1;
             costFPM1 = costFPM1 * 2;
             costFPM1Text.text = FormatNumber(costFPM1) + " $";
             soundBoost.Play();
             cpsFPM1 += 1;
             while (true)
             {
                 money += cpsFPM1;
                 yield return new WaitForSeconds(0.9f);
             }
         }
     }

     IEnumerator boosterFPM2()
     {
         if (money >= costFPM2)
         {
             money -= costFPM2;
             costFPM2 = costFPM2 * 2;
             costFPM2Text.text = FormatNumber(costFPM2) + " $";
             soundBoost.Play();
             cpsFPM2 += 15;
             while (true)
             {
                 money += cpsFPM2;
                 yield return new WaitForSeconds(0.9f);
             }
         }
     }

     IEnumerator boosterFPM3()
     {
         if (money >= costFPM3)
         {
             money -= costFPM3;
             costFPM3 = costFPM3 * 2;
             costFPM3Text.text = FormatNumber(costFPM3) + " $";
             soundBoost.Play();
             cpsFPM3 += 50;
             while (true)
             {
                 money += cpsFPM3;
                 yield return new WaitForSeconds(0.9f);
             }
         }
     }

     IEnumerator boosterFPM4()
     {
         if (money >= costFPM4)
         {
             money -= costFPM4;
             costFPM4 = costFPM4 * 2;
             costFPM4Text.text = FormatNumber(costFPM4) + " $";
             soundBoost.Play();
             cpsFPM4 += 200;
             while (true)
             {
                 money += cpsFPM4;
                 yield return new WaitForSeconds(0.9f);
             }
         }
     }

     IEnumerator boosterFPM5()
     {
         if (money >= costFPM5)
         {
             money -= costFPM5;
             costFPM5 = costFPM5 * 2;
             costFPM5Text.text = FormatNumber(costFPM5) + " $";
             soundBoost.Play();
             cpsFPM5 += 1000;
             while (true)
             {
                 money += cpsFPM5;
                 yield return new WaitForSeconds(0.9f);
             }
         }
     }

     public void BuyGrafiti()
     {
         if(money >= 90 && chlen == true)
         {
             money = money - 90;
             graffiti.SetActive(true);
             chlen = false;
             soundGrafiti.Play();
         }
     }

     public void BuyGrafiti2()
     {
         if(money >= 120 && chlen2 == true)
         {
             money = money - 120;
             graffiti2.SetActive(true);
             chlen2 = false;
             soundGrafiti.Play();
         }
     }

     public void BuyGrafiti3()
     {
         if(money >= 170 && chlen3 == true)
         {
             money = money - 170;
             graffiti3.SetActive(true);
             chlen3 = false;
             soundGrafiti.Play();
         }
     }
     public void BuySkin()
     {
         if(money >= 99 && chlenS == true)
         {
             money = money - 99;
             button.transform.localScale = new Vector3(3, 16, 2);
             buttonImage.sprite = skin;
             chlenS = false;
             SkinSound.Play();
         }
         else if(chlenS == false)
         {
             button.transform.localScale = new Vector3(3, 16, 2);
             buttonImage.sprite = skin;
         }
     }

     public void BuySkin2()
     {
         if(money >= 150 && chlen4 == true)
         {
             money = money - 150;
             button.transform.localScale = new Vector3(3, 16, 2);
             buttonImage.sprite = skin2;
             chlen4 = false;
             SkinSound.Play();
         }
         else if(chlen4 == false)
         {
             button.transform.localScale = new Vector3(3, 16, 2);
             buttonImage.sprite = skin2;
         }
     }

     public void BuySkin3()
     {
         if(money >= 200 && chlen5 == true)
         {
             money = money - 200;
             button.transform.localScale = new Vector3(4, 21, 3);
             buttonImage.sprite = skin3;
             chlen5 = false;
             SkinSound.Play();
         }
         else if(chlen5 == false)
         {
             button.transform.localScale = new Vector3(4, 21, 3);
             buttonImage.sprite = skin3;
         }
     }

     public void BuySkin4()
     {
         if(money >= 250 && chlen6 == true)
         {
             money = money - 250;
             button.transform.localScale = new Vector3(2, 16, 2);
             buttonImage.sprite = skin4;
             chlen6 = false;
             SkinSound.Play();
         }
         else if(chlen6 == false)
         {
             button.transform.localScale = new Vector3(2, 16, 2);
             buttonImage.sprite = skin4;
         }
     }

     public void BuyBGSkin1()
     {
         if(money >= 200 && bool1 == true)
         { 
             money = money - 200;
             bgImage.sprite = bgSkin1;
             bool1 = false;
         }
         else if(bool1 == false)
         {
             bgImage.sprite = bgSkin1;
         }
     }

      public void BuyBGSkin2()
     {
         if(money >= 300 && chlen7 == true)
         { 
             money = money - 300;
             bgImage.sprite = bgSkin2;
             chlen7 = false;
         }
         else if(chlen7 == false)
         {
             bgImage.sprite = bgSkin2;
         }
     }

      public void BuyBGSkin3()
     {
         if(money >= 467 && chlen8 == true)
         { 
             money = money - 467;
             bgImage.sprite = bgSkin3;
             chlen8 = false;
         }
         else if(chlen8 == false)
         {
             bgImage.sprite = bgSkin3;
         }
     }

     
}