using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using LLHandlers;
using GameplayEntities;
using LLGUI;


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
		}
		public static Dictionary<int, string> InputActions = new Dictionary<int, string>
		{
			[InputAction.SWING] = "Swing",
			[InputAction.BUNT] = "Bunt",
			[InputAction.GRAB] = "Grab",
			[InputAction.JUMP] = "Jump",
			[InputAction.TAUNT] = "Taunt",
			[InputAction.PAUSE] = "Pause",

		};
		public static Dictionary<int, string> NewInputActions = new Dictionary<int, string>
		{
			[InputAction.UP] = "Up",
			[InputAction.DOWN] = "Down",
			[InputAction.LEFT] = "Left",
			[InputAction.RIGHT] = "Right",
			[InputAction.EXPRESS_UP] = "Nice",
			[InputAction.EXPRESS_DOWN] = "Bring It",
			[InputAction.EXPRESS_LEFT] = "Oops",
			[InputAction.EXPRESS_RIGHT] = "Wow",
			[InputAction.OK] = "Select",
			[InputAction.MENU] = "Ready",
			[InputAction.SHLEFT] = "Skin Left",
			[InputAction.SHRIGHT] = "Skin Right",
		};
	}

	
	class EConfigurablesPatch
	{
		[HarmonyPatch(typeof(InputAction), nameof(InputAction.EConfigurables))]
		[HarmonyPostfix]
		static void EConfigurables_Postfix(ref IEnumerable<int> __result)
		{
			__result = new List<int>
			{
			InputAction.UP,
			InputAction.DOWN,
			InputAction.LEFT,
			InputAction.RIGHT,
			InputAction.SWING,
			InputAction.JUMP,
			InputAction.BUNT,
			InputAction.GRAB,
			InputAction.TAUNT,
			InputAction.EXPRESS_UP,
			InputAction.EXPRESS_DOWN,
			InputAction.EXPRESS_LEFT,
			InputAction.EXPRESS_RIGHT,
			InputAction.PAUSE,
			InputAction.OK,
			InputAction.MENU,

			// InputAction.BACK,
			// torn on including this, pause has the same function as far as i can tell. will look more into it.

			// InputAction.MENU_UP,
			// InputAction.MENU_DOWN,
			// InputAction.MENU_LEFT,
			// InputAction.MENU_RIGHT,
			// would like to add these if there is enough space, and if there is any exact purpose to. at the moment these cant be rebound and it kind of just locks arrow keys to menu keys.

			InputAction.SHLEFT,
			InputAction.SHRIGHT
			};	
		}
	}
	
	class GetInputActionNamePatch
	{
		[HarmonyPrefix]
		[HarmonyPatch(typeof(TextHandler), nameof(TextHandler.GetInputActionName))]
		public static bool GetInputActionName_Prefix(ref string __result, int inputAction)
		{
			string text = string.Empty;

			if (Plugin.InputActions.ContainsKey(inputAction))
			{
				text = Plugin.InputActions[inputAction];
				__result = TextHandler.Get("" + text.ToUpperInvariant(), new string[0]);
				return false;
			}

			if (Plugin.NewInputActions.ContainsKey(inputAction))
			{
				__result = Plugin.NewInputActions[inputAction];
				return false;
			}
			return true;
		}
		
	}
	
		class PCBBCFNFDJLPatch
	{
		[HarmonyPatch(typeof(HGFCCNMEEEF), nameof(HGFCCNMEEEF.PCBBCFNFDJL))]
		[HarmonyPrefix]
		static bool PCBBCFNFDJL_Prefix(HGFCCNMEEEF __instance)
			{
				__instance.CNINOFJOLNP.offsetBars = new Vector3(-5, -20f, -30f);
				(__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.TITLES;
				foreach (int num in InputAction.EConfigurables())
				{
					string inputActionName = TextHandler.GetInputActionName(num);
					(__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, inputActionName, HNEDEAGADKO.CGJIJHCPEPE, null) as OptionsBarInputConfig).inputAction = num;
					if (num == InputAction.UP || num == InputAction.DOWN || num == InputAction.LEFT || num == InputAction.RIGHT || num == InputAction.SWING || num == InputAction.BUNT || num == InputAction.GRAB || num == InputAction.JUMP || num == InputAction.TAUNT)
					{
						OptionsBarInputConfig optionsBarInputConfig = __instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.CGJIJHCPEPE, null) as OptionsBarInputConfig;
						optionsBarInputConfig.inputAction = num;
						optionsBarInputConfig.altInput = true;
					}
				}
				if (CGLLJHHAJAK.GIGAKBJGFDI.hasOptionMovement)
				{
					
				}
			   (__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.BUTTON1;
				(__instance.CNINOFJOLNP.AddBar(OptionsBarType.INPUT_CONFIG, string.Empty, HNEDEAGADKO.NMJDMHNMDNJ, null) as OptionsBarInputConfig).inputConfigBarType = InputConfigBarType.BUTTON2;
				return false;
			}
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
			InputAction.LEFT,
			InputAction.RIGHT,
			InputAction.UP,
			InputAction.DOWN
			};

		return false;
		}
	}



// TODO LIST:
// mouse support
// remove ; bound to bring it
// fix controller binding
// chnage how setting inputs is done entirely, make it needed to press select on an input to enter a new one, let stick inputs be set, and let arrow keys be set
// move input menu up, for more options. it will also look better
// look into possibility of having 3 bind slots


// NOTES:
// HGFCCNMEEEF.ANAFGCOBCAC bears a striking resemblance to HGFCCNMEEEF.PCBBCFNFDJL, there may be something here.
// HGFCCNMEEEF.OHCBIDFAHOE uses both HGFCCNMEEEF.ANAFGCOBCAC, and HGFCCNMEEEF.PCBBCFNFDJL. not sure for what.






