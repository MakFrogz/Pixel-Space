// GENERATED AUTOMATICALLY FROM 'Assets/Input Action Assets/GameManagerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameManagerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameManagerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameManagerInputs"",
    ""maps"": [
        {
            ""name"": ""GameManager"",
            ""id"": ""6ac81785-9ec2-4971-a8c8-7fcd33d6d555"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""06ff3a4a-cf1a-4478-83cf-8bde9e23f008"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""159cabb6-1181-4992-b762-9d5f594b09cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04049754-a498-4ccd-a922-6cae98a3b434"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8730c95c-3218-418c-86ea-8d572fd0d8df"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca22d8d3-46d7-4a57-9e65-6bce5830bc28"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73ce0be0-095d-4ae1-ac0d-3b711d1953a8"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameManager
        m_GameManager = asset.FindActionMap("GameManager", throwIfNotFound: true);
        m_GameManager_Pause = m_GameManager.FindAction("Pause", throwIfNotFound: true);
        m_GameManager_Restart = m_GameManager.FindAction("Restart", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GameManager
    private readonly InputActionMap m_GameManager;
    private IGameManagerActions m_GameManagerActionsCallbackInterface;
    private readonly InputAction m_GameManager_Pause;
    private readonly InputAction m_GameManager_Restart;
    public struct GameManagerActions
    {
        private @GameManagerInputs m_Wrapper;
        public GameManagerActions(@GameManagerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameManager_Pause;
        public InputAction @Restart => m_Wrapper.m_GameManager_Restart;
        public InputActionMap Get() { return m_Wrapper.m_GameManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameManagerActions set) { return set.Get(); }
        public void SetCallbacks(IGameManagerActions instance)
        {
            if (m_Wrapper.m_GameManagerActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnPause;
                @Restart.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_GameManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public GameManagerActions @GameManager => new GameManagerActions(this);
    public interface IGameManagerActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
