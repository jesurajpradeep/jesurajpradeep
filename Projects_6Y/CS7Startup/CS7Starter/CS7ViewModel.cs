
using System.Windows.Input;  // new 
using CS7Starter.Commands; // new 
using System.ComponentModel; // new 
using System.Diagnostics; // new 
using System.Windows; // new 
using System.IO; // new 
using System;
using System.Collections.Generic;
using System.IO.Compression;
using CS7Starter.Settings.InstitutionInformation;

namespace CS7Starter
{
    public delegate void CloseEventHandler();

    public delegate void MinimizeEventHandler();

    /// <summary>
    /// CS7ViewModel
    /// </summary>
    public class CS7ViewModel : ViewModelBase
    {
        #region Variables and Properties

        public event CloseEventHandler CloseEvent;

        public event CloseEventHandler CloseEventNewBinaryUI;

        public event CloseEventHandler CloseEventLanguageUpdateUI;

        public event MinimizeEventHandler MinimizeEvent;

        private CS7Model _CS7ModelInstance;

        public CS7Model CS7ModelInstance
        {
            get
            {
                return _CS7ModelInstance;
            }

            set
            {
                _CS7ModelInstance = value;
            }
        }

        public string Locale { get; set; }

        public string AutoShutdownValue
        {
            get; set;
        }

        public string Mode { get; set; }

        public string ScreenInfoFilePath;

        public string SysLoaderSettingPath
        {
            get
            {
                return @"C:\KonicaMinolta\Console\Config\System\SysLoader\SysLoaderOperationSetting.xml";
            }
                
        }

        public const string LOGPATH = @"C:\KonicaMinolta\Console\Data\log";

        public string PlatformSettingFilePath;

        private ICommand _SysLoaderCommand = null;


        public string PluginSettingPath
        {
            get
            {
                return @"C:\KonicaMinolta\Console\Config\System\Platform\System\PluginSetting";
            }
        }

        public string LauguageFolderPath
        {
            get
            {
                return @"C:\KonicaMinolta\Console\Config\System\Platform\System\Language";
            }
        }

        public string LogFolderPath
        {
            get
            {
                return @"C:\KonicaMinolta\Console\Data\log";
            }
        }

        public string AppFolderPath
        {
            get
            {
                return @"C:\KonicaMinolta\Console\Bin\Platform\Applications";
            }
        }

        #endregion

        #region ICommand

        //CurrentLogZipper
        //ForeGroundWindowTrackerCommand
        private ICommand _ForeGroundWindowTrackerCommand = null;

        public ICommand ForeGroundWindowTrackerCommand
        {
            get
            {
                if (_ForeGroundWindowTrackerCommand == null)
                {
                    _ForeGroundWindowTrackerCommand = new RelayCommand(param => OnForeGgWindTracker());
                }
                return _ForeGroundWindowTrackerCommand;
            }
        }


        private ICommand _CurrentLogZipperCommand = null;

        public ICommand CurrentLogZipperCommand
        {
            get
            {
                if (_CurrentLogZipperCommand == null)
                {
                    _CurrentLogZipperCommand = new RelayCommand(param => OnLogZipCommand());
                }
                return _CurrentLogZipperCommand;
            }
        }

        public ICommand SysLoaderCommand
        {
            get
            {
                if (_SysLoaderCommand == null)
                {
                    _SysLoaderCommand = new RelayCommand(param => OnSysLoaderCommand());
                }
                return _SysLoaderCommand;
            }
        }


        private ICommand _LogClearCommand = null;

        public ICommand LogClearCommand
        {
            get
            {
                if (_LogClearCommand == null)
                {
                    _LogClearCommand = new RelayCommand(param => OnLogClearCommand());
                }
                return _LogClearCommand;
            }
        }

        private ICommand _DataClearCommand = null;

        public ICommand DataClearCommand
        {
            get
            {
                if (_DataClearCommand == null)
                {
                    _DataClearCommand = new RelayCommand(param => OnDataClearCommand());
                }
                return _DataClearCommand;
            }
        }

