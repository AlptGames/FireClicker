using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class Menu : MonoBehaviour
{
  [SerializeField] int money;
  public TMP_Text moneyText;
  public int totalMoney;

  public GameObject effect;
  public GameObject button;
  public AudioSource sound;

   private void Start()
   {
   // sound = GetComponent<AudioSource>();
    money = PlayerPrefs.GetInt("money");
      totalMoney = PlayerPrefs.GetInt("totalMoney");
        
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
        moneyText.text = money.ToString();
    }

   
}
