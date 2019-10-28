using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
    const float delayTime = 0.5f; 

    private int enemiesOnScreen = 0;

    void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(enemySpawnWithDelay());
    }

    void spawnEnemy() {
        if(enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
            for(int i = 0; i < enemiesPerSpawn; i++) {
                if(enemiesOnScreen < maxEnemiesOnScreen) {
                    GameObject newEnemy = Instantiate(enemies[1]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                }
            }
        }
    }

    IEnumerator enemySpawnWithDelay() {
        spawnEnemy();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(enemySpawnWithDelay());
    }

    public void decrementEnemies() {
        if(enemiesOnScreen > 0) {
            enemiesOnScreen -= 1;
        }
    }

}
