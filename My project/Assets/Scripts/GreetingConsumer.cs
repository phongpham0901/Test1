using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GreetingConsumer : MonoBehaviour
{
    // Injecting into a dynamically created GameObject requires additional steps (PlaceholderFactory)
    [Inject]
    private IGreeting greeting;

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(greeting.Message());
    }
}