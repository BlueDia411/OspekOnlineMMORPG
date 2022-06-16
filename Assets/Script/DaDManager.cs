using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaDManager : MonoBehaviour
{
    public GameObject answer1,answer2,answer3,answer4,answer5,answerPlace1,answerPlace2,answerPlace3,answerPlace4,answerPlace5;
    Vector2 answer1Pos,answer2Pos,answer3Pos,answer4Pos,answer5Pos;
    public GameObject FinishPanel;
    public GameObject answerPanel;
    public GameObject answerPlacePanel;
    public GameObject losePanel;
    public GameObject playerChar;
    public GameObject enemyChar;
    public HealthScript healthbar;
    public EnemyHealthScript enemyHealthBar;
    

    int xp;
    int uang;
    int correct;
    public int xpValue;
    public int uangValue;
    public int totalCorrect;  
    public Text XpText;
    public Text UangText;
    private int playerMaxHealth = 100;
    private int playerCurrentHealth;
    private int enemyMaxHealth = 100;
    private int enemyCurrentHealth;
    public int damage;
    public Image playerHit;
    public Image enemyHit;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthbar.SetMaxHealth(playerMaxHealth);
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);

        // bonus.enabled = false;
        playerHit.enabled = false;
        enemyHit.enabled = false;
        answer1Pos = answer1.transform.position;
        answer2Pos = answer2.transform.position;
        answer3Pos = answer3.transform.position;
        answer4Pos = answer4.transform.position;
        answer5Pos = answer5.transform.position;
    }

    void Update()
    {
        if(totalCorrect == correct)
        {
            FinishPanel.SetActive(true);
            answerPanel.SetActive(false);
            answerPlacePanel.SetActive(false);
            playerChar.SetActive(false);
            enemyChar.SetActive(false);
            
        }
        XpText.text = xp.ToString();
        UangText.text = uang.ToString();

        if(enemyCurrentHealth <= 0)
        {
            FinishPanel.SetActive(true);
            answerPanel.SetActive(false);
            answerPlacePanel.SetActive(false);
            playerChar.SetActive(false);
            enemyChar.SetActive(false);
        } 
        if(playerCurrentHealth <= 0)
        {
            losePanel.SetActive(true);
            answerPanel.SetActive(false);
            answerPlacePanel.SetActive(false);
            playerChar.SetActive(false);
            enemyChar.SetActive(false);
        }
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

    public void Finish()
    {
        XpText.text = xp.ToString();
        UangText.text = uang.ToString();
    }

    public void DragAnswer1()
    {
        answer1.transform.position = Input.mousePosition;
    }
    public void DragAnswer2()
    {
        answer2.transform.position = Input.mousePosition;
    }
    public void DragAnswer3()
    {
        answer3.transform.position = Input.mousePosition;
    }
    public void DragAnswer4()
    {
        answer4.transform.position = Input.mousePosition;
    }
    public void DragAnswer5()
    {
        answer5.transform.position = Input.mousePosition;
    }

    public void DropAnswer1()
    {
        float Distance = Vector3.Distance(answer1.transform.position, answerPlace1.transform.position);
        if(Distance < 50)
        {
            answer1.transform.position = answerPlace1.transform.position;
            xp += xpValue;
            uang += uangValue;
            correct += 1;
            EnemyTakeDamage(damage);
            StartCoroutine("EnemyHit");
        }else
        {
            answer1.transform.position = answer1Pos;
            PlayerTakeDamage(damage);
            StartCoroutine("PlayerHit");
        }
    }
    public void DropAnswer2()
    {
        float Distance = Vector3.Distance(answer2.transform.position, answerPlace2.transform.position);
        if(Distance < 50)
        {
            answer2.transform.position = answerPlace2.transform.position;
            xp += xpValue;
            uang += uangValue;
            correct += 1;
            EnemyTakeDamage(damage);
            StartCoroutine("EnemyHit");
        }else
        {
            answer2.transform.position = answer2Pos;
            PlayerTakeDamage(damage);
            StartCoroutine("PlayerHit");
        }
    }
    public void DropAnswer3()
    {
        float Distance = Vector3.Distance(answer3.transform.position, answerPlace3.transform.position);
        if(Distance < 50)
        {
            answer3.transform.position = answerPlace3.transform.position;
            xp += xpValue;
            uang += uangValue;
            correct += 1;
            EnemyTakeDamage(damage);
            StartCoroutine("EnemyHit");
        }else
        {
            answer3.transform.position = answer3Pos;
            PlayerTakeDamage(damage);
            StartCoroutine("PlayerHit");
        }
    }
    public void DropAnswer4()
    {
        float Distance = Vector3.Distance(answer4.transform.position, answerPlace4.transform.position);
        if(Distance < 50)
        {
            answer4.transform.position = answerPlace4.transform.position;
            xp += xpValue;
            uang += uangValue;
            correct += 1;
            EnemyTakeDamage(damage);
            StartCoroutine("EnemyHit");
        }else
        {
            answer4.transform.position = answer4Pos;
            PlayerTakeDamage(damage);
            StartCoroutine("PlayerHit");
        }
    }
    public void DropAnswer5()
    {
        float Distance = Vector3.Distance(answer5.transform.position, answerPlace5.transform.position);
        if(Distance < 50)
        {
            answer5.transform.position = answerPlace5.transform.position;
            xp += xpValue;
            uang += uangValue;
            correct += 1;
            EnemyTakeDamage(damage);
            StartCoroutine("EnemyHit");
        }else
        {
            answer5.transform.position = answer5Pos;
            PlayerTakeDamage(damage);
            StartCoroutine("PlayerHit");
        }
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
