namespace Jst.Core.Application.Dtos
{
    public class BaseDtos<TPrimaryKy>
    {
        TPrimaryKy Id { get; set; }
    }

    public class BaseDtos : BaseDtos<long>
    {

    }
}
