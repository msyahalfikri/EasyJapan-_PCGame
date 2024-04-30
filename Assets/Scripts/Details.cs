using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Details : MonoBehaviour
{
    //SpriteRenderer sprite;
    public Image face;
    public Sprite[] image;
   
    private void Update() {
       
    }
    private void Start() {
      GameObject.Find ("SubPanel").transform.localScale = new Vector3(0, 0, 0);
      face.enabled = false;
    }
    public void changeImg(int index){
        GameObject.Find ("SubPanel").transform.localScale = new Vector3(1, 1, 1);
        face.enabled = true;
        face.sprite = image[index];
    }

}
