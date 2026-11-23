
using System.Collections;
using UnityEngine;

public class ICharacter 
{ 
    

    public GameObject gameObject { get; private set; }
    public Transform transform=> gameObject.transform;
    private bool m_isLeft;
    private bool isInit;
    private bool isStart;
    private bool isShouldRemove;
    private bool isAlreadyRemove;
    
    public ICharacter(GameObject obj)
    {
        gameObject = obj;
    }
    public void GameUpdate()
    {
        if (!isInit)
        {
            isInit = true;
            OnInit();
        }
        OnCharacterUpdate();
    }
    protected virtual void OnInit() { }
    protected virtual void OnCharacterStart() { }
    protected virtual void OnCharacterUpdate()
    {
        if (!isStart)
        {
            isStart = true;
            OnCharacterStart();
        }
    }
    protected virtual void OnCharacterDieStart() { }
    protected virtual void OnCharacterDieUpdate() { }
    public void Remove()
    {
        isShouldRemove = true;
    }
    public bool isLeft
    {
        get => m_isLeft;
        set
        {
            if (value)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
            m_isLeft = value;
        }
    }
}