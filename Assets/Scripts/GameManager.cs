using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    // Start is called before the first frame update
    public RCC_AICarController[] newAI; 
    public int[] speed;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    void Start()
    {
        for (int i=0; i<newAI.Length; i++)
        {
            newAI[i].maximumSpeed = speed[i];
        }
    }
    void Update()
    {
        //Debug.Log("LAP: " + newAI[0].lap);

        for (int i = 0; i < newAI.Length; i++)
        {
            newAI[i].maximumSpeed = speed[i];
        }
    }
}
