using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject token;
    public Canvas canvas;

    List<int> Hiragana_AIUEO = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    List<int> Hiragana_KAKIKUKEKO = new List<int>{10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
    List<int> Hiragana_SASHISUSESO = new List<int>{20, 21, 22, 23, 24, 25, 26, 27, 28, 29};
    List<int> Hiragana_TACHITSUTETO = new List<int>{30, 31, 32, 33, 34, 35, 36, 37, 38, 39};
    List<int> Hiragana_NANINUNENO= new List<int>{40, 41, 42, 43, 44, 45, 46, 47, 48, 49};
    List<int> Hiragana_HAHIFUHEHO = new List<int>{50, 51, 52, 53, 54, 55, 56, 57, 58, 59};
    List<int> Hiragana_MAMIMUMEMO = new List<int>{60, 61, 62, 63, 64, 65, 66, 67, 68, 69};
    List<int> Hiragana_RARIRURERO = new List<int>{70, 71, 72, 73, 74, 75, 76, 77, 78, 79};
    List<int> Hiragana_WAWOYAYUYO = new List<int>{80, 81, 82, 83, 84, 85, 86, 87, 88, 89};
     List<int> Hiragana_WAWONYAYU = new List<int>{80, 81, 82, 83, 85, 86, 87, 88, 90, 95};
     List<int> Katakana_AIUEO = new List<int>{96, 97, 98, 99, 100, 101, 102, 103, 104, 105};
    List<int> Katakana_KAKIKUKEKO = new List<int>{106, 107, 108, 109, 110, 111, 112, 113, 114, 115};
    List<int> Katakana_SASHISUSESO = new List<int>{116, 117, 118, 119, 120, 121, 122, 123, 124, 125};
    List<int> Katakana_TACHITSUTETO = new List<int>{126, 127, 128, 129, 130, 131, 132, 133, 134, 135};
    List<int> Katakana_NANINUNENO= new List<int>{136, 137, 138, 139, 140, 141, 142, 143, 144, 145};
    List<int> Katakana_HAHIFUHEHO = new List<int>{146, 147, 148, 149, 150, 151, 152, 153, 154, 155};
    List<int> Katakana_MAMIMUMEMO = new List<int>{156, 157, 158, 159, 160, 161, 162, 163, 164, 165};
    List<int> Katakana_RARIRURERO = new List<int>{166, 167, 168, 169, 170, 171, 172, 173, 174, 175};
    List<int> Katakana_WAWOYAYUYO = new List<int>{176, 177, 178, 179, 180, 181, 182, 183, 184, 185};
     List<int> Katakana_WAWONYAYU = new List<int>{176, 177, 178, 179, 181, 182, 183, 184, 186, 191};
    
    List<int> faceIndexes = new List<int>();
    List<int> matchedCards = new List<int>{-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
    int matchedCount = 0;
    public static System.Random rnd = new System.Random(); 
    public int shuffleNum = 0;
    int[] visibleFaces = {-6, -6};

    float currentTime = 0f;
    float startingTime;
    [SerializeField] Text countDownText;
    [SerializeField] Text scoreText;
     [SerializeField] Text highScoreText;

    public GameObject gameOverScreen;
    public GameObject winText;
    public GameObject GameOverText;
    public GameObject ScoreSprite;
   public int faceIndList;

    bool gameStart = false;
    public int score = 0;
    public int hiScore;

    void Start() {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();       
         faceIndList = rnd.Next(0, 19);
        switch(faceIndList)
        {
            case 0:
             faceIndexes = Hiragana_AIUEO;
            break;
            case 1:
            faceIndexes = Hiragana_KAKIKUKEKO;
            break;
            case 2:
            faceIndexes = Hiragana_SASHISUSESO;
            break;
            case 3:
            faceIndexes = Hiragana_TACHITSUTETO;
            break;
            case 4:
            faceIndexes = Hiragana_NANINUNENO;
            break;
            case 5:
            faceIndexes = Hiragana_HAHIFUHEHO;
            break;
            case 6:
            faceIndexes = Hiragana_MAMIMUMEMO;
            break;
            case 7:
            faceIndexes = Hiragana_RARIRURERO;
            break;
            case 8:
            faceIndexes = Hiragana_WAWONYAYU;
            break;
            case 9:
            faceIndexes = Hiragana_WAWOYAYUYO;
            break;
            case 10:
            faceIndexes = Katakana_AIUEO;
            break;
            case 11:
            faceIndexes = Katakana_KAKIKUKEKO;
            break;
            case 12:
            faceIndexes = Katakana_SASHISUSESO;
            break;
            case 13:
            faceIndexes = Katakana_TACHITSUTETO;
            break;
            case 14:
            faceIndexes = Katakana_NANINUNENO;
            break;
            case 15:
            faceIndexes = Katakana_HAHIFUHEHO;
            break;
            case 16:
            faceIndexes = Katakana_MAMIMUMEMO;
            break;
            case 17:
            faceIndexes = Katakana_RARIRURERO;
            break;
            case 18:
            faceIndexes = Katakana_WAWONYAYU;
            break;
            case 19:
            faceIndexes = Katakana_WAWOYAYUYO;
            break;
            default:
             break;
             }

        int originalLength = faceIndexes.Count;
        float yPosition = 2f;
        float xPosition = -3.2f;

        for(int i = 0; i < 9; i++){
            shuffleNum = rnd.Next(0, ((faceIndexes.Count) - 2));
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0),Quaternion.identity, canvas.transform);
            SetTokenAlphaToOne(temp); 
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition + 3;
            if (i == originalLength/2 - 2){
                yPosition = -1.3f;
                xPosition = -6.2f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
         SetTokenAlphaToOne(token); 

        //countdown timer
    }
    private void Update() {
        if(gameStart == true){
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
            gameOverScreen.SetActive(true);
            GameOverText.SetActive(true);
            ScoreSprite.SetActive(true);
        }else{
            gameOverScreen.SetActive(false);
            GameOverText.SetActive(false);
            ScoreSprite.SetActive(false);
        }

        if(!matchedCards.Contains(-1)){
            gameOverScreen.SetActive(true);
            winText.SetActive(true);
            ScoreSprite.SetActive(true);
            //currentTime = startingTime;
            gameStart = false;
            ScoreSystem();
        }
        }
    }
    public void diffcultyEasy(){
       startingTime = 45f;
       currentTime = startingTime;
       gameStart = true;
    }
    public void diffcultyMedium(){
       startingTime = 35f;
        currentTime = startingTime;
       gameStart = true;
    }
    public void diffcultyHard(){
       startingTime = 20f;
        currentTime = startingTime;
       gameStart = true;
    }
  public void ScoreSystem(){
      switch(startingTime){
          case 20f:
          if(currentTime >= 5){
              score = 500;
          }else{
              score = 450;
          }
          break;
          case 35f:
          if(currentTime >=20){
              score = 400;
          }else{
              score = 350;
          }
          break;
          case 45f:
          if(currentTime >=35){
              score = 300;
          }else{
              score = 250;
          }
          break;
      }
      if(score > PlayerPrefs.GetInt("HighScore", 0)){
           PlayerPrefs.SetInt("HighScore", score);
           highScoreText.text = score.ToString();
      }
      scoreText.text = score.ToString();
  }
  public void ResetHighScore(){
      PlayerPrefs.DeleteKey("HighScore");
      highScoreText.text = "0";
  }
    public bool TwoCardsUp(){
        bool cardsUp = false;
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0){
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index){
        if(visibleFaces[0] == -6){
            visibleFaces[0] = index;
        }else if(visibleFaces[1] == -6){
            visibleFaces[1] = index;
        }
    }
    public void RemoveVisibleFace(int index){
        if(visibleFaces[0] == index){
            visibleFaces[0] = -6;
        }else if(visibleFaces[1] == index){
            visibleFaces[1] = -6;
        }
    }

    public bool CheckMatch(){
        bool success = false;

        if(visibleFaces[0] - visibleFaces[1] == -5 || visibleFaces[0] - visibleFaces[1] == 5){
            MatchedCounts(visibleFaces[0]);
            MatchedCounts(visibleFaces[1]);
            visibleFaces[0] = -6;
            visibleFaces[1] = -6;
            success = true;
        }else{

        }
        return success;
    }

    public void MatchedCounts(int index){
        matchedCards[matchedCount] = index;
        matchedCount++;
    }
    public bool checkMatchedList(int index){
        bool contained = false;
        if(matchedCards.Contains(index) == true){
            contained = true;
        }else {
            contained = false;
        }
        return contained;
    }

    public void goback(){
          SceneManager.LoadScene("MainMenu");
    }

    public bool checkTime(){
        bool noTime = false;
        if (currentTime == 0){
            noTime = true;
        }else{
            noTime = false;
        }
        return noTime;
    }
    private void Awake() {
        token = GameObject.Find("QuestionMark");
    }
     public void SetTokenAlphaToOne(GameObject obj){
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
