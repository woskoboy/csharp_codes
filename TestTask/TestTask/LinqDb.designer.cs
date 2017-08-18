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
		
		public LinqDbDataContext() : 
				base(global::TestTask.Properties.Settings.Default.PowerConnectionString, mappingSource)
		{OnCreated();}
		
		public LinqDbDataContext(string connection) : 
				base(connection, mappingSource)
		{OnCreated();}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.ParseString_and_FillTempTable")]
		public ISingleResult<ParseString_and_FillTempTableResult> ParseString_and_FillTempTable([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(500)")] string cut_string)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), cut_string);
			return ((ISingleResult<ParseString_and_FillTempTableResult>)(result.ReturnValue));
		}
	}
	
	public partial class ParseString_and_FillTempTableResult
	{
		private System.Nullable<int> _min_;
		private System.Nullable<double> _accum_power;
		public ParseString_and_FillTempTableResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_min_", DbType="Int")]
		public System.Nullable<int> min_
		{
			get{return this._min_;}
			set{ this._min_ = value; }
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_accum_power", DbType="Float")]
		public System.Nullable<double> accum_power
		{
			get{return this._accum_power;}
			set{this._accum_power = value;}
		}
	}
}
