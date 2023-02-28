using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using LLHandlers;
using GameplayEntities;
using Debug = UnityEngine.Debug; // ADDED this line as well 

namespace moreinputs
{
	[BepInPlugin("us.wallace.plugins.llb.moreinputs", "more inputs Plug-In", "1.0.0.3")]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
		{
			Debug.Log("Patching effects settings...");

			var harmony = new Harmony("us.wallace.plugins.llb.moreinputs");
			harmony.PatchAll();
		}
	}
	[HarmonyPatch(typeof(InputAction), nameof(InputAction.EConfigurables))]
	class EConfigurablesPatch
	{
		static void Postfix(ref global::System.Collections.Generic.IEnumerable<int> __result)
			
		{
			__result = new global::System.Collections.Generic.List<int>
		{
			global::LLHandlers.InputAction.UP,
			global::LLHandlers.InputAction.DOWN,
			global::LLHandlers.InputAction.LEFT,
			global::LLHandlers.InputAction.RIGHT,
			global::LLHandlers.InputAction.SWING,
			global::LLHandlers.InputAction.JUMP,
			global::LLHandlers.InputAction.BUNT,
			global::LLHandlers.InputAction.GRAB,
			global::LLHandlers.InputAction.TAUNT,
			global::LLHandlers.InputAction.EXPRESS_UP,
			global::LLHandlers.InputAction.EXPRESS_DOWN,
			global::LLHandlers.InputAction.EXPRESS_LEFT,
			global::LLHandlers.InputAction.EXPRESS_RIGHT,
			global::LLHandlers.InputAction.PAUSE,
			global::LLHandlers.InputAction.OK,
			global::LLHandlers.InputAction.MENU,

			// global::LLHandlers.InputAction.BACK,
			// torn on including this, pause has the same function as far as i can tell. will look more into it.

			// global::LLHandlers.InputAction.MENU_UP,
			// global::LLHandlers.InputAction.MENU_DOWN,
			// global::LLHandlers.InputAction.MENU_LEFT,
			// global::LLHandlers.InputAction.MENU_RIGHT,
			// would like to add these if there is enough space, and if there is any exact purpose to. at the moment these cant be rebound and it kind of just locks arrow keys to menu keys.

			global::LLHandlers.InputAction.SHLEFT,
			global::LLHandlers.InputAction.SHRIGHT

		};
			
		}
	}
	[HarmonyPatch(typeof(TextHandler), nameof(TextHandler.GetInputActionName))]
	class GetInputActionNamePatch
	{
		public static bool Prefix(ref string __result, int inputAction)
		{
			string text = string.Empty;
			if (inputAction == global::LLHandlers.InputAction.UP)
			{
				text = "Up";
				
			}
			if (inputAction == global::LLHandlers.InputAction.DOWN)
			{
				text = "Down";
				
			}
			if (inputAction == global::LLHandlers.InputAction.LEFT)
			{
				text = "Left";
				
			}
			if (inputAction == global::LLHandlers.InputAction.RIGHT)
			{
				text = "Right";
				
			}
			if (inputAction == global::LLHandlers.InputAction.SWING)
			{
				text = "Swing";
				
			}
			if (inputAction == global::LLHandlers.InputAction.JUMP)
			{
				text = "Jump";
				
			}
			if (inputAction == global::LLHandlers.InputAction.BUNT)
			{
				text = "Bunt";
				
			}
			if (inputAction == global::LLHandlers.InputAction.GRAB)
			{
				text = "Grab";
				
			}
			if (inputAction == global::LLHandlers.InputAction.TAUNT)
			{
				text = "Taunt";
				
			}
			if (inputAction == global::LLHandlers.InputAction.PAUSE)
			{
				text = "Pause";
				
			}
			if (inputAction == global::LLHandlers.InputAction.MENU)
			{
				text = "Ready";

			}
			if (inputAction == global::LLHandlers.InputAction.OK)
			{
				text = "Select";

			}
			if (inputAction == global::LLHandlers.InputAction.BACK)
			{
				text = "Back";

			}
			if (inputAction == global::LLHandlers.InputAction.SHLEFT)
			{
				text = "Skin Left";

			}
			if (inputAction == global::LLHandlers.InputAction.SHRIGHT)
			{
				text = "Skin Right";

			}
			if (inputAction == global::LLHandlers.InputAction.EXPRESS_UP)
			{
				text = "Nice";
				
			}
			if (inputAction == global::LLHandlers.InputAction.EXPRESS_DOWN)
			{
				text = "Bring It";
				
			}
			if (inputAction == global::LLHandlers.InputAction.EXPRESS_LEFT)
			{
				text = "Oops";
				
			}
			if (inputAction == global::LLHandlers.InputAction.EXPRESS_RIGHT)
			{
				text = "Wow";
				
			}
			if (inputAction == global::LLHandlers.InputAction.MENU_UP)
			{
				text = "Menu Up";

			}
			if (inputAction == global::LLHandlers.InputAction.MENU_DOWN)
			{
				text = "Menu Down";

			}
			if (inputAction == global::LLHandlers.InputAction.MENU_LEFT)
			{
				text = "Menu Left";

			}
			if (inputAction == global::LLHandlers.InputAction.MENU_RIGHT)
			{
				text = "Menu Right";

			}
			if (text == string.Empty)
			{
				__result = "???";
				return true;
			}
			__result = TextHandler.Get("" + text.ToUpperInvariant(), new string[0]); // at the moment having it all uppercase works well with space constraints, doesnt look good though
			// __result = TextHandler.Get(text.Normalize()); 
			// this kind of fixes it, still get [] around the words though, not sure why.
			return false;
		}
		
	}
	[HarmonyPatch(typeof(HGFCCNMEEEF), nameof(HGFCCNMEEEF.PCBBCFNFDJL))]
		class PCBBCFNFDJLPatch
	{
			 static bool Prefix(HGFCCNMEEEF __instance)
			{
				__instance.CNINOFJOLNP.offsetBars = new global::UnityEngine.Vector3(-5, -20f, -30f);
				(__instance.CNINOFJOLNP.AddBar(global::LLGUI.OptionsBarType.INPUT_CONFIG, string.Empty, global::HNEDEAGADKO.NMJDMHNMDNJ, null) as global::LLGUI.OptionsBarInputConfig).inputConfigBarType = global::LLGUI.InputConfigBarType.TITLES;
				foreach (int num in global::LLHandlers.InputAction.EConfigurables())
				{
					string inputActionName = global::LLHandlers.TextHandler.GetInputActionName(num);
					(__instance.CNINOFJOLNP.AddBar(global::LLGUI.OptionsBarType.INPUT_CONFIG, inputActionName, global::HNEDEAGADKO.CGJIJHCPEPE, null) as global::LLGUI.OptionsBarInputConfig).inputAction = num;
					if (num == global::LLHandlers.InputAction.UP || num == global::LLHandlers.InputAction.DOWN || num == global::LLHandlers.InputAction.LEFT || num == global::LLHandlers.InputAction.RIGHT || num == global::LLHandlers.InputAction.SWING || num == global::LLHandlers.InputAction.BUNT || num == global::LLHandlers.InputAction.GRAB || num == global::LLHandlers.InputAction.JUMP || num == global::LLHandlers.InputAction.TAUNT)
					{
						global::LLGUI.OptionsBarInputConfig optionsBarInputConfig = __instance.CNINOFJOLNP.AddBar(global::LLGUI.OptionsBarType.INPUT_CONFIG, string.Empty, global::HNEDEAGADKO.CGJIJHCPEPE, null) as global::LLGUI.OptionsBarInputConfig;
						optionsBarInputConfig.inputAction = num;
						optionsBarInputConfig.altInput = true;
					}
				}
				if (global::CGLLJHHAJAK.GIGAKBJGFDI.hasOptionMovement)
				{
					
				}
			   (__instance.CNINOFJOLNP.AddBar(global::LLGUI.OptionsBarType.INPUT_CONFIG, string.Empty, global::HNEDEAGADKO.NMJDMHNMDNJ, null) as global::LLGUI.OptionsBarInputConfig).inputConfigBarType = global::LLGUI.InputConfigBarType.BUTTON1;
				(__instance.CNINOFJOLNP.AddBar(global::LLGUI.OptionsBarType.INPUT_CONFIG, string.Empty, global::HNEDEAGADKO.NMJDMHNMDNJ, null) as global::LLGUI.OptionsBarInputConfig).inputConfigBarType = global::LLGUI.InputConfigBarType.BUTTON2;
				return false;
			}
		}
	}
	[HarmonyPatch(typeof(InputHandler), nameof(InputHandler.SetMovementKeys))]
	class SetMovementKeysPatch
	{
		public static bool Prefix(global::LLHandlers.MovementKeys mk)
		{
			global::UnityEngine.KeyCode[] movementKeys = global::LLHandlers.InputHandler.GetMovementKeys(mk);
			if (movementKeys == null)
			{
				global::GAMDIODFOCI.ICLAFBAPEFO("SetMovementKeys: unknown " + mk);
				return true;
			}
			int[] array = new int[]
			{
			global::LLHandlers.InputAction.LEFT,
			global::LLHandlers.InputAction.RIGHT,
			global::LLHandlers.InputAction.UP,
			global::LLHandlers.InputAction.DOWN
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






