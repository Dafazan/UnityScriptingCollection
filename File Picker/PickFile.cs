using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//Import Native File Picker

public class PickFile : MonoBehaviour
{
    public string FinalPath;
    
    public void OpenFiles()
    {
        string FileType = NativeFilePicker.ConvertExtensionToFileType("*");

        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
        {
            if (path == null)
                Debug.Log("eweuhan");
            else
            {
                FinalPath = path;
                Debug.Log("Diambil" + FinalPath);
            }

        },new string[] { FileType }


        );
    }

   
}
