using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainMenuScene1;
using MainMenuScene;
public class MainMenuGameLoop : MonoBehaviour
{
    // Start is called before the first frame update
    private Facade facade;
    void Start()
    {
        facade = new Facade();
    }

    // Update is called once per frame
    void Update()
    {
        facade.GameUpdate();
    }
}
