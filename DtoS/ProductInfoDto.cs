namespace LarekApi.DtoS
{
    public record ProductInfoDto
    {
      public  string Name { get; init; }
      public int Price { get; init; }
      public  string Description { get; init; }

    }
}
