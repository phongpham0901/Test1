using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Greeting : IGreeting
{
    private string _message = "Hello world!";

    string IGreeting.Message()
    {
        return _message;
    }
}