using MainMenuScene1;
using System.Collections;
using UnityEngine;
namespace MainMenuScene
{
    public class Facade : AbstractFacade
    {
        private PlayerController m_PlayerController;
        protected override void OnInit()
        {
            base.OnInit();
            m_PlayerController = new PlayerController();
            GameMediator.Instance.RegisterController(m_PlayerController);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            m_PlayerController.GameUpdate();
        }
    }
}

