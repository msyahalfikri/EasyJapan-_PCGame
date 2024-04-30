using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    int QualityIndex;
    public Dropdown QualityDD;
    public void Quality(int QualityIndex){
        QualitySettings.SetQualityLevel(QualityIndex);
        SaveQuality();
    }

    public void Fullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    private void Start() {
        if(!PlayerPrefs.HasKey("Quality")){
           PlayerPrefs.SetInt("Quality", 2);
           LoadQuality();
       }else{
           LoadQuality();
       } 
    }
    private void Awake() {
       DontDestroyOnLoad(transform.gameObject);
    }
    private void LoadQuality(){
     //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality")); 
     QualityDD.value = PlayerPrefs.GetInt("Quality");
   }
   private void SaveQuality(){
    PlayerPrefs.SetInt("Quality", QualityIndex);
   }
}
