namespace CQRSDEMO.CQRS.Queries
{
    public class QueryBase<TQueryResult, TQueryResultData> : Query<TQueryResult, TQueryResultData>
        where TQueryResult : QueryResult<TQueryResultData>
    {

    }
}
