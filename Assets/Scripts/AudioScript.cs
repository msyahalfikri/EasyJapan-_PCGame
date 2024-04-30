using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
   private void Awake() {
       DontDestroyOnLoad(transform.gameObject);
   }
   private void Start() {
      if(!PlayerPrefs.HasKey("Volume")){
           PlayerPrefs.SetFloat("Volume", 0.6f);
           Load();
       }else{
           Load();
       } 
   }
   public void ChangeVolume(){
       AudioListener.volume = volumeSlider.value;
       Save();
   }
   private void Load(){
     volumeSlider.value = PlayerPrefs.GetFloat("Volume");
   }
   private void Save(){
       PlayerPrefs.SetFloat("Volume", volumeSlider.value);
   }
}
