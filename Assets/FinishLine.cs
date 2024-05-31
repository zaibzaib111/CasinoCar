using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FinishLine : MonoBehaviour
{
    List<string> _CarNames;
    List<string> _Winners;
    [SerializeField] GameObject _Leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        _Winners = new List<string>();
        _CarNames = new List<string>
        {
            "Car1",
            "Car2",
            "Car3",
            "Car4",
            "Car5",
            "Car6",
            "Car7",
            "Car8",
            "Car9",
        };
        StartCoroutine(CheckIfWon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<RCC_AICarController>().lap > 1) 
        {
            AddWinner(other.transform.parent.tag);
            Debug.Log("Car: " + other.transform.parent.tag);
        }
    }

    private void AddWinner(string name)
    {
        int index = -1;
        foreach(string n in _Winners)
        {
            if (n == name) return;
        }
        _Winners.Add(name);
        for (int i = 0; i < _CarNames.Count; i++)
        {
            if(name == _CarNames[i])
            {
                index = i;
                break;
            }
        }
        if(index == -1) Debug.LogError("index unassigned");
        Constants.WinnersInOrder.Add(Constants.PlayerNames[index]);
    }

    IEnumerator CheckIfWon()
    {
        while (true)
        {
            if (_Winners.Count >= 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    Debug.Log("Car no: " + _Winners[i] + " Driver name: " + Constants.WinnersInOrder[i]);
                }
                yield return new WaitForSeconds(1.5f);
                _Leaderboard.SetActive(true);
                StopCoroutine(CheckIfWon());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