        private ICommand _KillAllCommand = null;

        public ICommand KillAllCommand
        {
            get
            {
                if (_KillAllCommand == null)
                {
                    _KillAllCommand = new RelayCommand(param => OnKillAllCommand());
                }
                return _KillAllCommand;
            }
        }

        // KillAllCommand
        private ICommand _ExitCommand = null;

        public ICommand ExitCommand
        {
            get
            {
                if (_ExitCommand == null)
                {
                    _ExitCommand = new RelayCommand(param => OnExitCommand());
                }
                return _ExitCommand;
            }
        }

        private ICommand _MinimizeToTrayCommand = null;

        public ICommand MinimizeToTrayCommand
        {
            get
            {
                if (_MinimizeToTrayCommand == null)
                {
                    _MinimizeToTrayCommand = new RelayCommand(param => OnMinimizeToTray());
                }
                return _MinimizeToTrayCommand;
            }
        }


        //MinimizeToTrayCommand

        private ICommand _AutoShutdownCommand = null;

        public ICommand AutoShutdownCommand
        {
            get
            {
                if (_AutoShutdownCommand == null)
                {
                    _AutoShutdownCommand = new RelayCommand(param => OnAutoShutdownUpdateCommand());
                }
                return _AutoShutdownCommand;
            }
        }
        //AutoShutdownCommand
        //ProcessCheckCommand

        private ICommand _processCheckCommand = null;

        public ICommand ProcessCheckCommand
        {
            get
            {
                if (_processCheckCommand == null)
                {
                    _processCheckCommand = new RelayCommand(param => OnProessCheckCommand());
                }
                return _processCheckCommand;
            }
        }

       
        //NewBinaryCommand

        private ICommand _NewBinaryCommand = null;

        public ICommand NewBinaryCommand
        {
            get
            {
                if (_NewBinaryCommand == null)
                {
                    _NewBinaryCommand = new RelayCommand(param => OnNewBinaryCommand());
                }
                return _NewBinaryCommand;
            }
        }

        //LanguageUpdateCommand

        private ICommand _LanguageUpdateCommand = null;

        public ICommand LanguageUpdateCommand
        {
            get
            {
                if (_LanguageUpdateCommand == null)
                {
                    _LanguageUpdateCommand = new RelayCommand(param => OnLanguageUpdateCommand());
                }
                return _LanguageUpdateCommand;
            }
        }

        private ICommand _FolderOpenCommand = null;

        public ICommand FolderOpenCommand
        {
            get
            {
                if (_FolderOpenCommand == null)
                {
                    _FolderOpenCommand = new RelayCommand(param => OnFolderOpen(param.ToString()));
                }
                return _FolderOpenCommand;
            }
        }
      

       

        private ICommand _ScreenModeUpdateCommand = null;

        public ICommand ScreenModeUpdateCommand
        {
            get
            {
                if (_ScreenModeUpdateCommand == null)
                {
                    _ScreenModeUpdateCommand = new RelayCommand(param => OnScreenModeUpdateCommand());
                }
                return _ScreenModeUpdateCommand;
            }
        }

        #endregion

