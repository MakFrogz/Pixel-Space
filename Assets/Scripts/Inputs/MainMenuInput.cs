// GENERATED AUTOMATICALLY FROM 'Assets/Input Action Assets/MainMenuInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainMenuInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainMenuInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainMenuInput"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""79fd8a2b-f233-42a3-958c-005f99cdfa62"",
            ""actions"": [
                {
                    ""name"": ""Cancel Credits"",
                    ""type"": ""Button"",
                    ""id"": ""a29bd211-6cee-4ad8-ac84-02bf6fbbb214"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3e50edb-54f0-4f03-ae4a-4240616fa1c3"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel Credits"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb7b9346-8618-4e6f-9308-10e68b877e81"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel Credits"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_CancelCredits = m_MainMenu.FindAction("Cancel Credits", throwIfNotFound: true);
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

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_CancelCredits;
    public struct MainMenuActions
    {
        private @MainMenuInput m_Wrapper;
        public MainMenuActions(@MainMenuInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CancelCredits => m_Wrapper.m_MainMenu_CancelCredits;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @CancelCredits.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancelCredits;
                @CancelCredits.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancelCredits;
                @CancelCredits.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancelCredits;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CancelCredits.started += instance.OnCancelCredits;
                @CancelCredits.performed += instance.OnCancelCredits;
                @CancelCredits.canceled += instance.OnCancelCredits;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface IMainMenuActions
    {
        void OnCancelCredits(InputAction.CallbackContext context);
    }
}
