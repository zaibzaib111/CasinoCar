using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Racer
{
    public string Name { get; private set; }
    public float Form { get; private set; }
    public int Wins { get; private set; }
    public int Places { get; private set; }
    public float Rating { get; private set; }

    public Racer(string name, float form, int wins, int places)
    {
        Name = name;
        Form = form;
        Wins = wins;
        Places = places;
        CalculateRating();
    }

    public void UpdateStats(float form, int wins, int places)
    {
        Form = form;
        Wins = wins;
        Places = places;
        CalculateRating();
    }

    private void CalculateRating()
    {
        // Example rating calculation formula
        Rating = (Form * 0.4f) + (Wins * 0.5f) + (Places * 0.1f);
    }
}

public class RacerManager
{
    private List<Racer> racers = new List<Racer>();

    public void AddRacer(Racer racer)
    {
        racers.Add(racer);
    }

    public List<Racer> GetRacers()
    {
        return racers;
    }

    public void UpdateRacerStats(string name, float form, int wins, int places)
    {
        Racer racer = racers.Find(r => r.Name == name);
        if (racer != null)
        {
            racer.UpdateStats(form, wins, places);
        }
    }
}

public class RaceResultsPanel : MonoBehaviour
{
    public GameObject resultsPanel;
    public GameObject racerInfoPrefab;
    public Transform resultsContainer;

    public void UpdateResultsPanel(List<Racer> racers)
    {
        // Clear previous results
        foreach (Transform child in resultsContainer)
        {
            Destroy(child.gameObject);
        }

        // Display new results
        foreach (Racer racer in racers)
        {
            GameObject racerInfo = Instantiate(racerInfoPrefab, resultsContainer);
            racerInfo.transform.Find("Name").GetComponent<Text>().text = racer.Name;
            racerInfo.transform.Find("Form").GetComponent<Text>().text = racer.Form.ToString();
            racerInfo.transform.Find("Wins").GetComponent<Text>().text = racer.Wins.ToString();
            racerInfo.transform.Find("Places").GetComponent<Text>().text = racer.Places.ToString();
            racerInfo.transform.Find("Rating").GetComponent<Text>().text = racer.Rating.ToString("F2");
        }

        // Show the results panel
        resultsPanel.SetActive(true);
    }
}
