namespace EF4.Model
{
    public class Books
    {
        public int Id {  set; get; }
        public String Name { set; get; }
        public int Price { set; get; }
        public String Publisher { set; get; }
        public int AuthorId { set; get; }
    }
}
