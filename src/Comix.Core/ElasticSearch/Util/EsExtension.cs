using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Furion.LinqBuilder;

namespace Comix.Core.ElasticSearch.Util;

public static class EsExtension
{
    public static List<Action<QueryDescriptor<T>>> AddRt<T>(this
        List<Action<QueryDescriptor<T>>> must, Action<QueryDescriptor<T>> action)
    {
        must.Add(action);
        return must;
    }

    public static List<Action<QueryDescriptor<T>>> AddIF<T>(this
            List<Action<QueryDescriptor<T>>> must, bool b,
        Action<QueryDescriptor<T>> action)
    {
        if (!b)
        {
            return must;
        }

        must.Add(action);
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="tableName">表别名</param>
    /// <param name="fieldName">字段名</param>
    /// <param name="queryType">查询类型</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public static List<EsQueryParams> AddRt(this List<EsQueryParams> must, 
        string tableName, string fieldName, EsQueryType queryType, object value, string path = null)
    {
        if (value == null)
        {
            return must;
        }
        
        must.Add(new EsQueryParams
        {
            Path = path,
            TableName = tableName,
            EsFieldName = fieldName,
            QueryType = queryType,
            value = value
        });
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="b"></param>
    /// <param name="tableName"></param>
    /// <param name="fieldName"></param>
    /// <param name="queryType"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static List<EsQueryParams> AddIF(this List<EsQueryParams> must, bool b,
        string tableName, string fieldName, EsQueryType queryType, object value, string path = null)
    {
        if (!b)
        {
            return must;
        }

        must.Add(new EsQueryParams
        {
            TableName = tableName,
            EsFieldName = fieldName,
            QueryType = queryType,
            value = value,
            Path = path
        });
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="param">表别名</param>
    /// <returns></returns>
    public static Dictionary<EsAndOr, IEnumerable<EsQueryParams>> AddChild(this Dictionary<EsAndOr, IEnumerable<EsQueryParams>> must,
         EsAndOr andOr, List<EsQueryParams> param)
    {
        must.Add(andOr, param);
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="param">表别名</param>
    /// <returns></returns>
    public static List<EsQueryParams> AddChild(
        this List<EsQueryParams> must,
        EsAndOr andOr, List<EsQueryParams> param)
    {
        must.Add(new EsQueryParams(){ChildQueryParams = new Dictionary<EsAndOr, IEnumerable<EsQueryParams>>().AddChild(andOr, param)});
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="param">表别名</param>
    /// <returns></returns>
    public static List<EsQueryParams> AddChildIF(
        this List<EsQueryParams> must, bool b,
        EsAndOr andOr, List<EsQueryParams> param)
    {
        if (!b)
        {
            return must;
        }
        must.Add(new EsQueryParams()
        {
            ChildQueryParams = new Dictionary<EsAndOr, IEnumerable<EsQueryParams>>()
                .AddChild(andOr, param)
        });
        return must;
    }
    
    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="param">表别名</param>
    /// <returns></returns>
    public static List<EsQueryParams> AddRt(this List<EsQueryParams> must,
            EsQueryParams param)
    {
        must.Add(param);
        return must;
    }

    /// <summary>
    /// 添加查询参数
    /// </summary>
    /// <param name="must"></param>
    /// <param name="b"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static List<EsQueryParams> AddIF(this List<EsQueryParams> must, bool b, EsQueryParams param)
    {
        if (!b)
        {
            return must;
        }

        must.Add(param);
        
        return must;
    }
    
    /// <summary>
    /// 自定义和查询
    /// </summary>
    /// <param name="musts"></param>
    /// <param name="esQueryParams">参数列表</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static List<Action<QueryDescriptor<T>>> CustomQuery<T>(this List<Action<QueryDescriptor<T>>> musts,
        Dictionary<EsAndOr, IEnumerable<EsQueryParams>> esQueryParams)
    {
        if (!esQueryParams.Any())
        {
            return musts;
        }

        musts.AddRange(CustomQuery<T>(esQueryParams));
        
        return musts;
    }

    /// <summary>
    /// 自定义和查询
    /// </summary>
    /// <param name="esQueryParams">参数列表</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static List<Action<QueryDescriptor<T>>> CustomQuery<T>(Dictionary<EsAndOr, IEnumerable<EsQueryParams>> esQueryParams)
    {
        var musts = new List<Action<QueryDescriptor<T>>>();
        if (!esQueryParams.Any())
        {
            return musts;
        }

        musts = esQueryParams.Aggregate(musts, (current, esQueryParam) =>
        {
            return esQueryParam.Key switch
            {
                EsAndOr.And => current.CustomAndQuery(esQueryParam.Value),
                EsAndOr.Or => current.CustomOrQuery(esQueryParam.Value),
                _ => throw new ArgumentOutOfRangeException()
            };
        });

        return musts;
    }
    
    /// <summary>
    /// 自定义和查询
    /// </summary>
    /// <param name="musts"></param>
    /// <param name="esQueryParams">参数列表</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static List<Action<QueryDescriptor<T>>> CustomAndQuery<T>(this List<Action<QueryDescriptor<T>>> musts,
        IEnumerable<EsQueryParams> esQueryParams)
    {
        if (!esQueryParams.Any())
        {
            return musts;
        }

        var actions = esQueryParams.Select(esQueryParam => CustomSingleQuery<T>(esQueryParam)).ToList();
        
        
        if (musts.IsNullOrEmpty())
        {
            musts = new List<Action<QueryDescriptor<T>>>();
        }
        
        musts.AddRange(actions);

        return musts;
    }

    /// <summary>
    /// 自定义或查询
    /// </summary>
    /// <param name="musts"></param>
    /// <param name="esQueryParams">参数列表</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static List<Action<QueryDescriptor<T>>> CustomOrQuery<T>(this List<Action<QueryDescriptor<T>>> musts,
        IEnumerable<EsQueryParams> esQueryParams)
    {
        if (!esQueryParams.Any())
        {
            return musts;
        }

        var actions = esQueryParams.Select(esQueryParam => CustomSingleQuery<T>(esQueryParam));

        musts = musts.AddRt(m => m
            .Bool(b => b
                .Should(actions.ToArray())
            )
        );

        return musts;
    }

