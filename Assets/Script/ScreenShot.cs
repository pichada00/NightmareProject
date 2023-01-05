using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    public int captureWidth = 1920;
    public int captureHeight = 1080;

    //configure with raw jpg png ppm (simple raw format)
    public enum Format { RAW, JPG, PNG, PPM }
    public Format format = Format.JPG;

    //folder to write output (default to data path)
    private string outputFolder;

    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenShot;
    private byte[] currentTexture;

    private bool isProcressing;
    // Start is called before the first frame update
    void Start()
    {
        outputFolder = Application.persistentDataPath + "/Screenshot/";

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
            Debug.Log("Save Path will be :" + outputFolder);
        }
    }

    private string CreateFileName(int width, int height)
    {
        string timesstamp = DateTime.Now.ToString("yyyyMMddTHHmmss");

        var filename = string.Format($"{outputFolder}/screen_{width}x{height}_{timesstamp}.{format.ToString().ToLower()}");

        return filename;
    }
    void Update()
    {
        if(Input.GetButtonDown("ScreenCapture"))
        {
            CaptureScreenshot();
        }
    }


    public void CaptureScreenshot()
    {
        isProcressing = true;

        //create screenshot objects
        if (renderTexture == null)
        {
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }

        //get main camera and render its output into the off-screen render texture created above
        Camera camera = Camera.main;
        camera.targetTexture = renderTexture;
        camera.Render();

        //mark the render texture as aactive and read the current pixel data into Texture2D
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);

        camera.targetTexture = null;
        RenderTexture.active = null;

        //get our filename
        string filename = CreateFileName((int)rect.width, (int)rect.height);

        //get file header/data byte for the specified image format
        byte[] fileHeader = null;
        byte[] fileData = null;

        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
        }
        else
        {
            string headerStr = string.Format($"P6\n{rect.width} {rect.height}\n255\n");
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
        }

        new System.Threading.Thread(() =>
        {
            var file = System.IO.File.Create(filename);
            if (fileHeader != null)
            {
                file.Write(fileHeader, 0, fileHeader.Length);
            }
            file.Write(fileData, 0, fileData.Length);
            file.Close();
            Debug.Log($"ScreenShot save{filename} , size{fileData.Length}");
            isProcressing = false;
        }

        ).Start();

        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
    }

    /*public IEnumerator ShowImage(string fileName)
    {
        yield return new WaitForEndOfFrame();
        //showImage.material.mainTexture = null;

    }*/
    // Update is called once per frame
    
}
