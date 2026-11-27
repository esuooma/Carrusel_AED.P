using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

// codigo del profesor
public static class AudioPlayer
{
    [DllImport("winmm.dll")]
    private static extern int mciSendString(
        string command,
        StringBuilder buffer,
        int bufferSize,
        IntPtr hwnd);

    public static void ReproducirBase64(string base64Mp3)
    {
        string tempPath = Path.Combine(Path.GetTempPath(), "audio_bgm.mp3");
        File.WriteAllBytes(tempPath, Convert.FromBase64String(base64Mp3));

        mciSendString("close bgm", null, 0, IntPtr.Zero);
        mciSendString("open \"" + tempPath + "\" type mpegvideo alias bgm", null, 0, IntPtr.Zero);
        mciSendString("play bgm repeat", null, 0, IntPtr.Zero);
    }

    public static void Detener()
    {
        mciSendString("close bgm", null, 0, IntPtr.Zero);
    }
}