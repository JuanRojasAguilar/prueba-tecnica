using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class add_receipt_overview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW ReceiptOverview AS
            SELECT 
                r.Id AS Id,
                c.Name AS CustomerName,
                r.CreatedOn AS CreatedOn,
                SUM(rd.Quantity * rd.UnitPrice) AS Total
            FROM Receipt r
            INNER JOIN Customer c 
                ON r.CustomerId = c.Id
            INNER JOIN ReceiptDetails rd 
                ON rd.ReceiptId = r.Id 
            GROUP BY r.Id, r.CreatedOn, c.Name
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReceiptOverview");
        }
    }
}
