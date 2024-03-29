﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("CST.Security.Data", "FK_GROUP_APP", "FG_APP", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CST.Security.Data.App), "FG_GROUP", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CST.Security.Data.Group), true)]
[assembly: EdmRelationshipAttribute("CST.Security.Data", "FG_GROUP_USER", "FG_GROUP", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CST.Security.Data.Group), "FG_USER", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CST.Security.Data.User))]

#endregion

namespace CST.Security.Data
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SecurityEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SecurityEntities object using the connection string found in the 'SecurityEntities' section of the application configuration file.
        /// </summary>
        public SecurityEntities() : base("name=SecurityEntities", "SecurityEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SecurityEntities object.
        /// </summary>
        public SecurityEntities(string connectionString) : base(connectionString, "SecurityEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SecurityEntities object.
        /// </summary>
        public SecurityEntities(EntityConnection connection) : base(connection, "SecurityEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<App> Apps
        {
            get
            {
                if ((_Apps == null))
                {
                    _Apps = base.CreateObjectSet<App>("Apps");
                }
                return _Apps;
            }
        }
        private ObjectSet<App> _Apps;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Group> Groups
        {
            get
            {
                if ((_Groups == null))
                {
                    _Groups = base.CreateObjectSet<Group>("Groups");
                }
                return _Groups;
            }
        }
        private ObjectSet<Group> _Groups;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Apps EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToApps(App app)
        {
            base.AddObject("Apps", app);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Groups EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToGroups(Group group)
        {
            base.AddObject("Groups", group);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion
        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="v_PLAIN_TEXT">No Metadata Documentation available.</param>
        /// <param name="v_CRYPT_TEXT">No Metadata Documentation available.</param>
        public int GetEncryptText(global::System.String v_PLAIN_TEXT, ObjectParameter v_CRYPT_TEXT)
        {
            ObjectParameter v_PLAIN_TEXTParameter;
            if (v_PLAIN_TEXT != null)
            {
                v_PLAIN_TEXTParameter = new ObjectParameter("V_PLAIN_TEXT", v_PLAIN_TEXT);
            }
            else
            {
                v_PLAIN_TEXTParameter = new ObjectParameter("V_PLAIN_TEXT", typeof(global::System.String));
            }
    
            return base.ExecuteFunction("GetEncryptText", v_PLAIN_TEXTParameter, v_CRYPT_TEXT);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="v_CRYPT_TEXT">No Metadata Documentation available.</param>
        /// <param name="v_PLAIN_TEXT">No Metadata Documentation available.</param>
        public int GetDecryptText(global::System.String v_CRYPT_TEXT, ObjectParameter v_PLAIN_TEXT)
        {
            ObjectParameter v_CRYPT_TEXTParameter;
            if (v_CRYPT_TEXT != null)
            {
                v_CRYPT_TEXTParameter = new ObjectParameter("V_CRYPT_TEXT", v_CRYPT_TEXT);
            }
            else
            {
                v_CRYPT_TEXTParameter = new ObjectParameter("V_CRYPT_TEXT", typeof(global::System.String));
            }
    
            return base.ExecuteFunction("GetDecryptText", v_CRYPT_TEXTParameter, v_PLAIN_TEXT);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CST.Security.Data", Name="App")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class App : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new App object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="code">Initial value of the Code property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="activeFlag">Initial value of the ActiveFlag property.</param>
        /// <param name="sysAdminFlag">Initial value of the SysAdminFlag property.</param>
        public static App CreateApp(global::System.Decimal id, global::System.String code, global::System.String name, global::System.String activeFlag, global::System.String sysAdminFlag)
        {
            App app = new App();
            app.ID = id;
            app.Code = code;
            app.Name = name;
            app.ActiveFlag = activeFlag;
            app.SysAdminFlag = sysAdminFlag;
            return app;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Decimal _ID;
        partial void OnIDChanging(global::System.Decimal value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                OnCodeChanging(value);
                ReportPropertyChanging("Code");
                _Code = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Code");
                OnCodeChanged();
            }
        }
        private global::System.String _Code;
        partial void OnCodeChanging(global::System.String value);
        partial void OnCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ActiveFlag
        {
            get
            {
                return _ActiveFlag;
            }
            set
            {
                OnActiveFlagChanging(value);
                ReportPropertyChanging("ActiveFlag");
                _ActiveFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ActiveFlag");
                OnActiveFlagChanged();
            }
        }
        private global::System.String _ActiveFlag;
        partial void OnActiveFlagChanging(global::System.String value);
        partial void OnActiveFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String SysAdminFlag
        {
            get
            {
                return _SysAdminFlag;
            }
            set
            {
                OnSysAdminFlagChanging(value);
                ReportPropertyChanging("SysAdminFlag");
                _SysAdminFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("SysAdminFlag");
                OnSysAdminFlagChanged();
            }
        }
        private global::System.String _SysAdminFlag;
        partial void OnSysAdminFlagChanging(global::System.String value);
        partial void OnSysAdminFlagChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CST.Security.Data", "FK_GROUP_APP", "FG_GROUP")]
        public EntityCollection<Group> Groups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Group>("CST.Security.Data.FK_GROUP_APP", "FG_GROUP");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Group>("CST.Security.Data.FK_GROUP_APP", "FG_GROUP", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CST.Security.Data", Name="Group")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Group : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Group object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="code">Initial value of the Code property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="appID">Initial value of the AppID property.</param>
        /// <param name="activeFlag">Initial value of the ActiveFlag property.</param>
        /// <param name="appAdminFlag">Initial value of the AppAdminFlag property.</param>
        public static Group CreateGroup(global::System.Decimal id, global::System.String code, global::System.String name, global::System.Decimal appID, global::System.String activeFlag, global::System.String appAdminFlag)
        {
            Group group = new Group();
            group.ID = id;
            group.Code = code;
            group.Name = name;
            group.AppID = appID;
            group.ActiveFlag = activeFlag;
            group.AppAdminFlag = appAdminFlag;
            return group;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Decimal _ID;
        partial void OnIDChanging(global::System.Decimal value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                OnCodeChanging(value);
                ReportPropertyChanging("Code");
                _Code = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Code");
                OnCodeChanged();
            }
        }
        private global::System.String _Code;
        partial void OnCodeChanging(global::System.String value);
        partial void OnCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal AppID
        {
            get
            {
                return _AppID;
            }
            set
            {
                OnAppIDChanging(value);
                ReportPropertyChanging("AppID");
                _AppID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AppID");
                OnAppIDChanged();
            }
        }
        private global::System.Decimal _AppID;
        partial void OnAppIDChanging(global::System.Decimal value);
        partial void OnAppIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ActiveFlag
        {
            get
            {
                return _ActiveFlag;
            }
            set
            {
                OnActiveFlagChanging(value);
                ReportPropertyChanging("ActiveFlag");
                _ActiveFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ActiveFlag");
                OnActiveFlagChanged();
            }
        }
        private global::System.String _ActiveFlag;
        partial void OnActiveFlagChanging(global::System.String value);
        partial void OnActiveFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AppAdminFlag
        {
            get
            {
                return _AppAdminFlag;
            }
            set
            {
                OnAppAdminFlagChanging(value);
                ReportPropertyChanging("AppAdminFlag");
                _AppAdminFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AppAdminFlag");
                OnAppAdminFlagChanged();
            }
        }
        private global::System.String _AppAdminFlag;
        partial void OnAppAdminFlagChanging(global::System.String value);
        partial void OnAppAdminFlagChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CST.Security.Data", "FK_GROUP_APP", "FG_APP")]
        public App App
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<App>("CST.Security.Data.FK_GROUP_APP", "FG_APP").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<App>("CST.Security.Data.FK_GROUP_APP", "FG_APP").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<App> AppReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<App>("CST.Security.Data.FK_GROUP_APP", "FG_APP");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<App>("CST.Security.Data.FK_GROUP_APP", "FG_APP", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CST.Security.Data", "FG_GROUP_USER", "FG_USER")]
        public EntityCollection<User> Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<User>("CST.Security.Data.FG_GROUP_USER", "FG_USER");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<User>("CST.Security.Data.FG_GROUP_USER", "FG_USER", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="CST.Security.Data", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="login">Initial value of the Login property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="activeFlag">Initial value of the ActiveFlag property.</param>
        /// <param name="alterPasswordFlag">Initial value of the AlterPasswordFlag property.</param>
        public static User CreateUser(global::System.Decimal id, global::System.String login, global::System.String lastName, global::System.String firstName, global::System.String password, global::System.String activeFlag, global::System.String alterPasswordFlag)
        {
            User user = new User();
            user.ID = id;
            user.Login = login;
            user.LastName = lastName;
            user.FirstName = firstName;
            user.Password = password;
            user.ActiveFlag = activeFlag;
            user.AlterPasswordFlag = alterPasswordFlag;
            return user;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Decimal _ID;
        partial void OnIDChanging(global::System.Decimal value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Login
        {
            get
            {
                return _Login;
            }
            set
            {
                OnLoginChanging(value);
                ReportPropertyChanging("Login");
                _Login = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Login");
                OnLoginChanged();
            }
        }
        private global::System.String _Login;
        partial void OnLoginChanging(global::System.String value);
        partial void OnLoginChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EMail
        {
            get
            {
                return _EMail;
            }
            set
            {
                OnEMailChanging(value);
                ReportPropertyChanging("EMail");
                _EMail = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EMail");
                OnEMailChanged();
            }
        }
        private global::System.String _EMail;
        partial void OnEMailChanging(global::System.String value);
        partial void OnEMailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                OnPhoneChanging(value);
                ReportPropertyChanging("Phone");
                _Phone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Phone");
                OnPhoneChanged();
            }
        }
        private global::System.String _Phone;
        partial void OnPhoneChanging(global::System.String value);
        partial void OnPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ActiveFlag
        {
            get
            {
                return _ActiveFlag;
            }
            set
            {
                OnActiveFlagChanging(value);
                ReportPropertyChanging("ActiveFlag");
                _ActiveFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ActiveFlag");
                OnActiveFlagChanged();
            }
        }
        private global::System.String _ActiveFlag;
        partial void OnActiveFlagChanging(global::System.String value);
        partial void OnActiveFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AlterPasswordFlag
        {
            get
            {
                return _AlterPasswordFlag;
            }
            set
            {
                OnAlterPasswordFlagChanging(value);
                ReportPropertyChanging("AlterPasswordFlag");
                _AlterPasswordFlag = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AlterPasswordFlag");
                OnAlterPasswordFlagChanged();
            }
        }
        private global::System.String _AlterPasswordFlag;
        partial void OnAlterPasswordFlagChanging(global::System.String value);
        partial void OnAlterPasswordFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                OnCultureChanging(value);
                ReportPropertyChanging("Culture");
                _Culture = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Culture");
                OnCultureChanged();
            }
        }
        private global::System.String _Culture;
        partial void OnCultureChanging(global::System.String value);
        partial void OnCultureChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("CST.Security.Data", "FG_GROUP_USER", "FG_GROUP")]
        public EntityCollection<Group> Groups
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Group>("CST.Security.Data.FG_GROUP_USER", "FG_GROUP");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Group>("CST.Security.Data.FG_GROUP_USER", "FG_GROUP", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