    /// <summary>
    /// 自定义查询（单个条件）
    /// </summary>
    /// <param name="musts"></param>
    /// <param name="esQueryParams">参数对象</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static Action<QueryDescriptor<T>> CustomSingleQuery<T>(EsQueryParams esQueryParams)
    {
        if (!esQueryParams.ChildQueryParams.IsNullOrEmpty())
        {
            var childMusts = CustomQuery<T>(esQueryParams.ChildQueryParams);
            return m => m.Bool(b => b.Must(childMusts.ToArray()));
        }

        var action = GetAction<T>(esQueryParams.QueryType,
            esQueryParams.DataType,
            esQueryParams.EsFieldName,
            esQueryParams.value,
            esQueryParams.Path);

        return action;
    }
    
    /// <summary>
    /// 自定义查询（单个条件）
    /// </summary>
    /// <param name="musts"></param>
    /// <param name="queryType">查询类型</param>
    /// <param name="dataType">数据类型</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">值</param>
    /// <param name="path">子表查询路径</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    public static List<Action<QueryDescriptor<T>>> CustomSingleQuery<T>(this List<Action<QueryDescriptor<T>>> musts,
        EsQueryType queryType, EsDataType dataType, string fieldName, object value, string? path = null)
    {
        var action = GetAction<T>(queryType, dataType, fieldName, value, path);
        musts = musts.AddRt(action);
        return musts;
    }

    /// <summary>
    /// 获取查询动作
    /// </summary>
    /// <param name="queryType">查询类型</param>
    /// <param name="dataType">数据类型</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">值</param>
    /// <param name="path">子表查询路径</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static Action<QueryDescriptor<T>> GetAction<T>(EsQueryType queryType, EsDataType dataType, string fieldName,
        object value, string? path = null)
    {
        if (!path.IsNullOrEmpty())
        {
            return m => m.Nested(n => n
                .Path(path)
                .Query(GetAction<T>(queryType, dataType, $"{path}.{fieldName}", value))
            ); 
        }
        
        switch (queryType)
        {
            case EsQueryType.Gt:
            case EsQueryType.Gte:
            case EsQueryType.Lt:
            case EsQueryType.Lte:
                
                return m => m.Range(queryType, dataType, fieldName, value);
                
            case EsQueryType.Like:
            case EsQueryType.NotLike:

                return m => m.LikeOrNot(queryType, dataType, fieldName, value);

            case EsQueryType.In:
            case EsQueryType.NotIn:

                return m => m.InOrNot(queryType, dataType, fieldName, value);

            case EsQueryType.Equals:
            case EsQueryType.NotEquals:

                return m => m.EqualsOrNot(queryType, dataType, fieldName, value);
            
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    /// <summary>
    /// 范围查询
    /// </summary>
    /// <param name="range"></param>
    /// <param name="queryType">查询类型 大于、小于...</param>
    /// <param name="dataType">数据类型 日期类型，数字类型</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">范围边界</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    private static QueryDescriptor<T> Range<T>(this QueryDescriptor<T> range,
        EsQueryType queryType, EsDataType dataType, string fieldName, object value)
    {
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (dataType)
        {
            case EsDataType.DateTime:

                var dateRange = new DateRangeQueryDescriptor<T>(fieldName);

                // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
                dateRange = queryType switch
                {
                    EsQueryType.Gt => dateRange.Gt(value.ToString().ToDateTime()),
                    EsQueryType.Gte => dateRange.Gte(value.ToString().ToDateTime()),
                    EsQueryType.Lt => dateRange.Lt(value.ToString().ToDateTime()),
                    EsQueryType.Lte => dateRange.Lte(value.ToString().ToDateTime()),
                    _ => throw new ArgumentOutOfRangeException(nameof(queryType), queryType,
                        $"rang条件下查询类型不能是{queryType}")
                };

                range.Range(r => r.DateRange(dateRange));

                break;
            case EsDataType.Num:

                var numRange = new NumberRangeQueryDescriptor<T>(fieldName);

                // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
                numRange = queryType switch
                {
                    EsQueryType.Gt => numRange.Gt(value.ToDouble()),
                    EsQueryType.Gte => numRange.Gte(value.ToDouble()),
                    EsQueryType.Lt => numRange.Lt(value.ToDouble()),
                    EsQueryType.Lte => numRange.Lte(value.ToDouble()),
                    _ => throw new ArgumentOutOfRangeException(nameof(queryType), queryType,
                        $"rang条件下查询类型不能是{queryType}")
                };

                range.Range(r => r.NumberRange(numRange));

                break;
            default:
                throw new Exception($"rang条件下数据类型只能是DateTime或者Num，当前{dataType}");
        }

        return range;
    }

    /// <summary>
    /// 模糊查询
    /// </summary>
    /// <param name="match"></param>
    /// <param name="queryType">查询类型 like、not like</param>
    /// <param name="dataType">数据类型 string</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">模糊字符串</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    private static QueryDescriptor<T> LikeOrNot<T>(this QueryDescriptor<T> match,
        EsQueryType queryType, EsDataType dataType, string fieldName, object? value)
    {
        if (value == null)
        {
            return match;
        }

        if (queryType == EsQueryType.NotLike)
        {
            return match.Bool(b => b
                .MustNot(mn => mn
                    .LikeOrNot(EsQueryType.Like, dataType, fieldName, value)
                )
            );
        }
        
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        return dataType switch
        {
            EsDataType.String => match.Wildcard(w => w.Field(fieldName).Value($"*{value}*")),
            _ => throw new Exception($"like条件下数据类型只能是String，当前{dataType}")
        };
    }

    /// <summary>
    /// 包含查询
    /// </summary>
    /// <param name="terms"></param>
    /// <param name="queryType">查询类型 in, not in</param>
    /// <param name="dataType">数据类型 string, num</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">英文逗号分割字符串</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    private static QueryDescriptor<T> InOrNot<T>(this QueryDescriptor<T> terms,
        EsQueryType queryType, EsDataType dataType, string fieldName, object? value)
    {
        if (value == null)
        {
            return terms;
        }

        if (queryType == EsQueryType.NotIn)
        {
            return terms.Bool(b => b
                .MustNot(mn => mn
                    .InOrNot(EsQueryType.In, dataType, fieldName, value)
                )
            );
        }

        FieldValue[] fieldValue = null;
        switch (dataType)
        {
            case EsDataType.Num:

                Type elementType = value.GetType();

                if (elementType == typeof(List<int>) || elementType == typeof(int[]) || elementType == typeof(IEnumerable<int>))
                {
                    fieldValue = ((IEnumerable<int>)value).Select(x => FieldValue.Double(x)).ToArray();
                }
                else if (elementType == typeof(List<float>) || elementType == typeof(float[]) || elementType == typeof(IEnumerable<float>))
                {
                    fieldValue = ((IEnumerable<float>)value).Select(x => FieldValue.Double(x)).ToArray();
                }
                else if (elementType == typeof(List<double>) || elementType == typeof(double[]) || elementType == typeof(IEnumerable<double>))
                {
                    fieldValue = ((IEnumerable<double>)value).Select(x => FieldValue.Double(x)).ToArray();
                }
                else if (elementType == typeof(List<decimal>) || elementType == typeof(decimal[]) || elementType == typeof(IEnumerable<decimal>))
                {
                    fieldValue = ((IEnumerable<decimal>)value).Select(x => FieldValue.Double((double)x)).ToArray();
                }
                
                break;
            case EsDataType.String:
                fieldValue = ((List<string>)value).Select(FieldValue.String).ToArray();
                break;
            case EsDataType.Guid:
                fieldValue = ((List<Guid>)value).Select(o => FieldValue.String(o.ToString())).ToArray();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
        }
        
        terms.Terms(ts => ts.Field(fieldName).Terms(new TermsQueryField(fieldValue)));

        return terms;
    }

    /// <summary>
    /// 等值查询
    /// </summary>
    /// <param name="term"></param>
    /// <param name="queryType">查询类型 Equals, not Equals</param>
    /// <param name="dataType">数据类型</param>
    /// <param name="fieldName">字段名称</param>
    /// <param name="value">等值</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="Exception"></exception>
    private static QueryDescriptor<T> EqualsOrNot<T>(this QueryDescriptor<T> term,
        EsQueryType queryType, EsDataType dataType, string fieldName, object? value)
    {
        if (value == null)
        {
            return term;
        }

        if (queryType == EsQueryType.NotEquals)
        {
            return term.Bool(b => b
                .MustNot(mn => mn
                    .EqualsOrNot(EsQueryType.Equals, dataType, fieldName, value)
                )
            );
        }
        
        switch (dataType)
        {
            case EsDataType.DateTime:
                // term.Range(r => r
                //     .DateRange(d => d
                //         .Field(fieldName)
                //         .From(value.ToString().ToDateTime())
                //         .To(value.ToString().ToDateTime())
                //     )
                // );
                var time = value.ToString().ToDateTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                
                term.Term(t => t.Field(fieldName).Value(time));
                
                return term;
            case EsDataType.Num:
                term.Term(t => t.Field(fieldName).Value(value.ToInt()));
               
                return term;
            case EsDataType.String:
            case EsDataType.Guid:
                if (value == null)
                {
                    term.Term(t => t.Field(fieldName).Value(FieldValue.Null));
                }
                else
                {
                    term.Term(t => t.Field(fieldName).Value(value.ToString()));
                }

                return term;
            case EsDataType.Bool:
                term.Term(t => t.Field(fieldName).Value(FieldValue.Boolean((bool)value)));
               
                return term;
            default:
                throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
        }
    }
}