        #region Constructor
        public CS7ViewModel()
        {
            _CS7ModelInstance = new CS7Model();
            PlatformSettingFilePath = "C:\\KonicaMinolta\\Console\\Config\\System\\Platform\\System\\Platform\\PlatformSetting.xml";
            ScreenInfoFilePath = "C:\\KonicaMinolta\\Console\\Config\\System\\Platform\\System\\Platform\\ScreenInfo\\ScreenInfo.xml";

            CS7Starter.Settings.PlatformSetting obj = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.PlatformSetting), PlatformSettingFilePath) as CS7Starter.Settings.PlatformSetting;
            CS7Starter.Settings.SysLoaderOperationSetting sysLoaderSetting = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath) as CS7Starter.Settings.SysLoaderOperationSetting;
            if (sysLoaderSetting.OperationInfo.EndSetting.AutoShutdown == 1)
            {
                AutoShutdownValue = "AutoShutdown ON";
            }
            else
            {
                AutoShutdownValue = "AutoShutdown OFF";
            }

            Locale = obj.Locale;
            CS7Starter.Settings.ScreenInfo screenInfobj = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.ScreenInfo), ScreenInfoFilePath) as CS7Starter.Settings.ScreenInfo;
            Mode = screenInfobj.Mode;

        }
        #endregion

        #region  Command Handlers
        private void OnFolderOpen(string folderPath)
        {
            Process proc = new Process();
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            proc.StartInfo.FileName = folderPath;
            proc.Start();
        }

        

        private void OnLanguageUpdateCommand()
        {
            LanguageUpdateUI uiObj = new LanguageUpdateUI(this);
            

            uiObj.ShowDialog();
            
            //Locale = objvm.Locale;
            //OnPropertyChanged("Locale");

            /*
            CS7Starter.Settings.PlatformSetting obj = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.PlatformSetting), PlatformSettingFilePath) as CS7Starter.Settings.PlatformSetting;
            if(Locale.Contains("USA"))
            {
                obj.Locale = "JPN";
            }
            else
            {
                obj.Locale = "USA";
            }

            Locale = obj.Locale;
            OnPropertyChanged("Locale");
            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.PlatformSetting), PlatformSettingFilePath, obj);

    */
        }

        private void OnAutoShutdownUpdateCommand()
        {
            CS7Starter.Settings.SysLoaderOperationSetting sysLoadSettings = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath) as CS7Starter.Settings.SysLoaderOperationSetting;
            if(sysLoadSettings.OperationInfo.EndSetting.AutoShutdown == 1)
            {
                sysLoadSettings.OperationInfo.EndSetting.AutoShutdown = 0;
                AutoShutdownValue = "AutoShutdown OFF";
            }
            else
            {
                sysLoadSettings.OperationInfo.EndSetting.AutoShutdown = 1;
                AutoShutdownValue = "AutoShutdown ON";
            }
            OnPropertyChanged("AutoShutdownValue");
            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath, sysLoadSettings);

        }
        
        
        private void OnScreenModeUpdateCommand()
        { 
            //ScreenInfoFilePath

            CS7Starter.Settings.ScreenInfo obj = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.ScreenInfo), ScreenInfoFilePath) as CS7Starter.Settings.ScreenInfo;
            if (Mode.Contains("Floating"))
            {
                obj.Mode = "FullScreen";
            }
            else
            {
                obj.Mode = "Floating";
            }

            Mode = obj.Mode;
            OnPropertyChanged("Mode");
            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.ScreenInfo), ScreenInfoFilePath, obj);
        }

        private void OnNewBinaryCommand()
        {
            NewBinarySetupUI uiObj = new NewBinarySetupUI(this);
            CS7Starter.Settings.SysLoaderOperationSetting sysLoadSettings = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath) as CS7Starter.Settings.SysLoaderOperationSetting;
            if (sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON == 1)
            {
                TaskbarScriptStatus = "TASKBAR SCRIPT ON";
            }
            else
            {
                TaskbarScriptStatus = "TASKBAR SCRIPT OFF";
            }

            uiObj.ShowDialog();
        }

        private void CopyCorrectFiles()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "Setup.bat";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO batch file");
            }
        }

        private void OnSysLoaderCommand()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"C:\KonicaMinolta\Console\Bin\BackProcess\SysLoader\SysLoader.exe";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = @"C:\KonicaMinolta\Console\Bin\BackProcess\SysLoader\";
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO sysloader.exe");
            }

        }

        private void OnForeGgWindTracker()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "focus.exe";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO focus.exe");
            }
        }

        private void OnLogZipCommand()
        {
            string folderName = string.Empty;
            string zipName = string.Empty;
            try
            {
                string[] fileList = Directory.GetFiles(LOGPATH);
                string[] directoryList = Directory.GetDirectories(LOGPATH);

                folderName = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                zipName = folderName + ".zip";
                CreateDirectory(folderName);

                List<FileInfo> fileInfoList = GetFileInfoListTodaysDate(LOGPATH);
                LogFileCopy(fileInfoList, folderName);

                foreach (string directory in directoryList)
                {
                    string directoryName = Path.GetFileName(directory);
                    string destinationFolder = folderName + @"\" + directoryName;
                    CreateDirectory(destinationFolder);
                    fileInfoList = GetFileInfoListTodaysDate(directory);
                    LogFileCopy(fileInfoList, destinationFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                ZipFile.CreateFromDirectory(folderName, zipName);
                Directory.Delete(folderName,true);
                string path = Directory.GetCurrentDirectory() + @"\" + zipName;
                string res = string.Format("Log file is zipped {0}", path);
                MessageBox.Show(res);
            }
            catch(Exception ex)
            {
                string result = string.Format(" Exception message - {0} Unable to Zip the files", ex.Message);
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private List<FileInfo> GetFileInfoListTodaysDate(string folderPath)
        {
            List<FileInfo> fileInfoList = new List<FileInfo>();
            try
            {
                string[] fileList = Directory.GetFiles(folderPath);
                foreach (string fileName in fileList)
                {
                    DateTime datetime = File.GetLastWriteTime(fileName);
                    string fileModifiedDate = datetime.ToString("yyyy-MM-dd");
                    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

                    string file = Path.GetFileName(fileName);
                    if (string.Equals(fileModifiedDate, todayDate))
                    {
                        FileInfo info = new FileInfo(fileName);
                        fileInfoList.Add(info);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fileInfoList;
        }
        

        private void LogFileCopy(List<FileInfo> FileList, string folderName)
        {
            try
            {
                foreach (FileInfo fileInfo in FileList)
                {
                    string DirectoryPath = Path.GetDirectoryName(fileInfo.ToString());

                    if (fileInfo.Exists)
                    {
                        fileInfo.CopyTo(folderName + @"\" + fileInfo.Name);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static bool CreateDirectory(string folderName)
        {
            bool result = true;
            try
            {
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private void OnLogClearCommand()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "LogDelete.bat";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO batch file LogDelete.bat");
            }
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        private void OnDataClearCommand()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"C:\KonicaMinolta\Console\Bin\Initialization.exe";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = @"C:\KonicaMinolta\Console\Bin\";
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO Initialization.exe file");
            }
        }

        private void OnProessCheckCommand()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ProcessCheck.exe";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO executable ProcessCheck.exe");
            }

        }

        private void OnKillAllCommand()
        {

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "kill_all.bat";
            if (CS7ModelInstance.IsFileExists(proc.StartInfo.FileName))
            {
                proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                proc.Start();
            }
            else
            {
                MessageBox.Show("NO BATCH FILE kill_all.bat");
            }

        }

        private void OnMinimizeToTray()
        {
            if(MinimizeEvent !=null)
                MinimizeEvent();
        }

        private void OnExitCommand()
        {
            if (CloseEvent != null)
            {
                CloseEvent();
            }
        }

        /// <summary>
        /// RenameTaskbarFolder
        /// </summary>
        private void RenameTaskbarFolder()
        {
            CS7Starter.Settings.SysLoaderOperationSetting sysLoadSettings = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath) as CS7Starter.Settings.SysLoaderOperationSetting;
            if (sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON == 1)
            {
                sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON = 0;
            }
            else
            {
                sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON = 1;
            }

            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath, sysLoadSettings);
            //MessageBox.Show("TaskBar is Renamed");

            /*
            string source = "C:\\KonicaMinolta\\Console\\Bin\\BackProcess\\SysLoader\\Taskbar";
            string destination = "C:\\KonicaMinolta\\Console\\Bin\\BackProcess\\SysLoader\\Taskbar_";
            if (Directory.Exists(source))
            {
                Directory.Move(source, destination);
                MessageBox.Show("Taskbar folder renamed to Taskbar_");
            }
            else
            {
                MessageBox.Show("Taskbar folder already renamed");
            }
            */
        }

        /// <summary>
        /// CopyDefaultSettingFiles
        /// </summary>
        private void CopyDefaultSettingFiles()
        {
            string SourcePath = @"LMS";
            string DestinationPath = @"C:\KonicaMinolta\Console\Config\System\LMS\";
            string LMSFolderDir = @"C:\KonicaMinolta\Console\Config\System\LMS";
            string LicenseFilePath = @"C:\KonicaMinolta\Console\Config\System\LMS\LicenseNew.xml";

            if (!Directory.Exists(LMSFolderDir))
            {
                Directory.CreateDirectory(LMSFolderDir);
            }
            else
            {
                if (File.Exists(LicenseFilePath))
                {
                    MessageBox.Show("License File Present");
                    return;
                }
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                if(newPath.Contains("LicenseNew"))
                {
                    MessageBox.Show("License File Moved");
                }
            }

        }
        #endregion

        #region Laungage update view

        private string _SelectedItemCmbBox;
        public string SelectedItemCmbBox
        {
            get
            {
                return _SelectedItemCmbBox;
            }
            set
            {
                _SelectedItemCmbBox = value;
                OnPropertyChanged(SelectedItemCmbBox);

            }
        }

        private ICommand _LanguageSaveCommand;
        public ICommand LanguageSaveCommand
        {
            get
            {
                if (_LanguageSaveCommand == null)
                {
                    _LanguageSaveCommand = new RelayCommand(param => OnLanguageSaveCommand());
                }
                //OnPropertyChanged(Locale);
                return _LanguageSaveCommand;

            }
        }

        //LanguageUIExitCommand

        private ICommand _LanguageUIExitCommand;
        public ICommand LanguageUIExitCommand
        {
            get
            {
                if (_LanguageUIExitCommand == null)
                {
                    _LanguageUIExitCommand = new RelayCommand(param => OnLanguageSaveExitCommand());
                }
                //OnPropertyChanged(Locale);
                return _LanguageUIExitCommand;

            }
        }

        private void OnLanguageSaveExitCommand()
        {
            if (LanguageSaveCommand != null)
            {
                CloseEventLanguageUpdateUI();
            }
        }

        private void OnLanguageSaveCommand()
        {
            CS7Starter.Settings.PlatformSetting obj = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.PlatformSetting), PlatformSettingFilePath) as CS7Starter.Settings.PlatformSetting;
            if(SelectedItemCmbBox == null)
            {
                MessageBox.Show("Please select a language");
                return;
            }

            if (SelectedItemCmbBox.Contains(""))
            {
                obj.Locale = SelectedItemCmbBox;
            }
            Locale = obj.Locale;
            SelectedItemCmbBox = obj.Locale;
            OnPropertyChanged("SelectedItemCmbBox");
            OnPropertyChanged("Locale");
            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.PlatformSetting), PlatformSettingFilePath, obj);
            OnLanguageSaveExitCommand();
        }

        #endregion

        #region NewBinaryUI related

        // ExitNewBinaryWindowCommand

        private ICommand _ExitNewBinaryWindowCommand;
        public ICommand ExitNewBinaryWindowCommand
        {
            get
            {
                if (_ExitNewBinaryWindowCommand == null)
                {
                    _ExitNewBinaryWindowCommand = new RelayCommand(param => OnExitNewBinaryUI());
                }
                return _ExitNewBinaryWindowCommand;

            }
        }

        private ICommand _TraiLicenseCommand;
        public ICommand TraiLicenseCommand
        {
            get
            {
                if (_TraiLicenseCommand == null)
                {
                    _TraiLicenseCommand = new RelayCommand(param => OnTrialLicenseCommand());
                }
                return _TraiLicenseCommand;

            }
        }


        private ICommand _CopyCorrectFilesCommand;
        public ICommand CopyCorrectFilesCommand
        {
            get
            {
                if (_CopyCorrectFilesCommand == null)
                {
                    _CopyCorrectFilesCommand = new RelayCommand(param => OnCorrectFilesUpdateCommand());
                }
                return _CopyCorrectFilesCommand;

            }
        }

        private string _TaskbarScriptStatus;

        /// <summary>
        /// 
        /// </summary>
        public string TaskbarScriptStatus
        {
            get
            {
                return _TaskbarScriptStatus;
            }
            set
            {
                _TaskbarScriptStatus = value;
                OnPropertyChanged("TaskbarScriptStatus");
            }
        }

        private ICommand _TaskbarSettingUpdateCommand;
        public ICommand TaskbarSettingUpdateCommand
        {
            get
            {
                if (_TaskbarSettingUpdateCommand == null)
                {
                    _TaskbarSettingUpdateCommand = new RelayCommand(param => OnTaskbarSettingUpdateCommand());
                }
                return _TaskbarSettingUpdateCommand;

            }
        }


        private void OnTrialLicenseCommand()
        {
            if(File.Exists(@"C:\KonicaMinolta\Console\Config\System\LMS\LicenseNew.xml"))
            {
                MessageBox.Show("License file is available in LMS folder. Can't Activate TRIAL LICENSE.");
                return;
            }

            string path = @"C:\KonicaMinolta\Console\Config\System\Platform\System\Platform\InstitutionInformation\EnviromentInfo.xml";
            EnvironmentSetting envSetting = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.InstitutionInformation.EnvironmentSetting), path) as CS7Starter.Settings.InstitutionInformation.EnvironmentSetting;

            foreach(EnvironmentGroup group in envSetting.EnviromentGroupList)
            {
                if(group.Name == "EquipmentInfo")
                {
                    foreach(EnvironmentParam param in group.EnviromentParamList)
                    {
                        if(param.Key == "PharmaceuticalSerialNumber")
                        {
                            if(param.Value == "")
                            {
                                param.Value = "A33G-12345";
                                MessageBox.Show("Trial License Updated");
                                break;
                            }
                            else
                            {
                                param.Value = "";
                                MessageBox.Show("Trial License Removed");
                                break;
                            }
                        }
                    }
                }
            }
            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.InstitutionInformation.EnvironmentSetting), path, envSetting);
        }

        private void OnCorrectFilesUpdateCommand()
        {
            CopyCorrectFiles();

            /*
            string SourcePath = @"LMS";
            string DestinationPath = @"C:\KonicaMinolta\Console\Config\System\LMS\";
            string LMSFolderDir = @"C:\KonicaMinolta\Console\Config\System\LMS";
            string LicenseFilePath = @"C:\KonicaMinolta\Console\Config\System\LMS\LicenseNew.xml";

            if (!Directory.Exists(LMSFolderDir))
            {
                Directory.CreateDirectory(LMSFolderDir);
            }
            else
            {
                if (File.Exists(LicenseFilePath))
                {
                    MessageBox.Show("License File Present");
                    return;
                }
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                if (newPath.Contains("LicenseNew"))
                {
                    MessageBox.Show("License File Moved");
                }
            }
            */
        }

        private void OnTaskbarSettingUpdateCommand()
        {
            CS7Starter.Settings.SysLoaderOperationSetting sysLoadSettings = CS7ModelInstance.DeSerialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath) as CS7Starter.Settings.SysLoaderOperationSetting;
            if (sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON == 1)
            {
                TaskbarScriptStatus = "TASKBAR SCRIPT OFF";
                sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON = 0;
            }
            else
            {
                TaskbarScriptStatus = "TASKBAR SCRIPT ON";
                sysLoadSettings.OperationInfo.TaskbarContorl.TaskbarContorl_ON = 1;
            }

            CS7ModelInstance.Serialize(typeof(CS7Starter.Settings.SysLoaderOperationSetting), SysLoaderSettingPath, sysLoadSettings);
        }

        private void OnExitNewBinaryUI()
        {
            if(CloseEventNewBinaryUI != null)
            {
                CloseEventNewBinaryUI();
            }
        }

        #endregion


        

    }
}
