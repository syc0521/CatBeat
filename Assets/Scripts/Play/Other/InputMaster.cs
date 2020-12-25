// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Play/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
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
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Tap_Blue"",
                    ""type"": ""Button"",
                    ""id"": ""9d8e7d53-969d-405a-baf1-a9867036bc40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Tap_Purple"",
                    ""type"": ""Button"",
                    ""id"": ""f876fdc6-1584-48fe-a46d-7219f68f6949"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Tap_Red_Right"",
                    ""type"": ""Button"",
                    ""id"": ""289ec202-4e6c-4bce-beaf-d52d8e681c4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Tap_Blue_Right"",
                    ""type"": ""Button"",
                    ""id"": ""1d4bdcda-852f-4252-93b1-5d186db445d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c16562b-6180-4c69-a339-e45058ec0ca7"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87c789a7-ab03-4a3c-b50e-698a8ec6ceae"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5615c370-6828-42fc-b9c4-cb668cb87b0e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6964719-a487-434f-a6c3-ea238d3a8c43"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d75d4084-3fe0-43ca-ba95-0b8562cc4e1e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c3c4794-f211-4798-8080-bac9b13f1a7e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""766d5e6a-f35f-4c65-9e31-cfb67e06daaa"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Xbox_1"",
                    ""id"": ""e1e6eb80-0b24-4b89-8d5c-47fdba766a42"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Modifier"",
                    ""id"": ""b7a762de-310b-449a-a1f6-f65e633ce1c2"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button"",
                    ""id"": ""83ca00ad-b15a-4cbb-ab51-a55670a6d5e0"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard_1"",
                    ""id"": ""b9998d23-9c40-4855-9ebe-d584e6bb0fc7"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""93231aaa-e2f2-4fe2-b46e-fcaff22b7491"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fb9dd5c5-762c-47ff-8061-481236e3f36a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard_2"",
                    ""id"": ""417434cc-556b-49f8-8195-b9e82f8c04de"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""83a5e225-32a6-494d-9f8b-ae56712fa4fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""28e927b4-816e-427a-8c4f-91e53bbec572"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_2"",
                    ""id"": ""381c1429-d128-4bd8-b3cd-f23a3a38868f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""fae9feac-d844-420e-ac30-eecf1c41806f"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""1a4cf18e-7951-407f-b3b2-49fdb636439f"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_3"",
                    ""id"": ""9b9878be-5a75-46e4-b7e5-097ce1856bae"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4688d36d-4181-45d2-9a00-c659599a1ee0"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c024bf4e-5c1d-4104-8c0a-3d3f43d986af"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_4"",
                    ""id"": ""d350cbda-d7a5-4f77-881d-9f8d520bb18b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9bfa498a-e7b2-4910-b975-e63e6f17ab2c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""983ee5ed-6ec4-49bf-ad2c-0372b579359d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_5"",
                    ""id"": ""7b8eacbc-7179-4b85-88ea-0a11ccaebbda"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b6bbf7fe-6a61-4e96-92c8-e70f904b3ef6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c8b768ec-a2b1-4c72-ac8e-44c23f8753a3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_6"",
                    ""id"": ""03f7dc16-b620-46cf-bf3d-93193a19af50"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f975594f-348c-4b9a-9c34-75e069892923"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0b9368f0-4bfd-44da-9464-5c6718ed499e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_7"",
                    ""id"": ""a004024b-5447-4b7d-bb12-7e40e3653b1f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""6569bd44-20a4-4fee-b606-b411fd1be49c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ad5c5df1-85d3-4e84-8dc3-6807e0b3a0e9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_8"",
                    ""id"": ""3477e2a1-6f14-48c7-ad82-84d79a45fa04"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2a2ca8d0-0827-4553-91a9-34c87e5f246d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""4caeccba-ff66-497d-99ef-4969281e846f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_9"",
                    ""id"": ""b877a276-5439-4750-9e95-c146a2b3592f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""823ad68d-37d1-4d69-95b4-d11e6923f5bb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fc338232-c518-4007-8cb2-c08f905e5bd4"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_10"",
                    ""id"": ""300237d3-e4ae-4230-9022-d8b78813d462"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""c19dd399-9b29-446d-8701-21fe8ae807d4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f9c83101-88f3-42b0-8179-b7750abc199b"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_11"",
                    ""id"": ""423b648c-590a-4c0e-9565-90521a315b68"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""808bb2df-ca1c-494f-9e2e-ceb074f03af9"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""d77b3f1a-c05c-45fc-a446-e7b772b9bb47"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_12"",
                    ""id"": ""d7f4f7e9-6ccc-40fa-889a-10dc2cbacba6"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9c5b3869-698e-4177-8df4-4b48f2a4d1b9"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""b9863002-1112-40ad-bf72-b9cb37a28155"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_13"",
                    ""id"": ""b95eb68e-c61e-4de9-af08-9101cbcd33f8"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""2819ee45-5ff9-4efb-80fb-c0404a6f8ec1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""47a036aa-af9f-4238-bba1-838575f6d854"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox_14"",
                    ""id"": ""7b2f6f68-bcf7-4248-9a4f-140ffbef720f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e0fdbacc-c5eb-4a58-a994-4e735814e534"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""7992ee7b-2adf-4b01-86ba-dcf6b9a2d520"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard_3"",
                    ""id"": ""6ad02bf4-4d44-48b1-8273-3307016dab4b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a81d4f78-4836-4505-8452-ecde57084b84"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""253eb3da-fda2-4446-a85f-cd6109e4c97f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard_4"",
                    ""id"": ""9096562a-56c0-48be-a699-4419f74f1e4e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""d8fd6427-251c-4acf-aadf-31030a75ef7c"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""812b4b48-03f4-4beb-ab7a-0123fc27f867"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Purple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee66c6bc-c5bb-49ca-bfd5-4a20da29e60c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d84fd2d5-a73f-4273-baa2-8c9c79540de7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e242eaaf-fe40-4e30-8517-d91312cf2475"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d409b704-fb0e-4cf1-b31e-8458640eba32"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Red_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec28c9a5-cc6e-4217-a26e-2ce03f94e528"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Red_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fb3f6a1-05e8-489f-af7c-74406b77286d"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Tap_Blue_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a34f0073-ee49-430e-bafd-2faab1573488"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Tap_Blue_Right"",
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
        m_PlayController_Tap_Purple = m_PlayController.FindAction("Tap_Purple", throwIfNotFound: true);
        m_PlayController_Tap_Red_Right = m_PlayController.FindAction("Tap_Red_Right", throwIfNotFound: true);
        m_PlayController_Tap_Blue_Right = m_PlayController.FindAction("Tap_Blue_Right", throwIfNotFound: true);
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
    private readonly InputAction m_PlayController_Tap_Purple;
    private readonly InputAction m_PlayController_Tap_Red_Right;
    private readonly InputAction m_PlayController_Tap_Blue_Right;
    public struct PlayControllerActions
    {
        private @InputMaster m_Wrapper;
        public PlayControllerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap_Red => m_Wrapper.m_PlayController_Tap_Red;
        public InputAction @Tap_Blue => m_Wrapper.m_PlayController_Tap_Blue;
        public InputAction @Tap_Purple => m_Wrapper.m_PlayController_Tap_Purple;
        public InputAction @Tap_Red_Right => m_Wrapper.m_PlayController_Tap_Red_Right;
        public InputAction @Tap_Blue_Right => m_Wrapper.m_PlayController_Tap_Blue_Right;
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
                @Tap_Purple.started -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Purple;
                @Tap_Purple.performed -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Purple;
                @Tap_Purple.canceled -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Purple;
                @Tap_Red_Right.started -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red_Right;
                @Tap_Red_Right.performed -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red_Right;
                @Tap_Red_Right.canceled -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Red_Right;
                @Tap_Blue_Right.started -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue_Right;
                @Tap_Blue_Right.performed -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue_Right;
                @Tap_Blue_Right.canceled -= m_Wrapper.m_PlayControllerActionsCallbackInterface.OnTap_Blue_Right;
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
                @Tap_Purple.started += instance.OnTap_Purple;
                @Tap_Purple.performed += instance.OnTap_Purple;
                @Tap_Purple.canceled += instance.OnTap_Purple;
                @Tap_Red_Right.started += instance.OnTap_Red_Right;
                @Tap_Red_Right.performed += instance.OnTap_Red_Right;
                @Tap_Red_Right.canceled += instance.OnTap_Red_Right;
                @Tap_Blue_Right.started += instance.OnTap_Blue_Right;
                @Tap_Blue_Right.performed += instance.OnTap_Blue_Right;
                @Tap_Blue_Right.canceled += instance.OnTap_Blue_Right;
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
        void OnTap_Purple(InputAction.CallbackContext context);
        void OnTap_Red_Right(InputAction.CallbackContext context);
        void OnTap_Blue_Right(InputAction.CallbackContext context);
    }
}