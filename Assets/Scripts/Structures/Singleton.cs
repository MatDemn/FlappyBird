using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T Instance;
    protected virtual void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
            
        }
        Instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
