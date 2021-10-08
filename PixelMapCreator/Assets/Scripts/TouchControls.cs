// GENERATED AUTOMATICALLY FROM 'Assets/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""67c3d213-8eaf-4eb8-a1e8-164aad542524"",
            ""actions"": [
                {
                    ""name"": ""PrimaryFingerPos"",
                    ""type"": ""Value"",
                    ""id"": ""ab0cca5a-8c12-41e2-8776-75d31fc172b3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryFingerPos"",
                    ""type"": ""Value"",
                    ""id"": ""98b21cb2-6236-4bd7-87c4-aabfb547a3f7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryTouchContact"",
                    ""type"": ""Button"",
                    ""id"": ""04f35d7b-ac29-4d12-a519-21dbc016c433"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0fabf72-a83b-4233-8b47-f08d31d3d13c"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryFingerPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""662be4f1-f872-4fbe-bc11-e5ce3212fc77"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryFingerPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3bf6bc6-45c5-418b-9ea6-6af44b9ae8cb"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryFingerPos = m_Touch.FindAction("PrimaryFingerPos", throwIfNotFound: true);
        m_Touch_SecondaryFingerPos = m_Touch.FindAction("SecondaryFingerPos", throwIfNotFound: true);
        m_Touch_SecondaryTouchContact = m_Touch.FindAction("SecondaryTouchContact", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_PrimaryFingerPos;
    private readonly InputAction m_Touch_SecondaryFingerPos;
    private readonly InputAction m_Touch_SecondaryTouchContact;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryFingerPos => m_Wrapper.m_Touch_PrimaryFingerPos;
        public InputAction @SecondaryFingerPos => m_Wrapper.m_Touch_SecondaryFingerPos;
        public InputAction @SecondaryTouchContact => m_Wrapper.m_Touch_SecondaryTouchContact;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @PrimaryFingerPos.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryFingerPos;
                @PrimaryFingerPos.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryFingerPos;
                @PrimaryFingerPos.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryFingerPos;
                @SecondaryFingerPos.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryFingerPos;
                @SecondaryFingerPos.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryFingerPos;
                @SecondaryFingerPos.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryFingerPos;
                @SecondaryTouchContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchContact;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryFingerPos.started += instance.OnPrimaryFingerPos;
                @PrimaryFingerPos.performed += instance.OnPrimaryFingerPos;
                @PrimaryFingerPos.canceled += instance.OnPrimaryFingerPos;
                @SecondaryFingerPos.started += instance.OnSecondaryFingerPos;
                @SecondaryFingerPos.performed += instance.OnSecondaryFingerPos;
                @SecondaryFingerPos.canceled += instance.OnSecondaryFingerPos;
                @SecondaryTouchContact.started += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.performed += instance.OnSecondaryTouchContact;
                @SecondaryTouchContact.canceled += instance.OnSecondaryTouchContact;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnPrimaryFingerPos(InputAction.CallbackContext context);
        void OnSecondaryFingerPos(InputAction.CallbackContext context);
        void OnSecondaryTouchContact(InputAction.CallbackContext context);
    }
}
