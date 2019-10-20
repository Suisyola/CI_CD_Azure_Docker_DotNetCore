namespace CI_CD_WebApp.Models
{
    public class Notification
    {
        private DbContext dbContext;

        public int Id { get; set; }

        public string Text { get; set; }

    }
}
