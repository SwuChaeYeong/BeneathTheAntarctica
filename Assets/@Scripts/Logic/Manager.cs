using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance {
        get {
            if (null == instance) {
                instance = (T)FindObjectOfType(typeof(T));
                
                if (null == instance) {
                    var managerObject = new GameObject();
                    instance = managerObject.AddComponent<T>();
                    managerObject.name = typeof(T).ToString() + " (Manager)";
                }
            }
            return instance;
        }
    }

    public void Awake() {
        if (null == instance) {
            instance = (T)FindObjectOfType(typeof(T));
            
            if (null == instance) {
                var managerObject = new GameObject();
                instance = managerObject.AddComponent<T>();
                managerObject.name = typeof(T).ToString() + " (Manager)"; 
            }
        }
    }
}
