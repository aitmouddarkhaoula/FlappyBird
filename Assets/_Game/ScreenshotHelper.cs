using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScreenshotHelper
{

    private const string ScreenshotFolderName = "Game-Screenshots/";

    [MenuItem("Proto/Take screenshot %#D")]
    public static void TakeScreenShot()
    {
        CreateScreenshotFolderIfNeeded();

        // var date = DateTime.Now.ToString().Replace(" ", "_").Replace("/", "-").Replace(":", "-");
        var screenshotBaseFilePath = ScreenshotFolderName + Application.productName + "-" + Screen.width + "x" +
                                     Screen.height;
        var screenshotFinalFilePath = GetIterationNameForFile(screenshotBaseFilePath) + ".png";
        ScreenCapture.CaptureScreenshot(screenshotFinalFilePath);
        Debug.Log(
            "[MWM-Utils] Screenshot located at: " + screenshotFinalFilePath + "\n" +
            "Wait for a few seconds for the screenshots to be written on your disk before calling this method again");
    }

    private static void CreateScreenshotFolderIfNeeded()
    {
        if (!Directory.Exists(ScreenshotFolderName))
        {
            Directory.CreateDirectory(ScreenshotFolderName);
        }
    }

    private static string GetIterationNameForFile(string baseFilePath)
    {
        if (!File.Exists(baseFilePath + ".png")) return baseFilePath;

        var iteration = 1;
        while (File.Exists(baseFilePath + "_" + iteration + ".png"))
        {
            iteration++;
        }

        return baseFilePath + "_" + iteration;
    }
}
