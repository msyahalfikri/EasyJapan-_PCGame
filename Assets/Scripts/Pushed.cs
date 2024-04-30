using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushed : MonoBehaviour
{
    GameObject Details;
    public int index;
   public bool pushed;
    public void pushedButton(){
       Details.GetComponent<Details>().changeImg(index);
       pushed = true;
    }
    private void Awake() {
        {
        Details = GameObject.Find("H_Det");
        }
    }
}
