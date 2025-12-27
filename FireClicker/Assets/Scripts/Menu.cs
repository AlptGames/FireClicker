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
    public GameObject limit;

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

    public void startBoost()
    {
        StartCoroutine(boost());
    }

    IEnumerator boost()
    {
        float timer = 0f;
        if (money >= 20)
        {
            money -= 20;
            while (timer < 30f)
            {
                money++;
                limit.SetActive(false);
                yield return new WaitForSeconds(1f); // пауза 2 секунды
                timer += 1f;
            }
        }
        limit.SetActive(true);
        Debug.Log("Корутинa завершилась");
    }
   
}
