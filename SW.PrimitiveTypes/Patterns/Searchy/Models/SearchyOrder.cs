using System;

namespace SW.PrimitiveTypes
{

    public class SearchyOrder
    {
        public enum Order
        {
            ASC = 1,
            DEC = 2
        }

        public string MemberName { get; set; }

        public Order SortOrder { get; set; }

        public SearchyOrder()
        {
        }

        public SearchyOrder(string memberName, Order sortOrder)
        {
            MemberName = memberName;
            SortOrder = sortOrder;
        }


    }
}
