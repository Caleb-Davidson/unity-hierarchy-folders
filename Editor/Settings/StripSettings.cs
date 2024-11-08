﻿namespace UnityHierarchyFolders.Editor
{
    using Runtime;
    using UnityEditor;
    using UnityEditor.SettingsManagement;

    internal static class StripSettings
    {
        private const string PackageName = "com.xsduan.hierarchy-folders";

        private static Settings _instance;
        private static UserSetting<StrippingMode> _playModeSetting;
        private static UserSetting<StrippingMode> _buildSetting;
        private static UserSetting<bool> _capitalizeName;
        private static UserSetting<bool> _addSeparatorSymbols;
        private static UserSetting<bool> _stripFoldersFromPrefabsInPlayMode;
        private static UserSetting<bool> _stripFoldersFromPrefabsInBuild;

        public static StrippingMode PlayMode
        {
            get
            {
                InitializeIfNeeded();
                return _playModeSetting.value;
            }

            set => _playModeSetting.value = value;
        }

        public static StrippingMode Build
        {
            get
            {
                InitializeIfNeeded();
                return _buildSetting.value;
            }

            set => _buildSetting.value = value;
        }

        public static bool CapitalizeName
        {
            get
            {
                InitializeIfNeeded();
                return _capitalizeName.value;
            }

            set => _capitalizeName.value = value;
        }
        
        public static bool AddSeparatorSymbols 
        {
            get 
            {
                InitializeIfNeeded();
                return _addSeparatorSymbols.value;
            }
            
            set => _addSeparatorSymbols.value = value;
        }

        public static bool StripFoldersFromPrefabsInPlayMode
        {
            get
            {
                InitializeIfNeeded();
                return _stripFoldersFromPrefabsInPlayMode.value;
            }

            set => _stripFoldersFromPrefabsInPlayMode.value = value;
        }

        public static bool StripFoldersFromPrefabsInBuild
        {
            get
            {
                InitializeIfNeeded();
                return _stripFoldersFromPrefabsInBuild.value;
            }

            set => _stripFoldersFromPrefabsInBuild.value = value;
        }

        private static void InitializeIfNeeded()
        {
            _instance ??= new Settings(PackageName);
            
            _playModeSetting ??= new UserSetting<StrippingMode>(_instance, nameof(_playModeSetting),
                StrippingMode.PrependWithFolderName, SettingsScope.Project);

            _buildSetting ??= new UserSetting<StrippingMode>(_instance, nameof(_buildSetting),
                StrippingMode.PrependWithFolderName, SettingsScope.Project);

            _capitalizeName ??= new UserSetting<bool>(_instance, nameof(_capitalizeName), true, SettingsScope.Project);
            
            _addSeparatorSymbols ??= new UserSetting<bool>(_instance, nameof(_addSeparatorSymbols), true, SettingsScope.Project);

            _stripFoldersFromPrefabsInPlayMode ??= new UserSetting<bool>(_instance,
                nameof(_stripFoldersFromPrefabsInPlayMode), true, SettingsScope.Project);

            _stripFoldersFromPrefabsInBuild ??= new UserSetting<bool>(_instance,
                nameof(_stripFoldersFromPrefabsInBuild), true, SettingsScope.Project);
        }
    }
}
