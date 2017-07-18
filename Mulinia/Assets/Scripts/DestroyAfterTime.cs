using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    public float time;
    private float current;

    void Start()
    {
        current = 0;
    }
	
    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;

        if(current >= time)
        {
            Destroy(gameObject);
        }
            
    }
}
