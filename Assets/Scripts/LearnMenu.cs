using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LearnMenu : MonoBehaviour
{
   public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }
    
}
