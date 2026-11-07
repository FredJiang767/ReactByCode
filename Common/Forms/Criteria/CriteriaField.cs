namespace ReactByCode.Common.Forms;

// One input of a search form. Type is "text", "date" or "select".
public sealed record CriteriaField(string Key, string Label, string Type, List<CriteriaOption>? Options);
