using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] _PlayerNames;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _PlayerNames.Length; i++)
        {
            _PlayerNames[i].text = Constants.WinnersInOrder[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
