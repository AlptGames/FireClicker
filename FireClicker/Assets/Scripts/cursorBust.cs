using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NewBehaviourScript : MonoBehaviour, IPointerDownHandler
{
    public int plusKnazhatiu;
    public Menu osnScript;
    public int tsena;
    public AudioSource buySound;
    public AudioSource neHvataet;
    public TMP_Text costCursor;
    // Start is called before the first frame update
    void Start()
    {
       // plusKnazhatiu = PlayerPrefs.GetInt("plusKnazhatiu");
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void OnPointerDown (PointerEventData eventData) 
	{
        if(osnScript.money >= tsena)
        {
            osnScript.money -= tsena;
            tsena *= 2;
            costCursor.text = FormatNumber(tsena) + " $";
            osnScript.moneyForClcik = osnScript.moneyForClcik + plusKnazhatiu;
            buySound.Play();
        }
        else
        {
            neHvataet.Play();
        }
	}
}
