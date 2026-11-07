namespace ReactByCode.Common.Forms;

// The serialized search form definition sent to the browser.
public sealed class CriteriaMetadata
{
    public List<CriteriaField> Fields { get; init; } = [];
}
