using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;


public static class PNGooTools
{
    private static string PNGooPath = $"{Application.dataPath}/PNGoo~/PNGoo.exe";


    // PNGooѹ���˵��ֻ�е�ѡ��Ŀ¼��ͼƬʱ������
    [MenuItem("Assets/PNGoo/Compress", true)]
    [MenuItem("Tools/PNGoo/Compress", true)]
    private static bool PNGooMenuOptionValidation()
    {
        // ��ȡ��ǰѡ�е��ʲ�·��
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        // ����Ƿ�ѡ�е���Ŀ¼
        if (AssetDatabase.IsValidFolder(path)) return true;

        // ʹ��������ʽ��ƥ��ͼƬ�ļ���չ��
        return Regex.IsMatch(path, @"\.(png)$", RegexOptions.IgnoreCase);
    }

    [MenuItem("Assets/PNGoo/Compress")]
    [MenuItem("Tools/PNGoo/Compress", priority = 100)]
    private static void ProcessPNGooCompress()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < Selection.assetGUIDs.Length; i++)
        {
            var assetPath = Selection.assetGUIDs[i];
            var path = AssetDatabase.GUIDToAssetPath(assetPath);
            path = Application.dataPath.Replace("Assets", path).Replace("/", "\\");

            if (i > 0) sb.Append("|");
            sb.Append(path);
        }

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = PNGooPath, // �����������·��
            Arguments = $"-p=\"{sb.ToString()}\"", // �����в���
            UseShellExecute = true, // �Ƿ�ʹ�ò���ϵͳshell��������
            RedirectStandardError = false, // �Ƿ��ض����׼����
            RedirectStandardInput = false, // �Ƿ��ض����׼����
            RedirectStandardOutput = false, // �Ƿ��ض����׼���
            CreateNoWindow = false, // �Ƿ����´�������������
        };

        var process = Process.Start(startInfo);
        process?.WaitForExit(); // �ȴ������˳�
        process?.Close();

        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/PNGoo/Open PNGoo", priority = 0)]
    private static void OpenPNGoo()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = PNGooPath, // �����������·��
            UseShellExecute = true, // �Ƿ�ʹ�ò���ϵͳshell��������
        };

        var process = Process.Start(startInfo);
        process?.Close();
    }
}