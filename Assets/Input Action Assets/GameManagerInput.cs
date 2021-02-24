// GENERATED AUTOMATICALLY FROM 'Assets/Input Action Assets/GameManagerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameManagerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameManagerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameManagerInput"",
    ""maps"": [
        {
            ""name"": ""Game manager"",
            ""id"": ""67082f25-887b-463f-bb0b-e811be6e79f5"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""5c8f7be9-6706-425d-906b-170f7a9fbf2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""fe48c105-a1e2-48b9-81c3-3c7cbdf69138"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6bf6a575-62a5-4b47-953f-ddec09c45c12"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d790d68e-afe3-4f51-b09c-c483829594b2"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""023d77fa-ae38-42dd-960b-14122c84e4a3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""430e8c12-78ce-42a9-b3f2-c7a7de414c27"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game manager
        m_Gamemanager = asset.FindActionMap("Game manager", throwIfNotFound: true);
        m_Gamemanager_Restart = m_Gamemanager.FindAction("Restart", throwIfNotFound: true);
        m_Gamemanager_Pause = m_Gamemanager.FindAction("Pause", throwIfNotFound: true);
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

    // Game manager
    private readonly InputActionMap m_Gamemanager;
    private IGamemanagerActions m_GamemanagerActionsCallbackInterface;
    private readonly InputAction m_Gamemanager_Restart;
    private readonly InputAction m_Gamemanager_Pause;
    public struct GamemanagerActions
    {
        private @GameManagerInput m_Wrapper;
        public GamemanagerActions(@GameManagerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_Gamemanager_Restart;
        public InputAction @Pause => m_Wrapper.m_Gamemanager_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gamemanager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamemanagerActions set) { return set.Get(); }
        public void SetCallbacks(IGamemanagerActions instance)
        {
            if (m_Wrapper.m_GamemanagerActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnRestart;
                @Pause.started -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamemanagerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GamemanagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GamemanagerActions @Gamemanager => new GamemanagerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGamemanagerActions
    {
        void OnRestart(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
