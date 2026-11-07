namespace ReactByCode.Common.Forms;

public interface ISearchCriteria<TCriteria>
{
    static abstract CriteriaBuilder<TCriteria> DefineCriteria();
}
