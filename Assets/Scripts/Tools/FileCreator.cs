using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileCreator : MonoBehaviour
{
    [NaughtyAttributes.Button]
    public void test()
    {
        
    }
    public static void createFIle( string fileName, string data)
    {
        string path = $"F:\\TestTextFile" + $"\\{fileName}.txt";
        if (File.Exists(path))
            File.Delete(path);
        FileStream file = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.Write(data);
        }
        System.Diagnostics.Process.Start("F:\\TestTextFile");

    }
    public static string readFile(string fileName)
    {
        string path = $"F:\\TestTextFile" + $"\\{fileName}.txt";
        string data = string.Empty;
        if (File.Exists(path))
        {
            using (FileStream file = new FileStream(path, FileMode.Open))
            {

                using (StreamReader reader = new StreamReader(file))
                {
                    data = reader.ReadToEnd();
                }
            }
            return data;
        }
        else
            return string.Empty;
    }
}
