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
     public GameObject puk;
     public int limit = 3;
     public int cost = 5;
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

     public AudioSource Nehvataet;

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
         //currentLevel = PlayerPrefs.GetInt("currentLevel");
         //n = PlayerPrefs.GetInt("n");

         //moneyForClcik = PlayerPrefs.GetInt("moneyForClicik");

      // levelText = PlayerPrefs.GetString("levelText");
     }

     public void ButtonClick()
     {
         money = money + moneyForClcik;
         totalMoney = totalMoney + moneyForClcik;
         PlayerPrefs.SetInt("money", money);
         PlayerPrefs.SetInt("totalMoney", totalMoney);
         Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
         sound.Play();

           //PlayerPrefs.SetInt("moneyForClicik", moneyForClcik);
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
              //PlayerPrefs.SetInt("currentLevel", currentLevel);
        // PlayerPrefs.SetInt("n", n);
        // PlayerPrefs.SetString("levelText", levelText);
          }
          slider.value = (totalMoney % 100);
         // levelText.text = $"({currentLevel} Уровень";
          levelText.text = currentLevel.ToString() + " Уровень";
          
     }

     public void startBoost()
     {
         StartCoroutine(boost());
     }

     IEnumerator boost()
     {
         float timer = 0f;
         if (money >= cost && limit > 0)
         {
             money -= cost;
             limit--;
             soundBoost.Play();
             while (timer < 50f)
             {
                 money++;
                 puk.SetActive(false);
                 yield return new WaitForSeconds(1f); // пауза 2 секунды
                 timer += 1f;
             }
         }
         puk.SetActive(true);
         cost = cost * 2; 
         Debug.Log("Корутинa завершилась");
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
         else
         {
            Nehvataet.Play();
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
         else
         {
            Nehvataet.Play();
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

         else
         {
            Nehvataet.Play();
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
             Nehvataet.Play();

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
             Nehvataet.Play();
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
             Nehvataet.Play();
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
             Nehvataet.Play();
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
}