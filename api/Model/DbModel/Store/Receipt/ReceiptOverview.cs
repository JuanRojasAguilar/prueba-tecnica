namespace api.Model.DbModel.Store.Receipt;
public class ReceiptOverview
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Total { get; set; }
}
