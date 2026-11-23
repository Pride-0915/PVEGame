using System.Collections;
using UnityEngine;

namespace MainMenuScene1
{
    public class UIController:AbstractController
    {
        private PanelRoot rootPanel;
        public UIController() { }
        protected override void OnInit()
        {
            base.OnInit();
            rootPanel = new PanelRoot();
        }
        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            rootPanel.GaneUpdate();
        }
    }
}