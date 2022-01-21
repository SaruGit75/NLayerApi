namespace NLayerApi.Core.Models
{
    public abstract class BaseEntity    //new ile olusturulamasin diye abstract keyi kullanildi.
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
