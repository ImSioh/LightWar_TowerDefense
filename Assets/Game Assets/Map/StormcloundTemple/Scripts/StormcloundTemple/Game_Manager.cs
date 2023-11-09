using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
	public static Game_Manager instance;
	public float waitingTime = 1;
	public GameObject spawnPoint;
	public GameObject[] enemies;
	public int maxEnemiesOnScreen;
	public int enemiesOnScreen;
	public int totalEnemies;
	public int enemiesPerSpawn;

	public float minSpawnInterval = 0.0f;
	public float maxSpawnInterval = 2.0f;
	private float nextSpawnTime;
	//public int currentGold;
	//public Text goldText;
	//public int maxWave;
	//public int currentWave = 1;
	//public Text CurrentWaveText;
	//public int maxHealth = 3;
	//public int currentHealth;
	//public Text CurrentHealthText;
	//public GameObject winWindow;
	//public GameObject loseWindow;


	private void Awake()
	{
		instance = this;
		//currentHealth = maxHealth;
		//nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}

	void Start()
	{

		CalculateNextSpawnTime();
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time >= nextSpawnTime)
		{
			SpawnRandomObject();
			CalculateNextSpawnTime();
		}

		//goldText.text = currentGold.ToString();
		//CurrentWaveText.text = currentWave.ToString() + "/" + maxWave.ToString();
		//CurrentHealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
		//if (currentWave < maxWave && enemiesOnScreen == 0)
		//{
		//	currentWave++;
		//	totalEnemies++;
		//	maxEnemiesOnScreen++;
		//	waitingTime -= 0.1f;
		//	StartCoroutine(Spawn());
		//}                                                                                                                                                                                
		//else if (currentWave == maxWave && enemiesOnScreen == 0)
		//{
		//	winWindow.SetActive(true);
		//	StopAllCoroutines();
		//}
	}

	private void CalculateNextSpawnTime()
	{
		float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
		nextSpawnTime = Time.time + randomInterval;
	}

	private void SpawnRandomObject()
	{
		if (enemiesOnScreen < totalEnemies)
		{
			for (int i = 0; i < enemiesPerSpawn; i++)
			{
				if (enemiesOnScreen < maxEnemiesOnScreen)
				{
					GameObject randomObject = enemies[0];
					Instantiate(randomObject, spawnPoint.transform.position, Quaternion.identity);
					enemiesOnScreen++;
				}
			}
		}
	}


	//IEnumerator Spawn()
	//{
	//	if (enemiesOnScreen < totalEnemies)
	//	{
	//	Debug.Log("Spwan");
	//		for (int i = 0; i < enemiesPerSpawn; i++)
	//		{
	//			if (enemiesOnScreen < maxEnemiesOnScreen)
	//			{

	//				GameObject newEnemy = Instantiate(enemies[0] as GameObject);
	//				newEnemy.transform.position = spawnPoint.transform.position;
	//				enemiesOnScreen++;
	//			}
	//		}
	//		yield return new WaitForSeconds(waitingTime);
	//		StartCoroutine(Spawn());
	//	}
	//}


	//public void AddGold(int amount)
	//{
	//	currentGold += amount;
	//}
	//public void ReduceGold(int amount)
	//{
	//	currentGold -= amount;
	//}
	//public void PlayerGetDamage()
	//{
	//	currentHealth--;
	//	if (currentHealth <= 0)
	//	{
	//		loseWindow.SetActive(true);
	//		currentHealth = 0;
	//	}
	//}

	//public void NextLevel()
	//{
	//	SceneManager.LoadScene(nextSceneToLoad);
	//	if (nextSceneToLoad > PlayerPrefs.GetInt("levelAt"))
	//	{
	//		PlayerPrefs.SetInt("levelAt", nextSceneToLoad);
	//	}
	//}
	//public void ReplyLevel()
	//{
	//	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	//}
	//public void MainMenu()
	//{
	//	SceneManager.LoadScene(0);
	//}

}
