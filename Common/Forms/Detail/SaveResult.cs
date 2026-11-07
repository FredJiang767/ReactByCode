namespace ReactByCode.Common.Forms;

public sealed class SaveResult
{
    public int? Id { get; set; }
    public Dictionary<string, string> Errors { get; set; } = [];
}
