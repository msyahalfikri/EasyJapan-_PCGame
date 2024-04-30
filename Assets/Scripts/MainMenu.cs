using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameController gameController;
     public void LearnButton(){
        SceneManager.LoadScene("LearnMenu");
    }

    public void BackButton(){
        SceneManager.LoadScene("Title Menu");
    }

    public void ChallengeStart(){
       SceneManager.LoadScene("GameScene");
    }
    private void Start() {
    }
}
