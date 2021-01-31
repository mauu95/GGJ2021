using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence
{
    private string planet;
    private string text;

    public Sentence(string planet, string text)
    {
        this.planet = planet;
        this.text = text;
    }

    public int GetPlanetID()
    {
        string[] planets =
        {
            "found", "plutone", "nettuno", "urano", "saturno", "giove", "marte", "terra", "venere", "mercurio", "sole"
        };
        return Array.IndexOf(planets, planet.ToLower());
    }

    public string GetPlanetName()
    {
        return planet;
    }
    
    public string GetEnglishPlanetName()
    {
        string[] planets =
        {
            "found", "plutone", "nettuno", "urano", "saturno", "giove", "marte", "terra", "venere", "mercurio", "sole"
        };
        string[] engPlanets =
        {
            "found", "pluto", "neptune", "uranus", "sapturne", "jupiter", "mars", "earth", "venus", "mercury", "sun"
        };

        int index = Array.IndexOf(planets, planet);

        if (index < 0 || index >= engPlanets.Length)
            return "";
        else
            return engPlanets[index];
    }


    public string GetText()
    {
        return text;
    }
}