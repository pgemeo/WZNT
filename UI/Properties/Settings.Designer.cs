﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Elements>
	<GruArtAufEinzelnutzen>
		<DataGridViewColumns>
			<DataGridViewColumn>
				<HeaderText>Id</HeaderText>
				<DataPropertyName>Id</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
			<DataGridViewColumn>
				<HeaderText>Aufgabe</HeaderText>
				<DataPropertyName>Aufgabe</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
		</DataGridViewColumns>
	</GruArtAufEinzelnutzen>
	<GruArtAufEinSprache>
		<DataGridViewColumns>
			<DataGridViewColumn>
				<HeaderText>Id</HeaderText>
				<DataPropertyName>Id</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
			<DataGridViewColumn>
				<HeaderText>IdSprache</HeaderText>
				<DataPropertyName>IdSprache</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
			<DataGridViewColumn>
				<HeaderText>IdAufgabe</HeaderText>
				<DataPropertyName>IdAufgabe</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
			<DataGridViewColumn>
				<HeaderText>Uebersetzung</HeaderText>
				<DataPropertyName>Uebersetzung</DataPropertyName>
				<Visible>true</Visible>
			</DataGridViewColumn>
		</DataGridViewColumns>
	</GruArtAufEinSprache>
</Elements>")]
        public string DataGridViewColumns {
            get {
                return ((string)(this["DataGridViewColumns"]));
            }
            set {
                this["DataGridViewColumns"] = value;
            }
        }
    }
}
