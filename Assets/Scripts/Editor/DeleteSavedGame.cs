using LikeADoom.Constants;
using LikeADoom.Core;

namespace LikeADoom.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System.IO;

    public class DeleteSavedGame : EditorWindow
    {
         [MenuItem("Tools/Delete Saved Game")]
         static void DeleteSavedGameFile()
         {
             string _path = Application.persistentDataPath + "/" + GameConstants.SaveFilePath;

             if (File.Exists(_path))
             {
                 File.Delete(_path);
                 AssetDatabase.Refresh();
                 Debug.Log("Saved game file deleted.");
             }
             else
             {
                 Debug.Log("No saved game file found at the specified path.");
             }
             
             PlayerPrefs.DeleteKey(nameof(GameSettings.IsNewGame));
         }
    }
}
