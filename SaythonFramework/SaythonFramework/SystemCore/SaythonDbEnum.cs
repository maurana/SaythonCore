/// <summary>
/// Saython Database Enums
/// </summary>
namespace Saython.Framework.CRUD
{
    public enum SaythonDbFieldType
    {
        Text = 1,
        NonText = 2
    }

    public enum SaythonDbOperatorType
    {
        Equal = 0,
        NotEqual = 1,
        Like = 2,
        NotLike = 3,
        LessThan = 4,
        GreaterThan = 5,
        LessThanOrEqual = 6,
        GreaterThanOrEqual = 7
    }

    public enum SaythonDbSortDirection
    {
        Asc = 0,
        Desc = 1
    }
}
