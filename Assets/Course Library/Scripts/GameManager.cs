using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

   public List<GameObject> targets;
   private float spawnRate = 1.0f;
   private int score =0;
   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI gameOverText;
   public bool isGameActive;
   public Button restartButton;
   public GameObject titleScreen;

   void Start()
   {

   }

    public void startGame(int difficulty)
    {
       isGameActive = true;
       score = 0;
       StartCoroutine(SpawnTarget());
       UpdatedScore(0);
       spawnRate /= difficulty;
       titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
      gameOverText.gameObject.SetActive(isGameActive);
      isGameActive = false;
      restartButton.gameObject.SetActive(true);
    }

   public void UpdatedScore(int scoreToAdd)
   {
      score += scoreToAdd;
      scoreText.text = "Score: " + score;
   }

      IEnumerator SpawnTarget()
       {
         while (isGameActive)
        {
         yield return new WaitForSeconds(spawnRate);
         int index = Random.Range(0, targets.Count);
         Instantiate(targets[index]);
        }
        }  

        public void UpdateScore(int scoreToAdd)
        {
         score += scoreToAdd;
         scoreText.text = "Score" + score;
        }

     public void RestartGame()
     {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
        
}