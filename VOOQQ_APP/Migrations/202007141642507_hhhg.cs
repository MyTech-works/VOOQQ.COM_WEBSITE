namespace VOOQQ_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhhg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RazorPayPaymentDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecordId = c.Long(nullable: false),
                        PaymentType = c.String(maxLength: 25),
                        PaymentId = c.String(maxLength: 75),
                        Entity = c.String(maxLength: 25),
                        Amount = c.Double(nullable: false),
                        Currency = c.String(maxLength: 10),
                        Status = c.String(maxLength: 15),
                        OrderId = c.String(maxLength: 75),
                        InvoiceId = c.String(maxLength: 75),
                        International = c.Boolean(),
                        Method = c.String(maxLength: 35),
                        AmountRefunded = c.Double(),
                        RefundStatus = c.String(maxLength: 25),
                        Captured = c.String(maxLength: 25),
                        Description = c.String(maxLength: 250),
                        CardId = c.String(maxLength: 35),
                        Bank = c.String(maxLength: 55),
                        Wallet = c.String(maxLength: 35),
                        Vpa = c.String(maxLength: 35),
                        Email = c.String(maxLength: 35),
                        Contact = c.String(maxLength: 25),
                        MerchantOrderId = c.String(maxLength: 45),
                        Fee = c.Decimal(precision: 18, scale: 2),
                        ServiceTax = c.Decimal(precision: 18, scale: 2),
                        PaymentDate = c.DateTime(),
                        RefundId = c.String(maxLength: 50),
                        RefundDate = c.DateTime(),
                        RazorpayOrderId = c.String(maxLength: 50),
                        Signature = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RazorPayPaymentDetails");
        }
    }
}
