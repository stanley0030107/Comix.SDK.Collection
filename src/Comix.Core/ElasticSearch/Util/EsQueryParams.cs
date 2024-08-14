namespace Comix.Core.ElasticSearch.Util;

public class EsQueryParams
{
    /// <summary>
    /// 查询字段名
    /// </summary>
    public string EsFieldName { get; set; }

    /// <summary>
    /// 查询类型
    /// </summary>
    public EsQueryType QueryType { get; set; }

    private object _value;

    /// <summary>
    /// 值
    /// </summary>
    public object value
    {
        get { return _value; }
        set
        {
            _value = value;

            var dateType = value.GetType();

            var esDataType = EsDataType.String;
            if (dateType == typeof(DateTime))
            {
                esDataType = EsDataType.DateTime;
            }

            if (dateType == typeof(byte) ||
                dateType == typeof(sbyte) ||
                dateType == typeof(short) ||
                dateType == typeof(ushort) ||
                dateType == typeof(int) ||
                dateType == typeof(uint) ||
                dateType == typeof(long) ||
                dateType == typeof(ulong) ||
                dateType == typeof(float) ||
                dateType == typeof(double) ||
                dateType == typeof(decimal) ||
                dateType == typeof(List<byte>) ||
                dateType == typeof(List<sbyte>) ||
                dateType == typeof(List<short>) ||
                dateType == typeof(List<ushort>) ||
                dateType == typeof(List<int>) ||
                dateType == typeof(List<uint>) ||
                dateType == typeof(List<long>) ||
                dateType == typeof(List<ulong>) ||
                dateType == typeof(List<float>) ||
                dateType == typeof(List<double>) ||
                dateType == typeof(List<decimal>))
            {
                esDataType = EsDataType.Num;
            }

            if (dateType == typeof(bool))
            {
                esDataType = EsDataType.Bool;
            }

            if (dateType == typeof(Guid)||
                dateType == typeof(List<Guid>))
            {
                esDataType = EsDataType.Guid;
            }

            DataType = esDataType;
        }
    }

    
    /// <summary>
    /// 数据类型
    /// </summary>
    public EsDataType DataType { get; private set; }

    /// <summary>
    /// 子表查询路径
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// 表别名
    /// </summary>
    public string TableName { get; set; }

    public Dictionary<EsAndOr, IEnumerable<EsQueryParams>>? ChildQueryParams { get; set; }

    public EsQueryParams AddChildParams(EsAndOr andOr, IEnumerable<EsQueryParams> queryParams)
    {
        ChildQueryParams ??= new Dictionary<EsAndOr, IEnumerable<EsQueryParams>>();

        ChildQueryParams.Add(andOr, queryParams);

        return this;
    }


    public static EsQueryParams CreateChildParams(EsAndOr andOr, IEnumerable<EsQueryParams> queryParams)
    {
        var esQueryParams = new EsQueryParams
        {
            ChildQueryParams = new Dictionary<EsAndOr, IEnumerable<EsQueryParams>> { { andOr, queryParams } }
        };

        return esQueryParams;
    }
}