using SFS.UI;
using SFS;
using SFS.UI.ModGUI;
using UnityEngine;
using Type = SFS.UI.ModGUI.Type;
using Builder = SFS.UI.ModGUI.Builder;
using HarmonyLib;
using UITools;

namespace BuildSearchMod
{
    public class GUI
    {
        public static TextInput Entry;
        public static SFS.UI.ModGUI.Button SearchButton;
        // Create a GameObject for your window to attach to.
        static GameObject windowHolder;

        // Random window ID to avoid conflicts with other mods.
        static readonly int MainWindowID = Builder.GetRandomID();

        static Window window;
        static RectInt windowRect = new RectInt(0, 0, 300, 300); // x-position, y-position, width, height
        /*
        Call this method when you want to show your UI.
        */
        public static void ShowGUI()
        {
            // Create the window holder, attach it to the currently active scene so it's removed when the scene changes.
            windowHolder = Builder.CreateHolder(Builder.SceneToAttach.CurrentScene, "MyHolderName");

            window = UIToolsBuilder.CreateClosableWindow(windowHolder.transform, MainWindowID, windowRect.width, windowRect.height, windowRect.x, windowRect.y, true, true, 0.95f, "Parts Searcher");

            // Create a layout group for the window. This will tell the GUI builder how it should position elements of your UI.
            window.CreateLayoutGroup(Type.Vertical);

            Entry = Builder.CreateTextInput(window, windowRect.width, 50, 0, 0, "Enter Part Name");
            SearchButton = Builder.CreateButton(window, windowRect.width, 50, 0, 0, onClick:TextInputMethod, text:"Search");
        }

        /*
        Method to pass into the button element to give it functionality
        */
        static void TextInputMethod()
        {
            Entry.Equals(SFS.Base.partsLoader.partVariants);
        }
    }
}
