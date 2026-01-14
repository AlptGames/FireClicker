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
    //public Menu money;
    public int priceGraffiti;
    bool chlen = true;
    public GameObject graffiti;
    //bool chlen2 = true;
   // public int priceGraffiti2;

   private void Start()
   {
   // sound = GetComponent<AudioSource>();
    money = PlayerPrefs.GetInt("money");
      totalMoney = PlayerPrefs.GetInt("totalMoney");
         graffiti.SetActive(false);
   }

  public void ButtonClick()
  {
    money++;
    totalMoney++;
    PlayerPrefs.SetInt("money", money);
     PlayerPrefs.SetInt("totalMoney", totalMoney);
     Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
     sound.Play();
  
  }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString() + " $";
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
        if(money >= priceGraffiti && chlen == true)
        {
            money = money - priceGraffiti;
            soundGrafiti.Play();
            graffiti.SetActive(true);
            chlen = false;
            
            
        }
    }

    /*public void BuyGrafiti2()
    {
        if(money >= priceGraffiti2 && chlen2 == true)
        {
            money = money - 120;
            soundGrafiti.Play();
            graffiti.SetActive(true);
            chlen2 = false;
            
            
        }
    }*/
   
}