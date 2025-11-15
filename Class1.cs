using System;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using LLGUI;
using LLHandlers;
using Rewired;


namespace moreinputs
{
    [BepInPlugin("us.wallace.plugins.llb.moreinputs", "more inputs Plug-In", "1.0.0.4")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogDebug("Patching effects settings...");

            var harmony = new Harmony("us.wallace.plugins.llb.moreinputs");
            harmony.PatchAll(typeof(EConfigurablesPatch));
            harmony.PatchAll(typeof(GetInputActionNamePatch));
            harmony.PatchAll(typeof(PCBBCFNFDJLPatch));
            harmony.PatchAll(typeof(SetMovementKeysPatch));
            harmony.PatchAll(typeof(BFGFOCFBGMJPatch));
            harmony.PatchAll(typeof(UpdateLooksPatch));
        }

        public static Dictionary<int, string> InputActions = new Dictionary<int, string>
        {
            [LLHandlers.InputAction.SWING] = "Swing",
            [LLHandlers.InputAction.BUNT] = "Bunt",
            [LLHandlers.InputAction.GRAB] = "Grab",
            [LLHandlers.InputAction.JUMP] = "Jump",
            [LLHandlers.InputAction.TAUNT] = "Taunt",
            [LLHandlers.InputAction.PAUSE] = "Pause",
        };

