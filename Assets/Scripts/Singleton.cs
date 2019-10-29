using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;
    public static T Instance {
        get {
            var instanceObject = FindObjectOfType<T>();
            if(instance == null) {
                instance = instanceObject;
            } else if(instance != instanceObject) {
                Destroy(instanceObject);
            }

        DontDestroyOnLoad(instanceObject);

            return instance;
        }
    }
}
