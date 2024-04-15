using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public partial class InputManager : MonoBehaviour
    {
        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new InputManager();
                    _instance.Enable();
                }

                return _instance;
            }
            private set => _instance = value;
        }
    }
}