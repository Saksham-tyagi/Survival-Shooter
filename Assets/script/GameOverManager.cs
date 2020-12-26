using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 10f;


    Animator anim;
	float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
			anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;
			if (restartTimer >= restartDelay) 
			{
				LoadByIndex (0);
			}
        }
    }
}