        public static Dictionary<int, string> NewInputActions = new Dictionary<int, string>
        {
            [LLHandlers.InputAction.UP] = "Up",
            [LLHandlers.InputAction.DOWN] = "Down",
            [LLHandlers.InputAction.LEFT] = "Left",
            [LLHandlers.InputAction.RIGHT] = "Right",
            [LLHandlers.InputAction.EXPRESS_UP] = "Nice",
            [LLHandlers.InputAction.EXPRESS_DOWN] = "Bring It",
            [LLHandlers.InputAction.EXPRESS_LEFT] = "Oops",
            [LLHandlers.InputAction.EXPRESS_RIGHT] = "Wow",
            [LLHandlers.InputAction.OK] = "Select",
            [LLHandlers.InputAction.MENU] = "Ready",
            [LLHandlers.InputAction.SHLEFT] = "Skin Left",
            [LLHandlers.InputAction.SHRIGHT] = "Skin Right",
        };
    }


    class EConfigurablesPatch
    {
        [HarmonyPatch(typeof(LLHandlers.InputAction), nameof(LLHandlers.InputAction.EConfigurables))]
        [HarmonyPostfix]
        static void EConfigurables_Postfix(ref IEnumerable<int> __result)
        {
            __result = new List<int>
            {
                LLHandlers.InputAction.UP,
                LLHandlers.InputAction.DOWN,
                LLHandlers.InputAction.LEFT,
                LLHandlers.InputAction.RIGHT,
                LLHandlers.InputAction.SWING,
                LLHandlers.InputAction.JUMP,
                LLHandlers.InputAction.BUNT,
                LLHandlers.InputAction.GRAB,
                LLHandlers.InputAction.TAUNT,
                LLHandlers.InputAction.EXPRESS_UP,
                LLHandlers.InputAction.EXPRESS_DOWN,
                LLHandlers.InputAction.EXPRESS_LEFT,
                LLHandlers.InputAction.EXPRESS_RIGHT,
                LLHandlers.InputAction.PAUSE,
                LLHandlers.InputAction.OK,
                LLHandlers.InputAction.MENU,
                LLHandlers.InputAction.BACK,
                LLHandlers.InputAction.MENU_UP,
                LLHandlers.InputAction.MENU_DOWN,
                LLHandlers.InputAction.MENU_LEFT,
                LLHandlers.InputAction.MENU_RIGHT,
                LLHandlers.InputAction.SHLEFT,
                LLHandlers.InputAction.SHRIGHT
            };
        }
    }

    public enum MyInputConfigBarType
    {
        MOREINPUT
    }

    class GetInputActionNamePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(TextHandler), nameof(TextHandler.GetInputActionName))]
        public static bool GetInputActionName_Prefix(ref string __result, int inputAction)
        {
            string text = string.Empty;
            bool flag = inputAction == LLHandlers.InputAction.UP;
            bool flag2 = flag;
            if (flag2)
            {
                text = "Up";
            }

            bool flag3 = inputAction == LLHandlers.InputAction.DOWN;
            bool flag4 = flag3;
            if (flag4)
            {
                text = "Down";
            }

            bool flag5 = inputAction == LLHandlers.InputAction.LEFT;
            bool flag6 = flag5;
            if (flag6)
            {
                text = "Left";
            }

            bool flag7 = inputAction == LLHandlers.InputAction.RIGHT;
            bool flag8 = flag7;
            if (flag8)
            {
                text = "Right";
            }

            bool flag9 = inputAction == LLHandlers.InputAction.SWING;
            bool flag10 = flag9;
            if (flag10)
            {
                text = "Swing";
            }

            bool flag11 = inputAction == LLHandlers.InputAction.JUMP;
            bool flag12 = flag11;
            if (flag12)
            {
                text = "Jump";
            }

            bool flag13 = inputAction == LLHandlers.InputAction.BUNT;
            bool flag14 = flag13;
            if (flag14)
            {
                text = "Bunt";
            }

            bool flag15 = inputAction == LLHandlers.InputAction.GRAB;
            bool flag16 = flag15;
            if (flag16)
            {
                text = "Grab";
            }

            bool flag17 = inputAction == LLHandlers.InputAction.TAUNT;
            bool flag18 = flag17;
            if (flag18)
            {
                text = "Taunt";
            }

            bool flag19 = inputAction == LLHandlers.InputAction.PAUSE;
            bool flag20 = flag19;
            if (flag20)
            {
                text = "Pause";
            }

            bool flag21 = inputAction == LLHandlers.InputAction.MENU;
            bool flag22 = flag21;
            if (flag22)
            {
                text = "Ready";
            }

            bool flag23 = inputAction == LLHandlers.InputAction.OK;
            bool flag24 = flag23;
            if (flag24)
            {
                text = "Ok";
            }

            bool flag25 = inputAction == LLHandlers.InputAction.BACK;
            bool flag26 = flag25;
            if (flag26)
            {
                text = "Back";
            }

            bool flag27 = inputAction == LLHandlers.InputAction.SHLEFT;
            bool flag28 = flag27;
            if (flag28)
            {
                text = "Skin L";
            }

            bool flag29 = inputAction == LLHandlers.InputAction.SHRIGHT;
            bool flag30 = flag29;
            if (flag30)
            {
                text = "Skin R";
            }

            bool flag31 = inputAction == LLHandlers.InputAction.EXPRESS_UP;
            bool flag32 = flag31;
            if (flag32)
            {
                text = "Nice";
            }

            bool flag33 = inputAction == LLHandlers.InputAction.EXPRESS_DOWN;
            bool flag34 = flag33;
            if (flag34)
            {
                text = "Bring It";
            }

            bool flag35 = inputAction == LLHandlers.InputAction.EXPRESS_LEFT;
            bool flag36 = flag35;
            if (flag36)
            {
                text = "Oops";
            }

            bool flag37 = inputAction == LLHandlers.InputAction.EXPRESS_RIGHT;
            bool flag38 = flag37;
            if (flag38)
            {
                text = "Wow";
            }

            bool flag39 = inputAction == LLHandlers.InputAction.MENU_UP;
            bool flag40 = flag39;
            if (flag40)
            {
                text = "M Up";
            }

            bool flag41 = inputAction == LLHandlers.InputAction.MENU_DOWN;
            bool flag42 = flag41;
            if (flag42)
            {
                text = "M Down";
            }

            bool flag43 = inputAction == LLHandlers.InputAction.MENU_LEFT;
            bool flag44 = flag43;
            if (flag44)
            {
                text = "M Left";
            }

            bool flag45 = inputAction == LLHandlers.InputAction.MENU_RIGHT;
            bool flag46 = flag45;
            if (flag46)
            {
                text = "M Right";
            }

            bool flag47 = text == string.Empty;
            bool flag48 = flag47;
            bool result;
            if (flag48)
            {
                __result = "???";
                result = true;
            }
            else
            {
                __result = TextHandler.Get(text.ToUpperInvariant() ?? "", new string[0]);
                result = false;
            }

            return result;
        }
    }

    class PCBBCFNFDJLPatch
    {
        [HarmonyPatch(typeof(HGFCCNMEEEF), nameof(HGFCCNMEEEF.PCBBCFNFDJL))]
        [HarmonyPrefix]
        static bool PCBBCFNFDJL_Prefix(HGFCCNMEEEF __instance)
        {
            __instance.CNINOFJOLNP.posBarNext = new Vector3(-150f, 110f, -30f);
            __instance.CNINOFJOLNP.offsetBars = new Vector3(-5f, -20f, -30f);
            (__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.TITLES;
            foreach (int num in LLHandlers.InputAction.EConfigurables())
            {
                string inputActionName = TextHandler.GetInputActionName(num);
                (__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, inputActionName, HNEDEAGADKO.CGJIJHCPEPE, null) as OptionsBarInputConfig).inputAction = num;
                bool flag = num == LLHandlers.InputAction.BUNT || num == LLHandlers.InputAction.GRAB || num == LLHandlers.InputAction.JUMP || num == LLHandlers.InputAction.TAUNT || num == LLHandlers.InputAction.SWING;
                if (flag)
                {
                    OptionsBarInputConfig optionsBarInputConfig = __instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.CGJIJHCPEPE, null) as OptionsBarInputConfig;
                    optionsBarInputConfig.inputAction = num;
                    optionsBarInputConfig.altInput = true;
                }
                bool flag2 = num == LLHandlers.InputAction.UP || num == LLHandlers.InputAction.DOWN || num == LLHandlers.InputAction.LEFT || num == LLHandlers.InputAction.RIGHT;
                if (flag2)
                {
                    OptionsBarInputConfig optionsBarInputConfig2 = __instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.CGJIJHCPEPE, null) as OptionsBarInputConfig;
                    optionsBarInputConfig2.inputAction = num;
                    optionsBarInputConfig2.altInput = true;
                }
            }
            (__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.BUTTON1;
            (__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.BUTTON2;
            return false;
        }
    }
    class UpdateLooksPatch
    {
    [HarmonyPatch(typeof(InputConfigElement), "UpdateLooks")]
    [HarmonyPrefix]
    public static bool UpdateLooks_Prefix(InputConfigElement __instance)
    {
        switch (__instance.inputConfigBarType)
        {
            case InputConfigBarType.ACTION:
            {
                int num = __instance.inputAction;
                __instance.SetText(InputHandler.GetControlName(__instance.inputConfigController, num, __instance.altInput));


                if (__instance.button.CanClick() != __instance.inputConfigController.DJFKIGINECC)
                {
                    __instance.button.SetActive(__instance.inputConfigController.DJFKIGINECC);
                    __instance.button.OnHoverOut(-1);
                }
                break;
            }
            case InputConfigBarType.TITLES:
                __instance.SetText(__instance.inputConfigController.KMBILNDIDKK);
                __instance.button.colDisabled = OptionsBarInputConfig.HEADER_COLOR;
                __instance.button.SetActive(false);
                break;
            case InputConfigBarType.BUTTON1:
                if (__instance.inputConfigController.DJFKIGINECC)
                {
                    __instance.SetTextCode("OPTIONS_BT_SAVE");
                }
                else
                {
                    __instance.SetTextCode("OPTIONS_BT_CHANGE");
                }
                break;
            case InputConfigBarType.BUTTON2:
                if (__instance.inputConfigController.DJFKIGINECC)
                {
                    __instance.SetTextCode("OPTIONS_BT_CANCEL");
                }
                else
                {
                    __instance.SetTextCode("BT_USE_DEFAULTS");
                }
                break;
            case InputConfigBarType.MOVEMENT:
                if (__instance.inputConfigController.NNGJKLIIDNI != Rewired.ControllerType.Keyboard)
                {
                    __instance.button.SetActive(false);
                    __instance.button.visible = false;
                }
                else
                {
                    __instance.SetTextCode("OPTIONS_MOVEMENT_" + InputHandler.movementKeys.ToString());
                    __instance.button.SetActive(__instance.inputConfigController.DJFKIGINECC);
                }
                break;
            case InputConfigBarType.EMPTY:
                
                __instance.SetText(string.Empty);
                __instance.button.SetActive(false);
                break;
        }
        return false;
    }
    }
    class SetMovementKeysPatch
    {
        [HarmonyPatch(typeof(InputHandler), nameof(InputHandler.SetMovementKeys))]
        [HarmonyPrefix]
        public static bool SetMovementKeys_Prefix(MovementKeys mk)
        {
            UnityEngine.KeyCode[] movementKeys = InputHandler.GetMovementKeys(mk);
            if (movementKeys == null)
            {
                GAMDIODFOCI.ICLAFBAPEFO("SetMovementKeys: unknown " + mk);
                return true;
            }

            int[] array = new int[]
            {
                LLHandlers.InputAction.LEFT,
                LLHandlers.InputAction.RIGHT,
                LLHandlers.InputAction.UP,
                LLHandlers.InputAction.DOWN
            };

            return false;
        }
    }

    class BFGFOCFBGMJPatch
    {
        [HarmonyPatch(typeof(HGFCCNMEEEF), nameof(HGFCCNMEEEF.BFGFOCFBGMJ))]
        [HarmonyPrefix]
        static bool BFGFOCFBGMJ_Prefix(HGFCCNMEEEF __instance)
        {
            foreach (JBKFDDKLDDG jbkfddklddg in HGFCCNMEEEF.inputConfigControllers)
            {
                if (jbkfddklddg.DOPGIJCCNLD != null)
                {
                    ControllerPollingInfo controllerPollingInfo = jbkfddklddg.GDEMBCKIDMA.Poll();
                    if (controllerPollingInfo.success)
                    {
                        if (jbkfddklddg.NNGJKLIIDNI == Rewired.ControllerType.Keyboard)
                        {
                            KeyCode keyboardKey = controllerPollingInfo.keyboardKey;
                            bool flag = false;
                            flag |= (keyboardKey >= KeyCode.A && keyboardKey <= KeyCode.Z);
                            flag |= (keyboardKey >= KeyCode.F1 && keyboardKey <= KeyCode.F15);
                            flag |= (keyboardKey >= KeyCode.UpArrow && keyboardKey <= KeyCode.LeftArrow);
                            flag |= (keyboardKey >= KeyCode.Mouse0 && keyboardKey <= KeyCode.Mouse6);
                            flag |= (keyboardKey == KeyCode.Tab || keyboardKey == KeyCode.Return || keyboardKey == KeyCode.Pause || keyboardKey == KeyCode.Escape);
                            flag |= (keyboardKey == KeyCode.Delete || keyboardKey == KeyCode.Insert || keyboardKey == KeyCode.Home || keyboardKey == KeyCode.End || keyboardKey == KeyCode.PageUp || keyboardKey == KeyCode.PageDown);
                            flag |= (keyboardKey >= KeyCode.Space && keyboardKey <= KeyCode.Underscore);
                            flag |= (keyboardKey >= KeyCode.Keypad0 && keyboardKey <= KeyCode.KeypadEquals);
                            flag |= (keyboardKey >= KeyCode.Numlock && keyboardKey <= KeyCode.Menu);
                            flag &= (keyboardKey != KeyCode.Minus || keyboardKey != KeyCode.KeypadMinus);
                            if (flag)
                            {
                                KeyCode[] movementKeys = InputHandler.GetMovementKeys();
                                if (movementKeys != null)
                                {
                                    for (int i = 0; i < movementKeys.Length; i++)
                                    {
                                        if (keyboardKey == movementKeys[i])
                                        {
                                            flag = false;
                                        }
                                    }
                                }
                            }

                            if (!flag)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            string text = controllerPollingInfo.elementIdentifierName.ToLowerInvariant();
                            if (text.Contains("d-pad"))
                            {
                                continue;
                            }

                            if (controllerPollingInfo.elementType == ControllerElementType.CompoundElement)
                            {
                                continue;
                            }

                            if (controllerPollingInfo.elementType == ControllerElementType.Axis &&
                                !text.Contains("trigger") && text != "l2" && text != "r2" && text != "l2 button" &&
                                text != "r2 button")
                            {
                                continue;
                            }
                        }

                        InputConfigElement dopgijccnld = jbkfddklddg.DOPGIJCCNLD;
                        bool altInput = jbkfddklddg.DOPGIJCCNLD.altInput;
                        InputConfigAssignment inputConfigAssignment;
                        if (jbkfddklddg.NNGJKLIIDNI == Rewired.ControllerType.Keyboard)
                        {
                            inputConfigAssignment.keyCode = controllerPollingInfo.keyboardKey;
                            inputConfigAssignment.elementId = 0;
                            inputConfigAssignment.elementType = ControllerElementType.Axis;
                        }
                        else
                        {
                            inputConfigAssignment.keyCode = KeyCode.None;
                            inputConfigAssignment.elementId = controllerPollingInfo.elementIdentifierId;
                            inputConfigAssignment.elementType = controllerPollingInfo.elementType;
                        }

                        inputConfigAssignment.inputAction = dopgijccnld.inputAction;
                        inputConfigAssignment.altInput = altInput;

                        if (!dopgijccnld.curAssignment.SameAs(inputConfigAssignment))
                        {
                            if (Input.GetKey(KeyCode.Backspace))
                            {
                                inputConfigAssignment.SetNone();
                            }

                            if (altInput)
                            {
                                InputConfigAssignment other = PPHBCKEFJEP.LIPIINMJBCC(jbkfddklddg.PIPEFDJDICP,
                                    dopgijccnld.inputAction, false);
                                if (inputConfigAssignment.SameInputAs(other))
                                {
                                    inputConfigAssignment.SetNone();
                                }
                            }

                            PPHBCKEFJEP.IJJPHFJAMGK(jbkfddklddg.PIPEFDJDICP, jbkfddklddg.NNGJKLIIDNI,
                                inputConfigAssignment);
                            dopgijccnld.curAssignment = inputConfigAssignment;
                            dopgijccnld.UpdateLooks();
                            __instance.LMLEFOBDCED(jbkfddklddg);
                        }
                    }
                }
            }

            return false;
        }
    }
}

// TODO LIST:
// mouse support
// remove ' bound to bring it
// fix controller binding
// chnage how setting inputs is done entirely, make it needed to press select on an input to enter a new one, let stick inputs be set, and let arrow keys be set


// NOTES:
// HGFCCNMEEEF.ANAFGCOBCAC bears a striking resemblance to HGFCCNMEEEF.PCBBCFNFDJL, there may be something here.
// HGFCCNMEEEF.OHCBIDFAHOE uses both HGFCCNMEEEF.ANAFGCOBCAC, and HGFCCNMEEEF.PCBBCFNFDJL. not sure for what.