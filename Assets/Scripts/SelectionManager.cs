using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cars;
    public Text playername;
    public Text TimerText;
    public Text carNo;
    public float time;
    public List<string> namesList = new List<string>()
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Henry", "Jack"
    };
    public List<string> newname;

    // Function to pick a random name
    public void PickRandomName()
    {
        // Generate a random index within the range of the list
        for (int i = 0; i <= 8; i++)
        {
            Constants.PlayerNames.Add(namesList[i]);
        }

        // Return the name at the rand
    }

    // Example usage
    IEnumerator Start()
    {
        // Call the function to pick a random name
        string Name;
        PickRandomName();
        for (int j = 0; j <= 8; j++)
        {
            foreach (var v in cars)
            {
                v.SetActive(false);
            }
            Name = Constants.PlayerNames[j];
            playername.text = Name;
            carNo.text = cars[j].gameObject.name;
            cars[j].SetActive(true);
            yield return new WaitForSeconds(3f);

        }



    }
    private void Update()
    {
        time -= Time.deltaTime;
        TimerText.text = Mathf.Ceil(time).ToString();
        if (time <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
