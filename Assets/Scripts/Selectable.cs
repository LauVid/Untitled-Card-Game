using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool FaceUp = true;
    public  int Strength;

    public bool IsPartOfPakison=false;

    public SpriteRenderer sprite;

    private GameMngr gameMngr;
    private UserInput userInput;

    public void CheckCardParent(GameObject card)
    {
        // Check if the card has a parent
        if (card.transform.parent != null)
        {
            // Check if the parent's name contains "Player"
            if (card.transform.parent.name.Contains("Player")||card.transform.parent.name.Contains("PlayedCards"))
            {
            card.GetComponent<Selectable>().FaceUp = true;
            }
        }
        else
        {
            Debug.Log("The card has no parent.");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameMngr=GameObject.Find("GameManager").GetComponent<GameMngr>();
        userInput=GameObject.Find("GameManager").GetComponent<UserInput>();
        sprite=gameObject.GetComponent<SpriteRenderer>();
        if(transform.name[0]=='9')
        {
            Strength=1;
        }
        if(transform.name[0]=='1')
        {
            Strength=2;
        }
        if(transform.name[0]=='J')
        {
            Strength=3;
        }
        if(transform.name[0]=='Q')
        {
            Strength=4;
        }
        if(transform.name[0]=='K')
        {
            Strength=5;
        }
        if(transform.name[0]=='A')
        {
            Strength=6;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseEnter()
    {
        if(gameObject.transform.parent.name=="Player"&&gameMngr.playersTurn&&sprite.color!=Color.grey&&!userInput.CardHasBeenSelected)
        {
            Color32 color=new(255,255,180,255); 
            sprite.color=color;           
        }
    }

    public void OnMouseExit()
    {
        if(gameObject.transform.parent.name=="Player"&&gameMngr.playersTurn&&sprite.color!=Color.grey&&!userInput.CardHasBeenSelected)
        {
            sprite.color=Color.white;            
        }
    }
    public void ChooseClickableColors(int str)
    {
        if(Strength>=str||IsPartOfPakison==true)
        {
            sprite.color=Color.white;
        }
        else
        {
            sprite.color=Color.grey;
        }
    }
}
