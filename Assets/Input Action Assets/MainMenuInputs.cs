// GENERATED AUTOMATICALLY FROM 'Assets/Input Action Assets/MainMenuInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainMenuInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainMenuInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainMenuInputs"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""23753e67-9846-42c4-b5cc-3afc87596fc8"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""87cc39d8-4af7-4c3f-bbfc-663060620402"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""f0aa5a84-f7a3-4bc6-9d9b-53dc2c6ac556"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""689e618f-6fa3-47fe-84e6-5140c68101aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b518f849-ef5b-44c7-9d37-7418c79580f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""75fc4785-1b49-4e13-b6c8-2d2087c6d892"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65e63a65-96d9-40ae-87eb-8a3fdf4c6c03"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""575ced05-76a9-42e4-b446-5449a4328a75"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""35f25c0b-d20b-4897-9b06-037c57ecdce4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf680da8-4aab-46da-ac2a-b00900001807"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11245955-b0d3-4d56-ab2a-95ed6e30412f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""026488ab-3d00-4c34-8b93-410a9c113203"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2be780f9-90b7-4c8f-a851-b7a6c3195e72"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""62fa321b-6c6f-4899-8fb9-bae2b6c30db6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""785e12cb-ccd8-4889-be9d-c70f84535196"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
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
        m_MainMenu_Navigation = m_MainMenu.FindAction("Navigation", throwIfNotFound: true);
        m_MainMenu_Cancel = m_MainMenu.FindAction("Cancel", throwIfNotFound: true);
        m_MainMenu_Submit = m_MainMenu.FindAction("Submit", throwIfNotFound: true);
        m_MainMenu_Point = m_MainMenu.FindAction("Point", throwIfNotFound: true);
        m_MainMenu_Click = m_MainMenu.FindAction("Click", throwIfNotFound: true);
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
    private readonly InputAction m_MainMenu_Navigation;
    private readonly InputAction m_MainMenu_Cancel;
    private readonly InputAction m_MainMenu_Submit;
    private readonly InputAction m_MainMenu_Point;
    private readonly InputAction m_MainMenu_Click;
    public struct MainMenuActions
    {
        private @MainMenuInputs m_Wrapper;
        public MainMenuActions(@MainMenuInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_MainMenu_Navigation;
        public InputAction @Cancel => m_Wrapper.m_MainMenu_Cancel;
        public InputAction @Submit => m_Wrapper.m_MainMenu_Submit;
        public InputAction @Point => m_Wrapper.m_MainMenu_Point;
        public InputAction @Click => m_Wrapper.m_MainMenu_Click;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Navigation.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Navigation.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Navigation.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Cancel.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Submit.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSubmit;
                @Point.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigation.started += instance.OnNavigation;
                @Navigation.performed += instance.OnNavigation;
                @Navigation.canceled += instance.OnNavigation;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface IMainMenuActions
    {
        void OnNavigation(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
