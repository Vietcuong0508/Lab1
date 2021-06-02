using System;
using System.Text;

namespace SpringHeroBank.Entity
{
    public class Transaction
    {
        // id tự sinh khi thực hiên giao dich
        public int Id { get; set; }

        // số tiền giao dịch
        public double Amount { get; set; }

        // để tìm kiếm trong database
        public string Code { get; set; }

        // mã người gửi
        public string SenderCode { get; set; }

        // mã người nhận
        public string ReceiverCode { get; set; }

        // loại giao dịch // 1 rút tiền // 2 nạp tiền // 3 chuyển tiền
        public int Type { get; set; }

        // thông báo tự sinh
        public string Message { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }

        public void ToString()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string tranTXT = "";
            if (this.Type == 1)
            {
                tranTXT = "Withdraw";
            }
            else if (this.Type == 2)
            {
                tranTXT = "Cash";
            }
            else if (this.Type == 3)
            {
                tranTXT = "Transfer";
            }

            Console.WriteLine($"|| Trading code : {Id} \t transaction money: ${Amount} \t doer : {SenderCode} \t recipient : {ReceiverCode} \t the kind of transaction : {tranTXT}\n" +
                              $"|| Message : {Message} \t create at : {CreateAt} \t update at : {UpdateAt}" +
                              $"\n|| --------------------------------------------------------------------------------------------------------------------------------------------------------------||\n");
        }
    }
}