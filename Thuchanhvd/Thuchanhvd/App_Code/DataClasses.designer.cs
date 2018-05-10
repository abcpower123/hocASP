﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Sample")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertHangHoa(HangHoa instance);
  partial void UpdateHangHoa(HangHoa instance);
  partial void DeleteHangHoa(HangHoa instance);
  partial void InsertTheLoai(TheLoai instance);
  partial void UpdateTheLoai(TheLoai instance);
  partial void DeleteTheLoai(TheLoai instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SampleConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<HangHoa> HangHoas
	{
		get
		{
			return this.GetTable<HangHoa>();
		}
	}
	
	public System.Data.Linq.Table<TheLoai> TheLoais
	{
		get
		{
			return this.GetTable<TheLoai>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HangHoa")]
public partial class HangHoa : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _ten;
	
	private System.Nullable<int> _maTheLoai;
	
	private EntityRef<TheLoai> _TheLoai;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OntenChanging(string value);
    partial void OntenChanged();
    partial void OnmaTheLoaiChanging(System.Nullable<int> value);
    partial void OnmaTheLoaiChanged();
    #endregion
	
	public HangHoa()
	{
		this._TheLoai = default(EntityRef<TheLoai>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ten", DbType="NVarChar(50)")]
	public string ten
	{
		get
		{
			return this._ten;
		}
		set
		{
			if ((this._ten != value))
			{
				this.OntenChanging(value);
				this.SendPropertyChanging();
				this._ten = value;
				this.SendPropertyChanged("ten");
				this.OntenChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maTheLoai", DbType="Int")]
	public System.Nullable<int> maTheLoai
	{
		get
		{
			return this._maTheLoai;
		}
		set
		{
			if ((this._maTheLoai != value))
			{
				if (this._TheLoai.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnmaTheLoaiChanging(value);
				this.SendPropertyChanging();
				this._maTheLoai = value;
				this.SendPropertyChanged("maTheLoai");
				this.OnmaTheLoaiChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TheLoai_HangHoa", Storage="_TheLoai", ThisKey="maTheLoai", OtherKey="maTheLoai", IsForeignKey=true)]
	public TheLoai TheLoai
	{
		get
		{
			return this._TheLoai.Entity;
		}
		set
		{
			TheLoai previousValue = this._TheLoai.Entity;
			if (((previousValue != value) 
						|| (this._TheLoai.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._TheLoai.Entity = null;
					previousValue.HangHoas.Remove(this);
				}
				this._TheLoai.Entity = value;
				if ((value != null))
				{
					value.HangHoas.Add(this);
					this._maTheLoai = value.maTheLoai;
				}
				else
				{
					this._maTheLoai = default(Nullable<int>);
				}
				this.SendPropertyChanged("TheLoai");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TheLoai")]
public partial class TheLoai : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _maTheLoai;
	
	private string _tenTheLoai;
	
	private EntitySet<HangHoa> _HangHoas;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaTheLoaiChanging(int value);
    partial void OnmaTheLoaiChanged();
    partial void OntenTheLoaiChanging(string value);
    partial void OntenTheLoaiChanged();
    #endregion
	
	public TheLoai()
	{
		this._HangHoas = new EntitySet<HangHoa>(new Action<HangHoa>(this.attach_HangHoas), new Action<HangHoa>(this.detach_HangHoas));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maTheLoai", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int maTheLoai
	{
		get
		{
			return this._maTheLoai;
		}
		set
		{
			if ((this._maTheLoai != value))
			{
				this.OnmaTheLoaiChanging(value);
				this.SendPropertyChanging();
				this._maTheLoai = value;
				this.SendPropertyChanged("maTheLoai");
				this.OnmaTheLoaiChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenTheLoai", DbType="NVarChar(50)")]
	public string tenTheLoai
	{
		get
		{
			return this._tenTheLoai;
		}
		set
		{
			if ((this._tenTheLoai != value))
			{
				this.OntenTheLoaiChanging(value);
				this.SendPropertyChanging();
				this._tenTheLoai = value;
				this.SendPropertyChanged("tenTheLoai");
				this.OntenTheLoaiChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TheLoai_HangHoa", Storage="_HangHoas", ThisKey="maTheLoai", OtherKey="maTheLoai")]
	public EntitySet<HangHoa> HangHoas
	{
		get
		{
			return this._HangHoas;
		}
		set
		{
			this._HangHoas.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_HangHoas(HangHoa entity)
	{
		this.SendPropertyChanging();
		entity.TheLoai = this;
	}
	
	private void detach_HangHoas(HangHoa entity)
	{
		this.SendPropertyChanging();
		entity.TheLoai = null;
	}
}
#pragma warning restore 1591
