using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : Singleton<TowerManager> {

    private TowerButton towerBtnPressed;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void selectedTower(TowerButton towerSelected) {
        towerBtnPressed = towerSelected;
        Debug.Log("Pressed:" + towerBtnPressed.gameObject);
    }
}
