using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoot:IPanel
{
    public PanelRoot() :base(null)
    {

    }
    protected override void OnInit()
    {
        base.OnInit();
        UnityTool.Instance.GetComponentFromChildren<Button>(this.gameObject, "ButtonStart").onClick.AddListener(() =>
        {
            Debug.Log("游戏开始");
        });
    }
    protected override void OnEnter()
    {
        base.OnEnter();
    }
}