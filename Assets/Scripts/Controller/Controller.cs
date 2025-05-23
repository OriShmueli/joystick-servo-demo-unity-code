//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/Controller/Controller.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""JoyStick"",
            ""id"": ""8471af76-4304-443c-bb75-fe2a560041b3"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fbacbb38-7ec5-4aa2-8b93-cd62d660a3ff"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2791b9ba-0a40-40c1-9b32-d93379b9043e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9680df89-c4d6-4786-b3e9-1cccd8463fc9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""30347995-4197-41fb-bfc7-76e70b24f181"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26c22765-d227-4856-a6ce-6ee58fefab70"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2111ecd5-1544-4223-afae-980c2f2d9165"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Computer"",
            ""id"": ""466e0f63-9e50-483b-baf7-fe33b0bb9475"",
            ""actions"": [
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""e2c949d4-89e4-4f1e-b7a4-482b5f154008"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad7c6817-4253-4820-8f1f-54476ccc35d0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // JoyStick
        m_JoyStick = asset.FindActionMap("JoyStick", throwIfNotFound: true);
        m_JoyStick_Horizontal = m_JoyStick.FindAction("Horizontal", throwIfNotFound: true);
        m_JoyStick_Up = m_JoyStick.FindAction("Up", throwIfNotFound: true);
        m_JoyStick_Down = m_JoyStick.FindAction("Down", throwIfNotFound: true);
        // Computer
        m_Computer = asset.FindActionMap("Computer", throwIfNotFound: true);
        m_Computer_Interaction = m_Computer.FindAction("Interaction", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // JoyStick
    private readonly InputActionMap m_JoyStick;
    private List<IJoyStickActions> m_JoyStickActionsCallbackInterfaces = new List<IJoyStickActions>();
    private readonly InputAction m_JoyStick_Horizontal;
    private readonly InputAction m_JoyStick_Up;
    private readonly InputAction m_JoyStick_Down;
    public struct JoyStickActions
    {
        private @Controller m_Wrapper;
        public JoyStickActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_JoyStick_Horizontal;
        public InputAction @Up => m_Wrapper.m_JoyStick_Up;
        public InputAction @Down => m_Wrapper.m_JoyStick_Down;
        public InputActionMap Get() { return m_Wrapper.m_JoyStick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JoyStickActions set) { return set.Get(); }
        public void AddCallbacks(IJoyStickActions instance)
        {
            if (instance == null || m_Wrapper.m_JoyStickActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JoyStickActionsCallbackInterfaces.Add(instance);
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
        }

        private void UnregisterCallbacks(IJoyStickActions instance)
        {
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
        }

        public void RemoveCallbacks(IJoyStickActions instance)
        {
            if (m_Wrapper.m_JoyStickActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJoyStickActions instance)
        {
            foreach (var item in m_Wrapper.m_JoyStickActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JoyStickActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JoyStickActions @JoyStick => new JoyStickActions(this);

    // Computer
    private readonly InputActionMap m_Computer;
    private List<IComputerActions> m_ComputerActionsCallbackInterfaces = new List<IComputerActions>();
    private readonly InputAction m_Computer_Interaction;
    public struct ComputerActions
    {
        private @Controller m_Wrapper;
        public ComputerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interaction => m_Wrapper.m_Computer_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Computer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ComputerActions set) { return set.Get(); }
        public void AddCallbacks(IComputerActions instance)
        {
            if (instance == null || m_Wrapper.m_ComputerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ComputerActionsCallbackInterfaces.Add(instance);
            @Interaction.started += instance.OnInteraction;
            @Interaction.performed += instance.OnInteraction;
            @Interaction.canceled += instance.OnInteraction;
        }

        private void UnregisterCallbacks(IComputerActions instance)
        {
            @Interaction.started -= instance.OnInteraction;
            @Interaction.performed -= instance.OnInteraction;
            @Interaction.canceled -= instance.OnInteraction;
        }

        public void RemoveCallbacks(IComputerActions instance)
        {
            if (m_Wrapper.m_ComputerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IComputerActions instance)
        {
            foreach (var item in m_Wrapper.m_ComputerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ComputerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ComputerActions @Computer => new ComputerActions(this);
    public interface IJoyStickActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
    public interface IComputerActions
    {
        void OnInteraction(InputAction.CallbackContext context);
    }
}
