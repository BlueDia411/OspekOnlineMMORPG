using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public HealthScript healthbar;
   
    public EnemyHealthScript enemyHealthBar;
    public CharLevelUp charLevel;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;
    public GameObject LosePanel;
    public GameObject WinPanel;

    public Text questionTxt;
    public Text ScoreText;
    public Text XpText;
    public Text UangText;
    public Text countdown;
    public Text bonus;

    int totalQuestion = 0;
    int score;
    public int xp;
    public int uang;
    public int xpValue;
    public int uangValue;
    private int playerMaxHealth = 100;
    private int playerCurrentHealth;
    private int enemyMaxHealth = 100;
    private int enemyCurrentHealth;
    public int damage;

    public int puzzleTime;
    public float timeLeft;
    public float timeLeftReset = 10;
    bool gameover = false;

    public Image playerHit;
    public Image enemyHit;
    public Animator monsterbot1;
    public Animator monsterbot2;
    
    

    private void Start()
    {

        playerCurrentHealth = healthbar.healthh = PlayerPrefs.GetInt("mainHealth");
        // healthbar.SetMaxHealth(playerMaxHealth);
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

            if (gameover == false)
            {
                GameOver();
                StopCoroutine("Timer");
                gameover = true;
            }
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
        charLevel.setExp(xp);
        UangText.text = uang.ToString();
        charLevel.setUang(uang);

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
        // charLevel.exp +=1;
        
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
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
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
        yield return new WaitForSeconds(puzzleTime);
        
        wrong();
        
        //  generateQuestion();
     }

     IEnumerator PlayerHit()
     {
        monsterbot2.SetInteger("status", 1);
        yield return new WaitForSeconds(1);
        playerHit.enabled = true;
        monsterbot1.SetInteger("status", 2);
        monsterbot2.SetInteger("status", 0);
        yield return new WaitForSeconds(2);
        playerHit.enabled = false;
        monsterbot1.SetInteger("status", 0);
     }

     IEnumerator EnemyHit()
     {
        monsterbot1.SetInteger("status", 1);
        yield return new WaitForSeconds(1);
        enemyHit.enabled = true;
        monsterbot2.SetInteger("status", 2);
        monsterbot1.SetInteger("status", 0);
        yield return new WaitForSeconds(1);
        enemyHit.enabled = false;
        monsterbot2.SetInteger("status", 0);
     }

}
