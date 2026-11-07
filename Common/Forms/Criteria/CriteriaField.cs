namespace ReactByCode.Common.Forms;

public sealed record CriteriaField(string Key, string Label, string Type, List<CriteriaOption>? Options);
