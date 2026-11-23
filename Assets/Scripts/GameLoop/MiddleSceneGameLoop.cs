using System.Collections;
using UnityEngine;
using MainMenuScene1;
using MiddleScene;

public class MiddleSceneGameLoop : MonoBehaviour
{
    public Facade facade;
    private void Start()
    {
        facade = new Facade();
    }
    private void Update()
    {
        facade.GameUpdate();
    }

}