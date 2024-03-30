namespace YongqingWork.ViewModels
{
    /// <summary>
    /// 取得顧客訂單用ViewModel
    /// </summary>
    public class CustomerOrderViewModel
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public short Quantity { get; set; }

    }
}
