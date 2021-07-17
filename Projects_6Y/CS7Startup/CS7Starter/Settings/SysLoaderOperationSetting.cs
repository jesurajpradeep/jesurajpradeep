using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS7Starter.Settings
{
    /// <summary>
    /// SysLoader運用設定ファイル
    /// </summary>
    public class SysLoaderOperationSetting
    {
        /// <summary>
        /// SysLoaderの運用設定
        /// </summary>
        public OperationInfo OperationInfo { get; set; }
        /// <summary>
        /// SysLoader設定情報
        /// </summary>
        public SysLoderSetting SysLoaderSetting { get; set; }
    }

    /// <summary>
    /// SysLoaderの運用設定
    /// </summary>
    public class OperationInfo
    {
        /// <summary>
        /// 起動時の連携処理設定
        /// </summary>
        public StartSetting StartSetting { get; set; }

        /// <summary>
        /// 終了時の連携処理設定
        /// </summary>
        public EndSetting EndSetting { get; set; }

        /// <summary>
        /// ショートカットキーの抑制
        /// </summary>
        public ShotCutKey ShotCutKey { get; set; }

        public KeyboardSetting KeyboardSetting { get; set; }

        /// <summary>
        /// 起動時の実行ファイル用のファイルパス
        /// </summary>
        //public List<StartRunFileList> StartRunFileList { get; set; }
        [System.Xml.Serialization.XmlArrayItem("StartRunFile")]
        public List<string> StartRunFileList { get; set; }

        /// <summary>
        /// 起動時の実行ファイル用のファイルパス2
        /// </summary>
        [System.Xml.Serialization.XmlArrayItem("StartRunFile")]
        public List<string> StartRunFileList2 { get; set; }

        /// <summary>
        /// 終了時の実行ファイル用のファイルパス
        /// </summary>
        //public List<EndRunFileList> EndRunFileList { get; set; }
        [System.Xml.Serialization.XmlArrayItem("EndRunFile")]
        public List<string> EndRunFileList { get; set; }

        /// <summary>
        /// 実行ファイル用のファイルパス For Portabl
        /// </summary>
        [System.Xml.Serialization.XmlArrayItem("RunFile")]
        public List<string> RunFileList { get; set; }

        // 2012.03.22 Add
        [System.Xml.Serialization.XmlArrayItem("RunFile")]
        public List<string> RunFileList2 { get; set; }

        // 2012.03.28 Add
        public TaskbarContorl TaskbarContorl { get; set; }

        [System.Xml.Serialization.XmlArrayItem("CheckItem")]
        public List<string> RunCheckList { get; set; }

        public string DBoptimizeExe { get; set; }

    }

    /// <summary>
    /// 起動時の連携処理設定
    /// </summary>
    public class StartSetting
    {
        /// <summary>
        /// PFの同時起動
        /// </summary>
        public int AutoStart { get; set; }
    }

    /// <summary>
    /// 終了時の連携処理設定
    /// </summary>
    public class EndSetting
    {
        /// <summary>
        /// CS-7の終了に伴う自動終了
        /// </summary>
        public int AutoEnd { get; set; }

        /// <summary>
        /// シャットダウン連携
        /// </summary>
        public int AutoShutdown { get; set; }
    }

    /// <summary>
    /// ショートカットキーの抑制
    /// </summary>
    public class ShotCutKey
    {
        /// <summary>
        /// 起動時のショートカットキー抑制有効/無効
        /// </summary>
        public int ShortCutKey_ON { get; set; }

        /// <summary>
        /// キー情報
        /// </summary>
        public List<Key> KeyList { get; set; }
    }

    /// <summary>
    /// キー情報
    /// </summary>
    public class Key
    {
        /// <summary>
        /// ショートカットキー抑制の有効/無効
        /// </summary>
        public int ON { get; set; }

        /// <summary>
        /// キー
        /// </summary>
        public string KEY { get; set; }
    }

    public class KeyboardSetting
    {
        public string UseFlag { get; set; }
        public string RegistryValue { get; set; }
    }

    /// <summary>
    /// 起動時の実行ファイル用のファイルパス
    /// </summary>
    public class StartRunFileList
    {
        /// <summary>
        /// 起動時の実行ファイル用のファイルパス
        /// </summary>
        public string StartRunFile { get; set; }
    }

    /// <summary>
    /// 終了時の実行ファイル用のファイルパス
    /// </summary>
    public class EndRunFileList
    {
        /// <summary>
        /// 終了時の実行ファイル用のファイルパス
        /// </summary>
        public string EndRunFile { get; set; }
    }

    /// <summary>
    /// 実行ファイル用のファイルパス For Portable
    /// </summary>
    public class RunFileList
    {
        /// <summary>
        /// 実行ファイル用のファイルパス
        /// </summary>
        public string RunFile { get; set; }
    }

    public class TaskbarContorl
    {
        public int TaskbarContorl_ON { get; set; }
        public string HideTaskbar { get; set; }
        public string ShowTaskbar { get; set; }
    }
    /// <summary>
    /// 起動チェックリスト
    /// </summary>
    public class RunCheckList
    {
        /// <summary>
        /// チェック項目
        /// </summary>
        public string CheckItem { get; set; }
    }
    /// <summary>
    /// SysLoader設定情報
    /// </summary>
    public class SysLoderSetting
    {
        public int WaitTimeCS7Execute { get; set; }
        public int EndFileTimeOut { get; set; }
        public int WarningInterval { get; set; }
        public int LogfilePeriod { get; set; }
    }
}
