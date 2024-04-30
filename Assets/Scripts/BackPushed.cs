using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPushed : MonoBehaviour
{
    GameObject Details;
    // Start is called before the first frame update
    public void back(){
        GameObject.Find ("SubPanel").transform.localScale = new Vector3(0, 0, 0);
        Details.GetComponent<Details>().face.enabled = false;
    }
    private void Awake() {
        Details = GameObject.Find("H_Det");
    }
}
