using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Dialog;
using OfficeOpenXml;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class DialogConfigImporter
    {
        private static string SoPath = "Assets/Resources/Config/DialogConfig";
        private static readonly string EXcelPath = "Assets/Config/Excel/Dialog";
        private static Dictionary<string, Type> _allEventTypeDic;

        [MenuItem("Tools/人物对话配置/导入所有")]
        public static void ImportALl()
        {
            FindAllDialogEventType();
            string[] ExcelPaths = Directory.GetFiles(EXcelPath, "*.*", SearchOption.AllDirectories);

            foreach (var path in ExcelPaths)
            {
                if (!path.EndsWith(".xlsx") || path.Contains("~$")) continue;
                //根据路径找到对应的excel文件生产对应的对话配置
                ImportExcel(path);
                Debug.Log(path);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("Import Complete");
        }

        private static void ImportExcel(string excelPath)
        {
            FileInfo fileInfo = new FileInfo(excelPath);
            string configPath = $"{SoPath}/{Path.GetFileNameWithoutExtension(fileInfo.Name)}.asset";
            //判断是否已经存在对应的配置
            DialogConfig config = AssetDatabase.LoadAssetAtPath<DialogConfig>(configPath);
            bool create = config == null;
            if (create) config = ScriptableObject.CreateInstance<DialogConfig>();
            //读取excel文件数据
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                //获取第一张工作表
                ExcelWorksheet sheet = package.Workbook.Worksheets[1];
                //先清空so数据
                config.StepList.Clear();

                int maxRows = sheet.Cells.Rows;
                //遍历每一行数据
                for (int i = 2; i <= maxRows; i++)
                {
                    //判定是否是空行数据
                    if (string.IsNullOrEmpty(sheet.Cells[i, 1].Text.Trim())) continue;
                    //创建步骤数据
                    DialogStepConfig step = new DialogStepConfig();
                    step.ISPlayer = Convert.ToBoolean(sheet.Cells[i, 1].Value.ToString());
                    step.DialogText = sheet.Cells[i, 2].Text.Trim();
                    step.StartEvents = ConverDialogEvent(sheet.Cells[i, 3].Text.Trim());
                    step.EndEvents = ConverDialogEvent(sheet.Cells[i, 4].Text.Trim());
                    config.StepList.Add(step);
                }
            }

            if (create)
            {
                //创建新的配置
                AssetDatabase.CreateAsset(config, configPath);
                AssetDatabase.SaveAssets();
            }
            else
            {
                EditorUtility.SetDirty(config);
            }
        }

        private static List<IEvent_Dialog> ConverDialogEvent(string eventString)
        {
            List<IEvent_Dialog> eventList = new List<IEvent_Dialog>();
            if (string.IsNullOrEmpty(eventString)) return eventList;
            string[] eventStrings = eventString.Split('\n'); // 以回车符分割
            for (int i = 0; i < eventStrings.Length; i++)
            {
                string[] eventStringSplit = eventStrings[i].Split(':');
                if (eventStringSplit.Length != 2) Debug.LogError($"对话事件格式不符:{eventStrings[i]}");

                string typeString = eventStringSplit[0];
                string valueString = eventStringSplit[1];
                if (_allEventTypeDic.TryGetValue($"IEvent_{typeString}", out Type eventType))
                {
                    IEvent_Dialog obj = (IEvent_Dialog)Activator.CreateInstance(eventType);
                    obj.ConvertTostring(valueString);
                    eventList.Add(obj);
                }
                else Debug.LogError($"不存在的对话事件类型:{eventType}");
            }

            return eventList;
        }

        private static void FindAllDialogEventType()
        {
            _allEventTypeDic = new Dictionary<string, Type>();
            Type interfaceType = typeof(IEvent_Dialog);
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies(); // 所有程序集
            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes().Where(t => interfaceType.IsAssignableFrom(t) && !t.IsAbstract)
                    .ToArray();
                foreach (Type type in types)
                {
                    _allEventTypeDic.Add(type.Name, type);
                }
            }
        }
    }
}