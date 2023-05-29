using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added pinaka taas
using UnityEngine.SceneManagement; //added

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Image healthBar; //added

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount){
      health-= amount;
        if(health<=0){
            //Destroy(gameObject);  

            gameOverScreen.SetActive(true); //added

            Time.timeScale = 0; //pag gusto icontinue gawing = 1
        }
        UpdateHealthBar();
    }

    //added
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (health) / (float)(maxHealth); //added

    }

    //added
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
