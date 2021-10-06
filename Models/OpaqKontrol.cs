namespace ODMSinavYazilimi.Models
{
    public class OpaqKontrol
    {
        public int OpaqId { get; set; }
        public int Oturum { get; set; }

        public OpaqKontrol()
        {
        }
        public OpaqKontrol(int opaqId, int oturum)
        {
            OpaqId = opaqId;
            Oturum = oturum;
        }
    }
}