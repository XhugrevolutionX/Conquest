using System.Collections.Generic;
using UnityEngine;

public class TerritoryManager : MonoBehaviour
{
    
    private List<Territory> _territories = new List<Territory>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTerritory(List<Country> countries)
    {
        Territory territory = new Territory(countries);
        _territories.Add(territory);
    }
}
