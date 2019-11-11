using System;

namespace template.Models.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //Hægt sé að tengja NewsItem við tiltekinn flokk og höfund. Um er að ræða einföld vensl (one-to-many), þ.e. hvert NewsItem getur eingöngu 
        //átt einn höfund og einn flokk. Hins vegar getur hver höfundur komið fyrir á nokkrum bókum og hver margar bækur verið undir hverjum flokki.
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

    }
}