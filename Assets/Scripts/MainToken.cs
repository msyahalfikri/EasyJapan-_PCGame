using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    GameObject gameController;
    SpriteRenderer spriteRenderer;
    public Sprite[] face;
    public Sprite back;
    public int faceIndex;
    public bool matched = false; 
    public bool contained = false;

    public void OnMouseDown() {
         contained = gameController.GetComponent<GameController>().checkMatchedList(faceIndex);
        if(matched == false && contained == false && gameController.GetComponent<GameController>().checkTime() == false){
        
        if(spriteRenderer.sprite == back){
            if(gameController.GetComponent<GameController>().TwoCardsUp() == false){
                spriteRenderer.sprite = face[faceIndex];
                gameController.GetComponent<GameController>().AddVisibleFace(faceIndex);
                matched = gameController.GetComponent<GameController>().CheckMatch();
                
            }
            
        }else{
            spriteRenderer.sprite = back;
            gameController.GetComponent<GameController>().RemoveVisibleFace(faceIndex);
        }
        }
    }

    private void Update() {
    
    }
    private void Awake(){
       
        gameController = GameObject.Find("GameController");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
