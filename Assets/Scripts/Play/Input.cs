// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Play/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""PlayController"",
            ""id"": ""97b76e75-998f-4334-87d3-1c40cd527947"",
            ""actions"": [
                {
                    ""name"": ""Tap_Red"",
                    ""type"": ""Button"",
                    ""id"": ""1a60e731-7ed2-401b-b040-49cd2058f694"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tap_Blue"",
                    ""type"": ""Button"",
                    ""id"": ""9d8e7d53-969d-405a-baf1-a9867036bc40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c16562b-6180-4c69-a339-e45058ec0ca7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b601510a-0dde-44dd-9d51-3c8085aa3a87"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87c789a7-ab03-4a3c-b50e-698a8ec6ceae"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5615c370-6828-42fc-b9c4-cb668cb87b0e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6964719-a487-434f-a6c3-ea238d3a8c43"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d75d4084-3fe0-43ca-ba95-0b8562cc4e1e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2b97955-1633-437a-ba42-7ef39ff593fb"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4802323e-4191-4db9-9502-bd1d6f8ba264"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afd49d65-62dd-42ab-8ae7-76517d35c0a5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c3c4794-f211-4798-8080-bac9b13f1a7e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0c27b18-3263-480e-9d14-3cc426c9d0bf"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""766d5e6a-f35f-4c65-9e31-cfb67e06daaa"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc48c363-2353-4f90-b790-e9ffa523faee"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox"",
            ""bindingGroup"": ""Xbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayController
        m_PlayController = asset.FindActionMap("PlayController", throwIfNotFound: true);
        m_PlayController_Tap_Red = m_PlayController.FindAction("Tap_Red", throwIfNotFound: true);
        m_PlayController_Tap_Blue = m_PlayController.FindAction("Tap_Blue", throwIfNotFound: true);
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

    // PlayController
    private readonly InputActionMap m_PlayController;
    private IPlayControllerActions m_PlayControllerActionsCallbackInterface;
    private readonly InputAction m_PlayController_Tap_Red;
    private readonly InputAction m_PlayController_Tap_Blue;
    public struct PlayControllerActions
    {
        private @Input m_Wrapper;
        public PlayControllerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap_Red => m_Wrapper.m_PlayController_Tap_Red;
        public InputAction @Tap_Blue => m_Wrapper.m_PlayController_Tap_Blue;
        public InputActionMap Get() { return m_Wrapper.m_PlayController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayControllerActions instance)
        {
            if (m_Wrapper.m_PlayControllerActionsCallbackInterface != null)
            {
                @Tap_Red.started -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red;
                @Tap_Red.performed -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red;
                @Tap_Red.canceled -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red;
                @Tap_Blue.started -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue;
                @Tap_Blue.performed -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue;
                @Tap_Blue.canceled -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue;
            }
            m_Wrapper.m_PlayControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap_Red.started += instance.OnTap_Red;
                @Tap_Red.performed += instance.OnTap_Red;
                @Tap_Red.canceled += instance.OnTap_Red;
                @Tap_Blue.started += instance.OnTap_Blue;
                @Tap_Blue.performed += instance.OnTap_Blue;
                @Tap_Blue.canceled += instance.OnTap_Blue;
            }
        }
    }
    public PlayControllerActions @PlayController => new PlayControllerActions(this);
    private int m_XboxSchemeIndex = -1;
    public InputControlScheme XboxScheme
    {
        get
        {
            if (m_XboxSchemeIndex == -1) m_XboxSchemeIndex = asset.FindControlSchemeIndex("Xbox");
            return asset.controlSchemes[m_XboxSchemeIndex];
        }
    }
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayControllerActions
    {
        void OnTap_Red(InputAction.CallbackContext context);
        void OnTap_Blue(InputAction.CallbackContext context);
    }
}
