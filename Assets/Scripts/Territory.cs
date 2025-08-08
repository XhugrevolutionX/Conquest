using System.Collections.Generic;
using UnityEngine;

public class Territory 
{
    
    private List<Country> _countries = new List<Country>();

    private int _troops;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Territory(List<Country> countries)
    {
        _countries = countries;
        _troops = 0;
    }
}
