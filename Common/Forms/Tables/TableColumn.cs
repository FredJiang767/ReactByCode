namespace ReactByCode.Common.Forms;

// One column of a table. Key is the camelCase row property; Format is the lowercase ColumnFormat name.
public sealed record TableColumn(string Key, string Title, string Format);
