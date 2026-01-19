using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IPointerDownHandler
{
    public int plusKnazhatiu;
    public Menu osnScript;
    public int tsena;
    public AudioSource buySound;
    public AudioSource neHvataet;
    private bool iziKal = true;
    // Start is called before the first frame update
    void Start()
    {
       // plusKnazhatiu = PlayerPrefs.GetInt("plusKnazhatiu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown (PointerEventData eventData) 
	{
        if(osnScript.money >= tsena && iziKal == true)
        {
            osnScript.money -= tsena;
            osnScript.moneyForClcik = osnScript.moneyForClcik + plusKnazhatiu; //  aaaaa += иоциу  ====== aaaaaaa = aaaaaachl en+zzzzzzzzzzzz zzzz
            buySound.Play();
            iziKal = false;
              //PlayerPrefs.SetInt("plusKnazhatiu", plusKnazhatiu);
        }
        else
        {
            neHvataet.Play();
        }
	}
}
