using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManagerPaC : MonoBehaviour
{
    public List<QuestionAndAnswerPaC> QnA;
    public GameObject[] options;
    public HealthScript healthbar;
    public EnemyHealthScript enemyHealthBar;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject LosePanel;
   

    public Text questionTxt;
    public Text ScoreText;
    public Text XpText;
    public Text UangText;
    public Text countdown;
    public Text bonus;

    int totalQuestion = 0;
    int score;
    int xp;
    int uang;
    public int xpValue;
    public int uangValue;
    private int playerMaxHealth = 100;
    private int playerCurrentHealth;
    private int enemyMaxHealth = 100;
    private int enemyCurrentHealth;
    public int damage;

    public int delay;
    public float timeLeft;
    public float timeLeftReset;

    public Image playerHit;
    public Image enemyHit;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthbar.SetMaxHealth(playerMaxHealth);
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);

        bonus.enabled = false;
        playerHit.enabled = false;
        enemyHit.enabled = false;
        totalQuestion = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        countdown.text = (timeLeft).ToString("0");
        
        
        if(timeLeft <= 0)
        {
            timeLeft = timeLeftReset;
        }

         if(playerCurrentHealth <= 0)
        {
            Death();
            StopCoroutine("Timer");
        }
        if(enemyCurrentHealth <= 0)
        {
            bonus.enabled = true;
            GameOver();
            StopCoroutine("Timer");
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = "Kamu menjawab" + score + " dari " + totalQuestion + "pertanyaan";
        XpText.text = xp.ToString();
        UangText.text = uang.ToString();
    }

    public void Death()
    {
        QuizPanel.SetActive(false);
        LosePanel.SetActive(true);
        // ScoreText.text = score + "/" + totalQuestion;
        // XpText.text = xp.ToString();
        // UangText.text = uang.ToString();
    }

    public void correct()
    {
        EnemyTakeDamage(damage);
        StartCoroutine("EnemyHit");
        //when you are right
        timeLeft = timeLeftReset;
        score += 1;
        xp += xpValue;
        uang += uangValue;
        QnA.RemoveAt(currentQuestion);
        StopCoroutine("Timer");
        Debug.Log("stop");
        if(enemyCurrentHealth <= 0)
        {
            xp += 2000;
            uang += 5000;
        }
        generateQuestion();
        
    }

    public void wrong()
    {
        PlayerTakeDamage(damage);
        StartCoroutine("PlayerHit");

        timeLeft = timeLeftReset;
        QnA.RemoveAt(currentQuestion);
        StopCoroutine("Timer");
        Debug.Log("stop");
        generateQuestion();
    }

    void PlayerTakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        healthbar.SetHealth(playerCurrentHealth);
    }

    void EnemyTakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScriptPaC>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answer[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScriptPaC>().isCorrect = true;
                
            }
        }
    }

    void generateQuestion()
    {
      if(QnA.Count > 0)
        {
            Coroutine c1 = StartCoroutine("Timer");
            currentQuestion = Random.Range(0, QnA.Count);
            questionTxt.text = QnA[currentQuestion].Question;
            setAnswers();
            
        }

        else
        {
            Debug.Log("Pertanyaan Selesai");
            if(playerCurrentHealth <=0 )
            {
                Death();
            }else
            {
                GameOver();
            }
        }
        
    }

     IEnumerator Timer()
     {
        yield return new WaitForSeconds(delay);
        
        wrong();
        
        //  generateQuestion();
     }

     IEnumerator PlayerHit()
     {
        playerHit.enabled = true;
        yield return new WaitForSeconds(1);
        playerHit.enabled = false;
     }

     IEnumerator EnemyHit()
     {
        enemyHit.enabled = true;
        yield return new WaitForSeconds(1);
        enemyHit.enabled = false;
     }
}
