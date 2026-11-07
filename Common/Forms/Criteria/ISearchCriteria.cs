namespace ReactByCode.Common.Forms;

// A search criteria class declares its form through one static DefineCriteria method.
// Its properties are bound from the query string of the search endpoint.
public interface ISearchCriteria<TCriteria>
{
    static abstract CriteriaBuilder<TCriteria> DefineCriteria();
}
