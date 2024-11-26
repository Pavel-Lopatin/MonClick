using MonClick.Code.PlayerInput;
using System;
using UnityEngine;
using Zenject;

namespace MonClick.Code.GameServices
{
    public class GameplayInjector : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inputHandler = SelectInpuHandler();
            Container.Bind<InputHandler>().FromInstance(inputHandler);

        }

        private InputHandler SelectInpuHandler()
        {
            // TODO types of input

            var inputHandler = new MouseInputHandler();

            return inputHandler;
        }
    }
}


