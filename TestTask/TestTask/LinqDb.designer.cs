#pragma warning disable 1591
namespace TestTask
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Reflection;


    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Power")]
	public partial class LinqDbDataContext : System.Data.Linq.DataContext
	{
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
    #region Определения метода расширяемости
    partial void OnCreated();
    #endregion
	
		public LinqDbDataContext(string connection) : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.ReqProc")]
		public ISingleResult<ReqProcResult> ReqProc([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<ReqProcResult>)(result.ReturnValue));
		}
	}
	

	public partial class ReqProcResult
	{
		private System.Nullable<System.DateTime> _MeasureTime;
		private string _DeviceCode;
		private System.Nullable<double> _P;
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MeasureTime", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> MeasureTime
		{
            get {return this._MeasureTime;}
			set{this._MeasureTime = value;}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeviceCode", DbType="VarChar(14)")]
		public string DeviceCode
		{
            get {return this._DeviceCode;}
			set{this._DeviceCode = value;}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_P", DbType="Float")]
		public System.Nullable<double> P
		{
			get{return this._P;}
			set{this._P = value;}
		}
	}
}
#pragma warning restore 1591
