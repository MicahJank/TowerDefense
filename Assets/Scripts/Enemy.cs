using UnityEngine;



public class Enemy : MonoBehaviour {

    public int target = 0;
    public Transform exitPoint;
    public GameObject[] waypoints;
    public float navigationUpdate;

    private Transform enemy;
    private float navigationTime = 0;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Transform>();
        waypoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update() {
        if(waypoints != null) {
            navigationTime += Time.deltaTime;
            if(navigationTime > navigationUpdate) {
                if(target < waypoints.Length) {
                    enemy.position = Vector2.MoveTowards(enemy.position, waypoints[target].transform.position, navigationTime);
                } else {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Checkpoint") {
            target += 1;
        } else if(other.tag == "Finish") {
            GameManager.instance.decrementEnemies();
            Destroy(gameObject);
        }
    }
}
