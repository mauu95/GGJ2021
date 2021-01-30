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
        string[] planets = {"found", "plutone", "nettuno", "urano", "saturno", "giove", "marte", "terra", "venere", "mercurio", "sole"};
        return Array.IndexOf(planets, planet.ToLower());


    }

    public string GetText()
    {
        return text;
    }
}
