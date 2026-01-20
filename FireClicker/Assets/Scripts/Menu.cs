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

     public int cpsTPM1 = 0;
     public int costTPM1 = 5;
     public TMP_Text costTPM1Text;

     public int moneyForClcik= 1;
     public Slider slider;
     public int currentLevel;
     private int n = 1;
     public TextMeshProUGUI levelText;

     public AudioSource soundSliderLevel;

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
         PlayerPrefs.SetInt("money", money);
         PlayerPrefs.SetInt("totalMoney", totalMoney);
         Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
         sound.Play();
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
          if(totalMoney >= 100 * n)
          {
            currentLevel++;
            n++;
            soundSliderLevel.Play();
          }
          slider.value = (totalMoney % 100);
         // levelText.text = $"({currentLevel} Уровень";
          levelText.text = currentLevel.ToString() + " Уровень";
     } 

     public void startBoost()
     {
         StartCoroutine(boosterTPM1());
     }

     public void startBoost2()
     {
         StartCoroutine(boosterFPM1());
     }

     IEnumerator boosterTPM1()
     {
         float timer = 0f;
         if (money >= costTPM1)
         {
             money -= costTPM1;
             costTPM1 = costTPM1 * 2; 
             costTPM1Text.text = costTPM1.ToString() + " $";
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

     IEnumerator boosterFPM1()
     {
         if (money >= costFPM1)
         {
             money -= costFPM1;
             costFPM1 = costFPM1 * 2;
             costFPM1Text.text = costFPM1.ToString() + " $";
             soundBoost.Play();
             cpsFPM1 += 1;
             while (true)
             {
                 money += cpsFPM1;
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