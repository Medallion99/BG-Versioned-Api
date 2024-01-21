namespace MyBGList_ApiVersion.DTO.v2
{
    public class RestDTO<T>
    {
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
        public T Item { get; set; }
    }
}
