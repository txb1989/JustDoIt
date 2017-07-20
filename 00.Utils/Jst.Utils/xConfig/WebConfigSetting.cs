using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Jst.Utils.xStrings;

namespace Jst.Utils.xConfig
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class WebConfigSetting:ISetting
    {
        /// <summary>
        /// 配置的节点
        /// </summary>
        private Dictionary<string,string> _settingDictionary = new Dictionary<string, string>();

        private Dictionary<string, string> _conStringDictionary = new Dictionary<string, string>();

        /// <summary>
        /// 最新更新时间
        /// </summary>
        private DateTime _configTime = DateTime.MinValue;

        /// <summary>
        /// 配置文件信息
        /// </summary>
        private FileInfo _configFileInfo;

        public WebConfigSetting()
        {
            DoReresh();
        }

        public void DoReresh()
        {
            UpdateConfigTime();
            if (_configFileInfo != null && _configFileInfo.LastWriteTime > _configTime)
            {
                return;
            }
            RereshSetting();
       
        }
        /// <summary>
        /// 刷新缓存的配置
        /// </summary>
        private void RereshSetting()
        {
            _settingDictionary.Clear();
            string[] allkeys =ConfigurationManager.AppSettings.AllKeys;
            if (allkeys.Length > 0)
            {
                foreach (var key in allkeys)
                {
                    string v = ConfigurationManager.AppSettings[key]??"";
                    if(!v.IsEmpty())_settingDictionary.Add(key,v);
                }
            }
        }
        
        /// <summary>
        /// 更新配置文件时间
        /// </summary>
        private void UpdateConfigTime()
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string webconfig = root + "web.config";
            string appconfig = root + "App.config";
            FileInfo webConfigInfo = new FileInfo(webconfig);
            FileInfo appConfigInfo = new FileInfo(appconfig);
            if (webConfigInfo.Exists)
            {
                _configTime = webConfigInfo.LastWriteTime;
                _configFileInfo = webConfigInfo;
            }
            else if (appConfigInfo.Exists)
            {
                _configTime = appConfigInfo.LastWriteTime;
                _configFileInfo = appConfigInfo;
            }
        }

        public T GetSettingValue<T>(string key,T defValue = default (T))
        {
            string strvalue = string.Empty;
            T value = defValue;
            if (_settingDictionary.TryGetValue(key, out strvalue))
            {
               value = (T)Convert.ChangeType(strvalue, typeof (T));
            }
            return value;
        }

        public string GetSettingValue(string key)
        {
            string value = string.Empty;
            if (_settingDictionary.TryGetValue(key, out value))
            {
                return value;
            }
            return value;
        }

        public string GetConnectString(string key)
        {
            string value = string.Empty;
            value = ConfigurationManager.ConnectionStrings[key].ToString();
            return value;
        }

        public string this[string key]
        {
            get { return GetSettingValue(key); }
        }
    }
}