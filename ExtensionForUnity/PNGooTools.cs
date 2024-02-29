using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;


public static class PNGooTools
{
    private static string PNGooPath = $"{Application.dataPath}/PNGoo~/PNGoo.exe";


    // PNGoo压缩菜单项，只有当选中目录或图片时才启用
    [MenuItem("Assets/PNGoo/Compress", true)]
    [MenuItem("Tools/PNGoo/Compress", true)]
    private static bool PNGooMenuOptionValidation()
    {
        // 获取当前选中的资产路径
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        // 检查是否选中的是目录
        if (AssetDatabase.IsValidFolder(path)) return true;

        // 使用正则表达式来匹配图片文件扩展名
        return Regex.IsMatch(path, @"\.(png)$", RegexOptions.IgnoreCase);
    }

    [MenuItem("Assets/PNGoo/Compress")]
    [MenuItem("Tools/PNGoo/Compress", priority = 100)]
    private static void ProcessPNGooCompress()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path = Application.dataPath.Replace("Assets", path).Replace("/", "\\");

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = PNGooPath, // 第三方软件的路径
            Arguments = $"-p=\"{path}\"", // 命令行参数
            UseShellExecute = true, // 是否使用操作系统shell启动进程
            RedirectStandardError = false, // 是否重定向标准错误
            RedirectStandardInput = false, // 是否重定向标准输入
            RedirectStandardOutput = false, // 是否重定向标准输出
            CreateNoWindow = false, // 是否在新窗口中启动进程
        };

        var process = Process.Start(startInfo);
        process?.WaitForExit(); // 等待进程退出
        process?.Close();

        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/PNGoo/Open PNGoo", priority = 0)]
    private static void OpenPNGoo()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = PNGooPath, // 第三方软件的路径
            UseShellExecute = true, // 是否使用操作系统shell启动进程
        };

        var process = Process.Start(startInfo);
        process?.Close();
    }
}