using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

public class User
{
    public string name;
    public double time;
    public int score;

    public User(string name, double time, int score)
    {
        this.name = name;
        this.time = time;
        this.score = score;
    }
}
