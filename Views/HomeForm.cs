using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMallManagerMVC
{
    public partial class HomeForm : Form, ICreateReadUpdateDelete
    {
        private AcctionType _acctionType;
        private AcctionTypeCustomer _acctionTypeCustomer;
        private AcctionTypeDiscount _acctionTypeDiscount;
        private AcctionTypeBillDetail _actionTypeBillDetail;
        // Controller
        public Filter FilterObject { set; get; }
        public CommonController CommonObject { set; get; }
        public BillController BillController { set; get; }
        public IOController IOControllerObject { set; get; }
        public UpdateAutoId UpdateAutoIdObject { set; get; }
        public StatisController StatisControllerObject { set; get; }
        // Model:
        // Items
        public List<Items> ListItems { get; set; }
        public List<Items> ListItemsSearchResult { get; set; }
        // Customers
        public List<Customers> ListCustomers { get; set; }
        public List<Customers> ListCustomersSearchResult { get; set; }
        //Discount
        public List<Discounts> ListDiscounts { get; set; }
        public List<Discounts> ListDiscountsSearchResult { get; set; }
        //Bill Details
        public List<BillDetails> ListsBillDetails { get; set; }
        public List<BillDetails> ListsBillDetailsSearchResult { get; set; }
        public HomeForm()
        {
            InitializeComponent();
            CenterToScreen();
            //Controller
            FilterObject = new Filter();
            CommonObject = new CommonController();
            BillController = new BillController();
            IOControllerObject = new IOController();
            UpdateAutoIdObject = new UpdateAutoId();
            StatisControllerObject = new StatisController();
            //Model:
            //Items
            ListItems = new List<Items>();
            ListItemsSearchResult = new List<Items>();
            //Customers
            ListCustomers = new List<Customers>();
            ListCustomersSearchResult = new List<Customers>();
            //Discounts
            ListDiscounts = new List<Discounts>();
            ListDiscountsSearchResult = new List<Discounts>();
            //Bill Details
            ListsBillDetails = new List<BillDetails>();
            ListsBillDetailsSearchResult = new List<BillDetails>();

            // Khởi trạng thái -> Normal
            _acctionType = AcctionType.NORMAL;
            _acctionTypeCustomer = AcctionTypeCustomer.NORMAL;
            _acctionTypeDiscount = AcctionTypeDiscount.NORMAL;
            _actionTypeBillDetail = AcctionTypeBillDetail.NORMAL;

        }

        //Method: Add Columns Data Grid View
        public void AddColumnsDataGridView(string[] name, string[] headText, DataGridView dataGridView)
        {
            DataGridViewCellStyle boldHeaderStyle = new DataGridViewCellStyle();
            boldHeaderStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);

            for (int i = 0; i < headText.Length; i++)
            {
                if (headText[i] == "Delete" || headText[i] == "Update" || headText[i] == "Select" || headText[i] == "Detail Bill")
                {
                    DataGridViewButtonColumn btnColumnCell = new DataGridViewButtonColumn();
                    btnColumnCell.HeaderText = headText[i];
                    btnColumnCell.Text = headText[i];
                    btnColumnCell.Name = name[i];
                    btnColumnCell.UseColumnTextForButtonValue = true;
                    btnColumnCell.HeaderCell.Style = boldHeaderStyle;
                    btnColumnCell.Visible = true;
                    btnColumnCell.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView.DefaultCellStyle = btnColumnCell.DefaultCellStyle;
                    // Method Add -> Của DataGridViewButtonColumn -> Add 1 index
                    dataGridView.Columns.Add(btnColumnCell);
                }
                else
                {
                    DataGridViewTextBoxColumn textBoxCell = new DataGridViewTextBoxColumn();
                    textBoxCell.Name = name[i];
                    textBoxCell.HeaderText = headText[i];
                    textBoxCell.HeaderCell.Style = boldHeaderStyle;
                    textBoxCell.Visible = true;
                    textBoxCell.SortMode = DataGridViewColumnSortMode.NotSortable;
                    // Method Add -> Của DataGridViewBoxColumn -> Add 1 index
                    dataGridView.Columns.Add(textBoxCell);
                }
            }
        }

        //Method: Select All Item
        public void SelectAllItems<T>(List<T> items)
        {
            if (items.GetType() == typeof(List<Items>))
            {
                if (items.Count <= 0)
                {
                    MessageBox.Show("There are no Item in the list Items!", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewMagItems.Rows.Clear();
                    // Operater -> Ep kieu Generic voi toan tu as
                    List<Items> newListItems = items as List<Items>;
                    foreach (Items item in newListItems)
                    {
                        dataGridViewMagItems.Rows.Add(item.ObjectToArray());
                    }
                }
            }
            else if (items.GetType() == typeof(List<Customers>))
            {
                if (items.Count <= 0)
                {
                    MessageBox.Show("There are no Customer in the list Customers!", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewMagCustomers.Rows.Clear();
                    // Operater -> Ep kieu Generic voi toan tu as
                    List<Customers> newCustomers = items as List<Customers>;
                    foreach (Customers customer in newCustomers)
                    {
                        dataGridViewMagCustomers.Rows.Add(customer.ObjectCustomerToArray());
                    }
                }
            }
            else if (items.GetType() == typeof(List<Discounts>))
            {
                if (items.Count <= 0)
                {
                    MessageBox.Show("There are no Discount in the list Discounts!", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewMagDiscounts.Rows.Clear();
                    // Operater -> Ep kieu Generic voi toan tu as
                    List<Discounts> newDiscounts = items as List<Discounts>;
                    foreach (Discounts discount in newDiscounts)
                    {
                        dataGridViewMagDiscounts.Rows.Add(discount.ObjectDiscountToArray());
                    }
                }
            }
            else if (items.GetType() == typeof(List<BillDetails>))
            {
                if (items.Count <= 0)
                {
                    MessageBox.Show("There are no Bills in the list BillDetails!", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewMagBill.Rows.Clear();
                    // Operater -> Ep kieu Generic voi toan tu as
                    List<BillDetails> billDetails = items as List<BillDetails>;
                    foreach (BillDetails billDetail in billDetails)
                    {
                        dataGridViewMagBill.Rows.Add(billDetail.ObjectToArray());
                    }
                }
            }
        }
        // --> Items
        //Method: Create Item 1 -> Save List and dataGridView
        public void CreateItems<T>(T item)
        {
            if (item.GetType() == typeof(Items))
            {
                if (dataGridViewMagItems.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Item", "Name Item", "Type Item", "Quantity", "Brand", "Release Date"
                                                    ,"Price", "Discount","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdItem", "colFullNameItem", "colTypeItem", "colQuantityItem", "colBrandItem", "colReleaseDateItem"
                                                    ,"colPriceItem", "colDiscountItem","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagItems);
                }
                // Operater -> Ep kieu Generic voi toan tu as
                Items newItem = item as Items;
                ListItems.Add(newItem);
                SelectAllItems<Items>(ListItems);
            }
            else if (item.GetType() == typeof(Customers))
            {
                if (dataGridViewMagCustomers.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Customer", "Full Name", "Birth Date", "Address", "Phone Number", "Email"
                                                    ,"Type Customer", "Point","Create Time Account","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdCustomer", "colFullNameCustomer", "colBirthDateCustomer", "colAddressCustomer", "colPhoneNumberCustomer"
                                                    ,"colEmailCustomer","colTypeCustomer","colPointCustomer", "colCreateTimeAccountCustomer","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagCustomers);
                }
                // Operater -> Ep kieu Generic voi toan tu as
                Customers newCustomer = item as Customers;
                ListCustomers.Add(newCustomer);
                SelectAllItems<Customers>(ListCustomers);
            }
            else if (item.GetType() == typeof(Discounts))
            {
                if (dataGridViewMagDiscounts.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Discount", "Name Discount", "Time Start", "Time End", "Type Discount", "Percent Discount"
                                                    ,"Value Discount","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdDiscount", "colFullNameDiscount", "colTimeStartDiscount", "colTimeEndDiscount", "colTypeDiscount"
                                                    ,"colPercentDiscount","colValueDiscount","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagDiscounts);
                }
                // Operater -> Ep kieu Generic voi toan tu as
                Discounts newDiscount = item as Discounts;
                ListDiscounts.Add(newDiscount);
                SelectAllItems<Discounts>(ListDiscounts);
            }
            else if (item.GetType() == typeof(BillDetails))
            {
                if (dataGridViewMagBill.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Bill", "Name Customer","Name Staff", "Time Create Bill", "Total Items", "Total Sub"
                                                    ,"Total Discount","Total Amount","Status Bill","Detail Bill"};
                    string[] dataColumnName = new string[] { "colIdBill", "colNameCustomer","colNameStaff", "colTimeCreateBill", "colTotalItems", "colTotalSub"
                                                    ,"colTotalDiscount","colTotalAmount","colStatusBill","colDetailBill"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagBill);
                }
                BillDetails newBillDetail = item as BillDetails;
                ListsBillDetails.Add(newBillDetail);
                SelectAllItems<BillDetails>(ListsBillDetails);
            }
        }

        // Method: Create List -> Save List and DataGridView
        public void CreateListData<T>(List<T> listData)
        {
            if (listData.GetType() == typeof(List<Items>))
            {
                if (dataGridViewMagItems.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Item", "Name Item", "Type Item", "Quantity", "Brand", "Release Date"
                                                    ,"Price", "Discount","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdItem", "colFullNameItem", "colTypeItem", "colQuantityItem", "colBrandItem", "colReleaseDateItem"
                                                    ,"colPriceItem", "colDiscountItem","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagItems);
                }
                dataGridViewMagItems.Rows.Clear();
                // Operater -> Ep kieu Generic voi toan tu as
                List<Items> newListItems = listData as List<Items>;
                foreach (Items item in newListItems)
                {
                    dataGridViewMagItems.Rows.Add(item.ObjectToArray());
                }
            }
            else if (listData.GetType() == typeof(List<Customers>))
            {
                if (dataGridViewMagCustomers.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Customer", "Full Name", "Birth Date", "Address", "Phone Number", "Email"
                                                    ,"Type Customer", "Point","Create Time Account","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdCustomer", "colFullNameCustomer", "colBirthDateCustomer", "colAddressCustomer", "colPhoneNumberCustomer"
                                                    ,"colEmailCustomer","colTypeCustomer","colPointCustomer", "colCreateTimeAccountCustomer","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagCustomers);
                }
                dataGridViewMagCustomers.Rows.Clear();
                // Operater -> Ep kieu Generic voi toan tu as
                List<Customers> newCustomer = listData as List<Customers>;
                foreach (Customers customer in newCustomer)
                {
                    dataGridViewMagCustomers.Rows.Add(customer.ObjectCustomerToArray());
                }

            }
            else if (listData.GetType() == typeof(List<Discounts>))
            {
                if (dataGridViewMagDiscounts.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Discount", "Name Discount", "Time Start", "Time End", "Type Discount", "Percent Discount"
                                                    ,"Value Discount","Update","Delete"};
                    string[] dataColumnName = new string[] { "colIdDiscount", "colFullNameDiscount", "colTimeStartDiscount", "colTimeEndDiscount", "colTypeDiscount"
                                                    ,"colPercentDiscount","colValueDiscount","colUpdate","colDelete"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagDiscounts);
                }
                dataGridViewMagDiscounts.Rows.Clear();
                // Operater -> Ep kieu Generic voi toan tu as
                List<Discounts> newDiscount = listData as List<Discounts>;
                foreach (Discounts discount in newDiscount)
                {
                    dataGridViewMagDiscounts.Rows.Add(discount.ObjectDiscountToArray());
                }
            }
            else if (listData.GetType() == typeof(List<BillDetails>))
            {
                if (dataGridViewMagBill.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Bill", "Name Customer","Name Staff", "Time Create Bill", "Total Items", "Total Sub"
                                                    ,"Total Discount","Total Amount","Status Bill","Detail Bill"};
                    string[] dataColumnName = new string[] { "colIdBill", "colNameCustomer","colNameStaff", "colTimeCreateBill", "colTotalItems", "colTotalSub"
                                                    ,"colTotalDiscount","colTotalAmount","colStatusBill","colDetailBill"};
                    AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagBill);
                }
                dataGridViewMagBill.Rows.Clear();
                // Operater -> Ep kieu Generic voi toan tu as
                List<BillDetails> newBillDetail = listData as List<BillDetails>;
                foreach (BillDetails billDetail in newBillDetail)
                {
                    dataGridViewMagBill.Rows.Add(billDetail.ObjectToArray());
                }
            }
        }


        // Method: UpdateItems
        public void UpdateItems<T>(T item)
        {
            if (_acctionType == AcctionType.NORMAL)
            {
                if (item.GetType() == typeof(Items))
                {
                    //Full-Normal
                    Items newItem = item as Items;
                    int indexUpdate = CommonObject.GetItemsById(ListItems, newItem.IdItem);
                    dataGridViewMagItems.Rows.RemoveAt(indexUpdate);
                    ListItems.RemoveAt(indexUpdate);
                    ListItems.Insert(indexUpdate, newItem);
                    dataGridViewMagItems.Rows.Insert(indexUpdate, newItem);
                    SelectAllItems<Items>(ListItems);
                }
            }
            else if (_acctionType == AcctionType.SEARCH)
            {
                if (item.GetType() == typeof(Items))
                {
                    Items newItem = item as Items;
                    //Search
                    int indexUpdateSearch = CommonObject.GetItemsById(ListItemsSearchResult, newItem.IdItem);
                    dataGridViewMagItems.Rows.RemoveAt(indexUpdateSearch);
                    ListItemsSearchResult.RemoveAt(indexUpdateSearch);
                    ListItemsSearchResult.Insert(indexUpdateSearch, newItem);
                    dataGridViewMagItems.Rows.Insert(indexUpdateSearch, newItem);
                    //Normal
                    int indexUpdate = CommonObject.GetItemsById(ListItems, newItem.IdItem);
                    ListItems.RemoveAt(indexUpdate);
                    ListItems.Insert(indexUpdate, newItem);
                    SelectAllItems<Items>(ListItemsSearchResult);
                }
            }

            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (item.GetType() == typeof(Customers))
                {
                    //Full-Normal
                    Customers newCustomer = item as Customers;
                    int indexUpdate = CommonObject.GetCustomerById(ListCustomers, newCustomer.IdPerson);
                    dataGridViewMagCustomers.Rows.RemoveAt(indexUpdate);
                    ListCustomers.RemoveAt(indexUpdate);
                    ListCustomers.Insert(indexUpdate, newCustomer);
                    dataGridViewMagCustomers.Rows.Insert(indexUpdate, newCustomer);
                    SelectAllItems<Customers>(ListCustomers);
                }

            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (item.GetType() == typeof(Customers))
                {
                    Customers newCustomer = item as Customers;
                    //Search
                    int indexUpdateSearch = CommonObject.GetCustomerById(ListCustomersSearchResult, newCustomer.IdPerson);
                    dataGridViewMagCustomers.Rows.RemoveAt(indexUpdateSearch);
                    ListCustomersSearchResult.RemoveAt(indexUpdateSearch);
                    ListCustomersSearchResult.Insert(indexUpdateSearch, newCustomer);
                    dataGridViewMagCustomers.Rows.Insert(indexUpdateSearch, newCustomer);
                    //Normal
                    int indexUpdate = CommonObject.GetCustomerById(ListCustomers, newCustomer.IdPerson);
                    ListCustomers.RemoveAt(indexUpdate);
                    ListCustomers.Insert(indexUpdate, newCustomer);
                    SelectAllItems<Customers>(ListCustomersSearchResult);
                }
            }

            if (_acctionTypeDiscount == AcctionTypeDiscount.NORMAL)
            {
                if (item.GetType() == typeof(Discounts))
                {
                    //Full-Normal
                    Discounts newDiscount = item as Discounts;
                    int indexUpdate = CommonObject.GetDiscountById(ListDiscounts, newDiscount.IdDiscount);
                    dataGridViewMagDiscounts.Rows.RemoveAt(indexUpdate);
                    ListDiscounts.RemoveAt(indexUpdate);
                    ListDiscounts.Insert(indexUpdate, newDiscount);
                    dataGridViewMagDiscounts.Rows.Insert(indexUpdate, newDiscount);
                    SelectAllItems<Discounts>(ListDiscounts);
                }

            }
            else if (_acctionTypeDiscount == AcctionTypeDiscount.SEARCH)
            {
                if (item.GetType() == typeof(Discounts))
                {
                    Discounts newDiscount = item as Discounts;
                    //Search
                    int indexUpdateSearch = CommonObject.GetDiscountById(ListDiscountsSearchResult, newDiscount.IdDiscount);
                    dataGridViewMagDiscounts.Rows.RemoveAt(indexUpdateSearch);
                    ListDiscountsSearchResult.RemoveAt(indexUpdateSearch);
                    ListDiscountsSearchResult.Insert(indexUpdateSearch, newDiscount);
                    dataGridViewMagDiscounts.Rows.Insert(indexUpdateSearch, newDiscount);
                    //Normal
                    int indexUpdate = CommonObject.GetDiscountById(ListDiscounts, newDiscount.IdDiscount);
                    ListDiscounts.RemoveAt(indexUpdate);
                    ListDiscounts.Insert(indexUpdate, newDiscount);
                    SelectAllItems<Discounts>(ListDiscountsSearchResult);
                }
            }

            if (_actionTypeBillDetail == AcctionTypeBillDetail.NORMAL)
            {
                if (item.GetType() == typeof(BillDetails))
                {
                    //Full-Normal
                    BillDetails newBillDetail = item as BillDetails;
                    int indexUpdate = CommonObject.GetIndexBillDetailById(ListsBillDetails, newBillDetail.IdBill);
                    ListsBillDetails.RemoveAt(indexUpdate);
                    dataGridViewMagBill.Rows.RemoveAt(indexUpdate);
                    ListsBillDetails.Insert(indexUpdate, newBillDetail);
                    dataGridViewMagBill.Rows.Insert(indexUpdate, newBillDetail);
                    SelectAllItems<BillDetails>(ListsBillDetails);
                }
            }
            else if (_actionTypeBillDetail == AcctionTypeBillDetail.SEARCH)
            {
                if (item.GetType() == typeof(BillDetails))
                {
                    BillDetails newBillDetail = item as BillDetails;
                    //Search
                    int indexUpdateSearch = CommonObject.GetIndexBillDetailById(ListsBillDetailsSearchResult, newBillDetail.IdBill);
                    dataGridViewMagBill.Rows.RemoveAt(indexUpdateSearch);
                    ListsBillDetailsSearchResult.RemoveAt(indexUpdateSearch);
                    ListsBillDetailsSearchResult.Insert(indexUpdateSearch, newBillDetail);
                    dataGridViewMagBill.Rows.Insert(indexUpdateSearch, newBillDetail);
                    //Normal
                    int indexUpdate = CommonObject.GetIndexBillDetailById(ListsBillDetails, newBillDetail.IdBill);
                    ListsBillDetails.RemoveAt(indexUpdate);
                    ListsBillDetails.Insert(indexUpdate, newBillDetail);
                    SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                }
            }

        }

        //Method: DeleteItems.
        public void DeleteItems<T>(List<T> listItems, T item)
        {
            if (_acctionType == AcctionType.NORMAL)
            {
                if (item.GetType() == typeof(Items))
                {
                    //Full-Normal
                    Items newItem = item as Items;
                    List<Items> newListItems = listItems as List<Items>;
                    int indexDelete = CommonObject.GetItemsById(newListItems, newItem.IdItem);
                    newListItems.RemoveAt(indexDelete);
                    dataGridViewMagItems.Rows.RemoveAt(indexDelete);
                    SelectAllItems<Items>(newListItems);
                }
            }
            else if (_acctionType == AcctionType.SEARCH)
            {
                if (item.GetType() == typeof(Items))
                {
                    Items newItem = item as Items;
                    //Search
                    int indexDeleteActionTypeSearch = CommonObject.GetItemsById(ListItemsSearchResult, newItem.IdItem);
                    ListItemsSearchResult.RemoveAt(indexDeleteActionTypeSearch);
                    dataGridViewMagItems.Rows.RemoveAt(indexDeleteActionTypeSearch);
                    //Normal
                    int indexDeleteActionTypeNormal = CommonObject.GetItemsById(ListItems, newItem.IdItem);
                    ListItems.RemoveAt(indexDeleteActionTypeNormal);
                    SelectAllItems<Items>(ListItemsSearchResult);
                }
            }
            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (item.GetType() == typeof(Customers))
                {
                    //Full-Normal
                    Customers newCustomer = item as Customers;
                    List<Customers> newListCustomers = listItems as List<Customers>;
                    int indexDelete = CommonObject.GetCustomerById(newListCustomers, newCustomer.IdPerson);
                    newListCustomers.RemoveAt(indexDelete);
                    dataGridViewMagCustomers.Rows.RemoveAt(indexDelete);
                    SelectAllItems<Customers>(newListCustomers);
                }
            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (item.GetType() == typeof(Customers))
                {
                    Customers newCustomer = item as Customers;
                    //Search
                    int indexDeleteActionTypeSearch = CommonObject.GetCustomerById(ListCustomersSearchResult, newCustomer.IdPerson);
                    ListCustomersSearchResult.RemoveAt(indexDeleteActionTypeSearch);
                    dataGridViewMagCustomers.Rows.RemoveAt(indexDeleteActionTypeSearch);
                    //Normal
                    int indexDeleteActionTypeNormal = CommonObject.GetCustomerById(ListCustomers, newCustomer.IdPerson);
                    ListCustomers.RemoveAt(indexDeleteActionTypeNormal);
                    SelectAllItems<Customers>(ListCustomersSearchResult);
                }
            }
            if (_acctionTypeDiscount == AcctionTypeDiscount.NORMAL)
            {
                if (item.GetType() == typeof(Discounts))
                {
                    //Full-Normal
                    Discounts newDiscount = item as Discounts;
                    List<Discounts> newListDiscounts = listItems as List<Discounts>;
                    int indexDelete = CommonObject.GetDiscountById(newListDiscounts, newDiscount.IdDiscount);
                    newListDiscounts.RemoveAt(indexDelete);
                    dataGridViewMagDiscounts.Rows.RemoveAt(indexDelete);
                    SelectAllItems<Discounts>(newListDiscounts);
                }
            }
            else if (_acctionTypeDiscount == AcctionTypeDiscount.SEARCH)
            {
                if (item.GetType() == typeof(Discounts))
                {
                    Discounts newDiscount = item as Discounts;
                    //Search
                    int indexDeleteActionTypeSearch = CommonObject.GetDiscountById(ListDiscountsSearchResult, newDiscount.IdDiscount);
                    ListDiscountsSearchResult.RemoveAt(indexDeleteActionTypeSearch);
                    dataGridViewMagDiscounts.Rows.RemoveAt(indexDeleteActionTypeSearch);
                    //Normal
                    int indexDeleteActionTypeNormal = CommonObject.GetDiscountById(ListDiscounts, newDiscount.IdDiscount);
                    ListDiscounts.RemoveAt(indexDeleteActionTypeNormal);
                    SelectAllItems<Discounts>(ListDiscountsSearchResult);
                }
            }

            if (_actionTypeBillDetail == AcctionTypeBillDetail.NORMAL)
            {
                if (item.GetType() == typeof(BillDetails))
                {
                    //Full-Normal
                    BillDetails billDetail = item as BillDetails;
                    List<BillDetails> newListBillDetails = listItems as List<BillDetails>;
                    int indexDelete = CommonObject.GetIndexBillDetailById(newListBillDetails, billDetail.IdBill);
                    newListBillDetails.RemoveAt(indexDelete);
                    dataGridViewMagBill.Rows.RemoveAt(indexDelete);
                    SelectAllItems<BillDetails>(newListBillDetails);
                }
            }
            else if (_actionTypeBillDetail == AcctionTypeBillDetail.SEARCH)
            {
                if (item.GetType() == typeof(BillDetails))
                {
                    BillDetails newBillDetail = item as BillDetails;
                    //Search
                    int indexDeleteActionTypeSearch = CommonObject.GetIndexBillDetailById(ListsBillDetailsSearchResult, newBillDetail.IdBill);
                    ListsBillDetailsSearchResult.RemoveAt(indexDeleteActionTypeSearch);
                    dataGridViewMagBill.Rows.RemoveAt(indexDeleteActionTypeSearch);
                    //Normal
                    int indexDeleteActionTypeNormal = CommonObject.GetIndexBillDetailById(ListsBillDetails, newBillDetail.IdBill);
                    ListsBillDetails.RemoveAt(indexDeleteActionTypeNormal);
                    SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                }
            }
        }

        // Event Handler: Add New Items 
        private void AddNewItemsClickEventHandler(object sender, EventArgs e)
        {
            if (sender.Equals(buttonMagItemsAddNewItems) || sender.Equals(mItem))
            {
                AddUpdateItemForm childViewHomeForm = new AddUpdateItemForm(this);
                childViewHomeForm.Text = "Add New Items Form";
                childViewHomeForm.ShowDialog();
            }
        }

        // Event Handler: Reset DataGridView DataSource 
        private void ResetItemsClickEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Normal
            _acctionType = AcctionType.NORMAL;
            CommonObject.Sort<Items>(ListItems, CommonObject.CompareByIdASC);
            SelectAllItems<Items>(ListItems);
        }

        // Event Handler: Update Items 
        private void UpdateItemsCellClickEvenHandler(object sender, DataGridViewCellEventArgs e)
        {
            //Set trạng thái cho hành động.
            if (_acctionType == AcctionType.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagItems.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagItems.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdItem"].Value.ToString();
                    int idUpdate = int.Parse(idUpdateString);
                    int indexItem = CommonObject.GetItemsById(ListItems, idUpdate);
                    AddUpdateItemForm updateItemsForm = new AddUpdateItemForm(this);
                    updateItemsForm.Text = "Update Items Form";
                    if (indexItem >= 0)
                    {
                        updateItemsForm.UpdateItemsInfomation(ListItems[indexItem]);
                    }
                    updateItemsForm.ShowDialog();
                }
            }
            else if (_acctionType == AcctionType.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagItems.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagItems.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdItem"].Value.ToString();
                    int idUpdate = int.Parse(idUpdateString);
                    int indexItem = CommonObject.GetItemsById(ListItemsSearchResult, idUpdate);
                    AddUpdateItemForm updateItemsForm = new AddUpdateItemForm(this);
                    updateItemsForm.Text = "Update Items Form";
                    if (indexItem >= 0)
                    {
                        updateItemsForm.UpdateItemsInfomation(ListItemsSearchResult[indexItem]);
                    }
                    updateItemsForm.ShowDialog();
                }
            }

        }

        //Event: Delete
        private void DeleteItemsCellContenClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            //Set trạng thái cho hành động.
            if (_acctionType == AcctionType.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagItems.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    
                    DataGridViewRow rowDataGridViewMagItem = dataGridViewMagItems.Rows[e.RowIndex];
                    string idRemoveS = rowDataGridViewMagItem.Cells["colIdItem"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int idRemove = int.Parse(idRemoveS);
                        int indexRemove = CommonObject.GetItemsById(ListItems, idRemove);
                        if (CommonObject.IsExitsItemInBill(ListItems[indexRemove], ListsBillDetails))
                            {
                            if (indexRemove >= 0)
                            {
                                string content = $"Are you sure you want to delete items with id = {idRemoveS}?";
                                string title = "Confirm delete: ";
                                DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    DeleteItems(ListItems, ListItems[indexRemove]);
                                    MessageBox.Show($"Successfully deleted item with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm đã tồn tại ở giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                }
            }
            else if (_acctionType == AcctionType.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagItems.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow rowDataGridViewMagItem = dataGridViewMagItems.Rows[e.RowIndex];
                    string idRemoveS = rowDataGridViewMagItem.Cells["colIdItem"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int idRemove = int.Parse(idRemoveS);
                        int indexRemove = CommonObject.GetItemsById(ListItemsSearchResult, idRemove);

                        if (indexRemove >= 0)
                        {
                            string content = $"Are you sure you want to delete items with id = {idRemoveS}?";
                            string title = "Confirm delete: ";
                            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DeleteItems<Items>(ListItemsSearchResult, ListItemsSearchResult[indexRemove]);
                                MessageBox.Show($"Successfully deleted item with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

        }

        // Event: Sort
        private void SortCheckedEventHandler(object sender, EventArgs e)
        {
            if (_acctionType == AcctionType.NORMAL)
            {
                if (dataGridViewMagItems.Rows.Count > 0)
                {
                    if (radioButtonMagItemsPriectAsc.Checked)
                    {
                        CommonObject.Sort(ListItems, CommonObject.CompareByPriceASC);
                    }
                    else if (radioButtonMagItemsPriceDesc.Checked)
                    {
                        CommonObject.Sort(ListItems, CommonObject.CompareByPriceDESC);
                    }
                    else if (radioButtonMagItemsQuanTityDesc.Checked)
                    {
                        CommonObject.Sort(ListItems, CommonObject.CompareByQuantittyDESC);
                    }
                    else if (radioButtonReleaseDateAsc.Checked)
                    {
                        CommonObject.Sort(ListItems, CommonObject.CompareByReleaseDateASC);
                    }
                    else if (radioButtonMagItemsNameItemaz.Checked)
                    {
                        CommonObject.Sort(ListItems, CommonObject.CompareByNameASC);
                    }
                    SelectAllItems<Items>(ListItems);
                }
                else if (dataGridViewMagItems.Rows.Count <= 0)
                {
                    MessageBox.Show("List Items IsEmpty cannot Sort!");
                }
            }
            else if (_acctionType == AcctionType.SEARCH)
            {
                if (dataGridViewMagItems.Rows.Count > 0)
                {
                    if (radioButtonMagItemsPriectAsc.Checked)
                    {
                        CommonObject.Sort(ListItemsSearchResult, CommonObject.CompareByPriceASC);
                    }
                    else if (radioButtonMagItemsPriceDesc.Checked)
                    {
                        CommonObject.Sort(ListItemsSearchResult, CommonObject.CompareByPriceDESC);
                    }
                    else if (radioButtonMagItemsQuanTityDesc.Checked)
                    {
                        CommonObject.Sort(ListItemsSearchResult, CommonObject.CompareByQuantittyDESC);
                    }
                    else if (radioButtonReleaseDateAsc.Checked)
                    {
                        CommonObject.Sort(ListItemsSearchResult, CommonObject.CompareByReleaseDateASC);
                    }
                    else if (radioButtonMagItemsNameItemaz.Checked)
                    {
                        CommonObject.Sort(ListItemsSearchResult, CommonObject.CompareByNameASC);
                    }
                    SelectAllItems<Items>(ListItemsSearchResult);
                }
                else if (dataGridViewMagItems.Rows.Count <= 0)
                {
                    MessageBox.Show("List Items IsEmpty cannot Sort!");
                }
            }

        }

        // Event: Search
        private void SearchIndexChangeEventHandler(object sender, EventArgs e)
        {
            if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 0)
            {
                numericUpDownMagItemsFrom.Enabled = false;
                numericUpDownMagItemsTo.Enabled = false;
                textBoxMagItemsContentSearch.Enabled = true;

            }
            else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 1)
            {
                textBoxMagItemsContentSearch.Enabled = false;
                numericUpDownMagItemsFrom.Enabled = true;
                numericUpDownMagItemsTo.Enabled = true;

            }
            else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 2)
            {
                numericUpDownMagItemsFrom.Enabled = false;
                numericUpDownMagItemsTo.Enabled = false;
                textBoxMagItemsContentSearch.Enabled = true;

            }
            else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 3)
            {
                numericUpDownMagItemsFrom.Enabled = false;
                numericUpDownMagItemsTo.Enabled = false;
                textBoxMagItemsContentSearch.Enabled = true;
            }
            else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 4)
            {
                textBoxMagItemsContentSearch.Enabled = false;
                numericUpDownMagItemsFrom.Enabled = true;
                numericUpDownMagItemsTo.Enabled = true;

            }
        }

        // Event: Search    -> content/from - to -> item.attribute == conten/from - to in the ListItem -> add.ListNew -> Show
        // Search in ListItems Gốc -> Show NewListItemSearch -> Reset show ListItems Gốc
        private void SearchClickButtonEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Search
            _acctionType = AcctionType.SEARCH;

            if (ListItems.Count <= 0)
            {
                string content = "There are no items in the list to search for yet!";
                string title = "Notification:";
                MessageBoxInfomationSearch(content, title);
            }
            else
            {
                if (comboBoxMagItemsCriteriaSearch.SelectedIndex <= -1)
                {
                    string content = "Please select criteria to search!";
                    string title = "Notification:";
                    MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    if ((comboBoxMagItemsCriteriaSearch.SelectedIndex == 0
                        || comboBoxMagItemsCriteriaSearch.SelectedIndex == 2
                        || comboBoxMagItemsCriteriaSearch.SelectedIndex == 3)
                        && String.IsNullOrEmpty(textBoxMagItemsContentSearch.Text))
                    {
                        string content = "Please enter your search text!";
                        string title = "Notification:";
                        MessageBoxInfomationSearch(content, title);
                    }
                    else if ((comboBoxMagItemsCriteriaSearch.SelectedIndex == 1
                        || comboBoxMagItemsCriteriaSearch.SelectedIndex == 4)
                        && ((int)numericUpDownMagItemsTo.Value - (int)numericUpDownMagItemsFrom.Value) <= 0)
                    {
                        string content = "Please enter your search number!";
                        string title = "Notification:";
                        MessageBoxInfomationSearch(content, title);
                    }
                    else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 0)
                    {
                        dataGridViewMagItems.Rows.Clear();
                        string contentSearch = textBoxMagItemsContentSearch.Text;
                        ListItemsSearchResult = CommonObject.GetListSearch<Items, string>(ListItems, CommonObject.IsItemNameMatch, contentSearch);
                        if (ListItemsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Items>(ListItemsSearchResult);
                        }
                    }
                    else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 2)
                    {
                        dataGridViewMagItems.Rows.Clear();
                        string contentSearch = textBoxMagItemsContentSearch.Text;
                        ListItemsSearchResult = CommonObject.GetListSearch(ListItems, CommonObject.IsItemTypeMatch, contentSearch);
                        if (ListItemsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Items>(ListItemsSearchResult);
                        }
                    }
                    else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 3)
                    {
                        dataGridViewMagItems.Rows.Clear();
                        string contentSearch = textBoxMagItemsContentSearch.Text;
                        ListItemsSearchResult = CommonObject.GetListSearch<Items, string>(ListItems, CommonObject.IsItemBrandeMatch, contentSearch);
                        if (ListItemsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Items>(ListItemsSearchResult);
                        }
                    }
                    else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 1)
                    {
                        dataGridViewMagItems.Rows.Clear();
                        long fromSearch = (long)numericUpDownMagItemsFrom.Value;
                        long toSearch = (long)numericUpDownMagItemsTo.Value;
                        ListItemsSearchResult = CommonObject.GetListSearch<Items, long>(ListItems, CommonObject.IsItemPriceMatch, fromSearch, toSearch);
                        if (ListItemsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Items>(ListItemsSearchResult);
                        }
                    }
                    else if (comboBoxMagItemsCriteriaSearch.SelectedIndex == 4)
                    {
                        dataGridViewMagItems.Rows.Clear();
                        int fromSearch = (int)numericUpDownMagItemsFrom.Value;
                        int toSearch = (int)numericUpDownMagItemsTo.Value;
                        ListItemsSearchResult = CommonObject.GetListSearch(ListItems, CommonObject.IsItemQuantityMatch, fromSearch, toSearch);
                        if (ListItemsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Items>(ListItemsSearchResult);
                        }
                    }
                }
            }

        }


        public void MessageBoxInfomationSearch(string content, string title)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---> Customer
        //Event: Add New Customer
        private void AddNewCustomerClickEventHandler(object sender, EventArgs e)
        {
            if (buttonMagCustomersAddNew.Equals(sender) || sender.Equals(mCustomer))
            {
                AddUpdateCustomerForm addUpdateCustomerForm = new AddUpdateCustomerForm(this);
                addUpdateCustomerForm.Text = "Add New Customer Form";
                addUpdateCustomerForm.ShowDialog();
            }
        }

        private void ResetCustomerClickEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Normal
            _acctionTypeCustomer = AcctionTypeCustomer.NORMAL;
            CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByIdASC);
            SelectAllItems<Customers>(ListCustomers);

        }

        private void UpdateCustomerCellClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagCustomers.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagCustomers.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdCustomer"].Value.ToString();
                    int indexCustomer = CommonObject.GetCustomerById(ListCustomers, idUpdateString);
                    AddUpdateCustomerForm updateCustomersForm = new AddUpdateCustomerForm(this);
                    updateCustomersForm.Text = "Update Customer Form";
                    if (indexCustomer >= 0)
                    {
                        updateCustomersForm.UpdateCustomernfomation(ListCustomers[indexCustomer]);
                    }
                    updateCustomersForm.ShowDialog();
                }
            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagCustomers.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagCustomers.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdCustomer"].Value.ToString();
                    int indexCustomer = CommonObject.GetCustomerById(ListCustomersSearchResult, idUpdateString);
                    AddUpdateCustomerForm updateCustomersForm = new AddUpdateCustomerForm(this);
                    updateCustomersForm.Text = "Update Customer Form";
                    if (indexCustomer >= 0)
                    {
                        updateCustomersForm.UpdateCustomernfomation(ListCustomersSearchResult[indexCustomer]);
                    }
                    updateCustomersForm.ShowDialog();
                }
            }

        }

        private void DeleteCustomerCellContenClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagCustomers.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow rowDataGridViewMagItem = dataGridViewMagCustomers.Rows[e.RowIndex];
                    string idRemoveS = rowDataGridViewMagItem.Cells["colIdCustomer"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int indexRemove = CommonObject.GetCustomerById(ListCustomers, idRemoveS);

                        if (indexRemove >= 0)
                        {
                            string content = $"Are you sure you want to delete customer with id = {idRemoveS}?";
                            string title = "Confirm delete: ";
                            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DeleteItems(ListCustomers, ListCustomers[indexRemove]);
                                MessageBox.Show($"Successfully deleted item with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagCustomers.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow rowDataGridViewMagItem = dataGridViewMagCustomers.Rows[e.RowIndex];
                    string idRemoveS = rowDataGridViewMagItem.Cells["colIdCustomer"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int indexRemove = CommonObject.GetCustomerById(ListCustomersSearchResult, idRemoveS);

                        if (indexRemove >= 0)
                        {
                            string content = $"Are you sure you want to delete customer with id = {idRemoveS}?";
                            string title = "Confirm delete: ";
                            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DeleteItems(ListCustomersSearchResult, ListCustomersSearchResult[indexRemove]);
                                MessageBox.Show($"Successfully deleted item with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void SortCustomerCheckedEventHandler(object sender, EventArgs e)
        {
            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (dataGridViewMagCustomers.Rows.Count > 0)
                {
                    if (radioButtonSortCustomerIdASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByIdASC);
                    }
                    else if (radioButtonSortCustomerPointDESC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByPointDESC);
                    }
                    else if (radioButtonSortCustomerNameASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByNameASC);
                    }
                    else if (radioButtonSortCustomerCreateTimeASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByCreateTimeAccountASC);
                    }
                    else if (radioButtonSortCustomerBirthDateASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByBirthDateASC);
                    }
                    SelectAllItems<Customers>(ListCustomers);
                }
                else if (dataGridViewMagCustomers.Rows.Count <= 0)
                {
                    MessageBox.Show("List Customer IsEmpty cannot Sort!");
                }
            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (dataGridViewMagCustomers.Rows.Count > 0)
                {
                    if (radioButtonSortCustomerIdASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByIdASC);
                    }
                    else if (radioButtonSortCustomerPointDESC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByPointDESC);
                    }
                    else if (radioButtonSortCustomerNameASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByNameASC);
                    }
                    else if (radioButtonSortCustomerCreateTimeASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByCreateTimeAccountASC);
                    }
                    else if (radioButtonSortCustomerBirthDateASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByBirthDateASC);
                    }
                    SelectAllItems<Customers>(ListCustomersSearchResult);
                }
                else if (dataGridViewMagCustomers.Rows.Count <= 0)
                {
                    MessageBox.Show("List Customer IsEmpty cannot Sort!");
                }
            }
        }

        private void SearchCustomerEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Search
            _acctionTypeCustomer = AcctionTypeCustomer.SEARCH;

            if (ListCustomers.Count <= 0)
            {
                string content = "There are no customers in the list to search for yet!";
                string title = "Notification:";
                MessageBoxInfomationSearch(content, title);
            }
            else
            {
                if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex <= -1)
                {
                    string content = "Please select criteria to search!";
                    string title = "Notification:";
                    MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    if ((comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 0
                        || comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 1
                        || comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 2
                        || comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 3
                        || comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 4)
                        && String.IsNullOrEmpty(textBoxContentSearchCustomer.Text))
                    {
                        string content = "Please enter your search text!";
                        string title = "Notification:";
                        MessageBoxInfomationSearch(content, title);
                    }
                    else if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 0)
                    {
                        dataGridViewMagCustomers.Rows.Clear();
                        string contentSearch = textBoxContentSearchCustomer.Text;
                        ListCustomersSearchResult = CommonObject.GetListSearch<Customers, string>(ListCustomers, CommonObject.IsCustomerNameMatch, contentSearch);
                        if (ListCustomersSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Customers>(ListCustomersSearchResult);
                        }
                    }
                    else if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 1)
                    {
                        dataGridViewMagCustomers.Rows.Clear();
                        string contentSearch = textBoxContentSearchCustomer.Text;
                        ListCustomersSearchResult = CommonObject.GetListSearch<Customers, string>(ListCustomers, CommonObject.IsCustomerIdMatch, contentSearch);
                        if (ListCustomersSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Customers>(ListCustomersSearchResult);
                        }
                    }
                    else if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 2)
                    {
                        dataGridViewMagCustomers.Rows.Clear();
                        string contentSearch = textBoxContentSearchCustomer.Text;
                        ListCustomersSearchResult = CommonObject.GetListSearch<Customers, string>(ListCustomers, CommonObject.IsCustomerTypeMatch, contentSearch);
                        if (ListCustomersSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Customers>(ListCustomersSearchResult);
                        }
                    }
                    else if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 3)
                    {
                        dataGridViewMagCustomers.Rows.Clear();
                        string contentSearch = textBoxContentSearchCustomer.Text;
                        ListCustomersSearchResult = CommonObject.GetListSearch<Customers, string>(ListCustomers, CommonObject.IsCustomerAddressMatch, contentSearch);
                        if (ListCustomersSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Customers>(ListCustomersSearchResult);
                        }
                    }
                    else if (comboBoxMagCustomersCrieteriaSearch.SelectedIndex == 4)
                    {
                        dataGridViewMagCustomers.Rows.Clear();
                        string contentSearch = textBoxContentSearchCustomer.Text;
                        ListCustomersSearchResult = CommonObject.GetListSearch<Customers, string>(ListCustomers, CommonObject.IsCustomerPhoneMatch, contentSearch);
                        if (ListCustomersSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Customers>(ListCustomersSearchResult);
                        }
                    }

                }
            }

        }

        // --> Discount
        private void AddNewDiscountClickEventHandler(object sender, EventArgs e)
        {
            if (buttonMagDiscountsAddNew.Equals(sender) || mDiscount.Equals(sender))
            {
                AddUpdateDiscountForm addUpdateDiscountForm = new AddUpdateDiscountForm(this);
                addUpdateDiscountForm.Text = "Add New Discount Form";
                addUpdateDiscountForm.ShowDialog();
            }
        }

        private void ResetDiscountClickHandlerEvent(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Normal
            _acctionTypeDiscount = AcctionTypeDiscount.NORMAL;
            CommonObject.Sort<Discounts>(ListDiscounts, CommonObject.CompareDiscountByIdASC);
            SelectAllItems<Discounts>(ListDiscounts);
        }


        private void UpdateDiscountsCellClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (_acctionTypeDiscount == AcctionTypeDiscount.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagDiscounts.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagDiscounts.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdDiscount"].Value.ToString();
                    int idUpdate = int.Parse(idUpdateString);
                    int indexDiscount = CommonObject.GetDiscountById(ListDiscounts, idUpdate);
                    AddUpdateDiscountForm updateDiscountForm = new AddUpdateDiscountForm(this);
                    updateDiscountForm.Text = "Update Discount Form";
                    if (indexDiscount >= 0)
                    {
                        updateDiscountForm.UpdateDiscountInfomation(ListDiscounts[indexDiscount]);
                    }
                    updateDiscountForm.ShowDialog();
                }
            }
            else if (_acctionTypeDiscount == AcctionTypeDiscount.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagDiscounts.Columns["colUpdate"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagDiscounts.Rows[e.RowIndex];
                    string idUpdateString = row.Cells["colIdDiscount"].Value.ToString();
                    int idUpdate = int.Parse(idUpdateString);
                    int indexDiscount = CommonObject.GetDiscountById(ListDiscountsSearchResult, idUpdate);
                    AddUpdateDiscountForm updateDiscountForm = new AddUpdateDiscountForm(this);
                    updateDiscountForm.Text = "Update Discount Form";
                    if (indexDiscount >= 0)
                    {
                        updateDiscountForm.UpdateDiscountInfomation(ListDiscountsSearchResult[indexDiscount]);
                    }
                    updateDiscountForm.ShowDialog();
                }
            }

        }

        private void DeleteDiscountCellContentClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            //Set trạng thái cho hành động.
            if (_acctionTypeDiscount == AcctionTypeDiscount.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagDiscounts.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagDiscounts.Rows[e.RowIndex];
                    string idRemoveS = row.Cells["colIdDiscount"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int idRemove = int.Parse(idRemoveS);
                        int indexRemove = CommonObject.GetDiscountById(ListDiscounts, idRemove);

                        if (indexRemove >= 0)
                        {
                            string content = $"Are you sure you want to delete Discount with id = {idRemoveS}?";
                            string title = "Confirm delete: ";
                            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DeleteItems(ListDiscounts, ListDiscounts[indexRemove]);
                                MessageBox.Show($"Successfully deleted Discount with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else if (_acctionTypeDiscount == AcctionTypeDiscount.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagDiscounts.Columns["colDelete"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagDiscounts.Rows[e.RowIndex];
                    string idRemoveS = row.Cells["colIdDiscount"].Value.ToString();
                    if (!String.IsNullOrEmpty(idRemoveS))
                    {
                        int idRemove = int.Parse(idRemoveS);
                        int indexRemove = CommonObject.GetDiscountById(ListDiscountsSearchResult, idRemove);

                        if (indexRemove >= 0)
                        {
                            string content = $"Are you sure you want to delete Discount with id = {idRemoveS}?";
                            string title = "Confirm delete: ";
                            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DeleteItems<Discounts>(ListDiscountsSearchResult, ListDiscountsSearchResult[indexRemove]);
                                MessageBox.Show($"Successfully deleted Discount with id = {idRemoveS}", "Delete Successfully: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The object to be deleted does not exist!", "Delete Failed: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }
        private void SortDiscountCheckedEventHandler(object sender, EventArgs e)
        {
            if (_acctionTypeCustomer == AcctionTypeCustomer.NORMAL)
            {
                if (dataGridViewMagCustomers.Rows.Count > 0)
                {
                    if (radioButtonSortCustomerIdASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByIdASC);
                    }
                    else if (radioButtonSortCustomerPointDESC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByPointDESC);
                    }
                    else if (radioButtonSortCustomerNameASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByNameASC);
                    }
                    else if (radioButtonSortCustomerCreateTimeASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByCreateTimeAccountASC);
                    }
                    else if (radioButtonSortCustomerBirthDateASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByBirthDateASC);
                    }
                    SelectAllItems<Customers>(ListCustomers);
                }
                else if (dataGridViewMagCustomers.Rows.Count <= 0)
                {
                    MessageBox.Show("List Customer IsEmpty cannot Sort!");
                }
            }
            else if (_acctionTypeCustomer == AcctionTypeCustomer.SEARCH)
            {
                if (dataGridViewMagCustomers.Rows.Count > 0)
                {
                    if (radioButtonSortCustomerIdASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByIdASC);
                    }
                    else if (radioButtonSortCustomerPointDESC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByPointDESC);
                    }
                    else if (radioButtonSortCustomerNameASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByNameASC);
                    }
                    else if (radioButtonSortCustomerCreateTimeASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByCreateTimeAccountASC);
                    }
                    else if (radioButtonSortCustomerBirthDateASC.Checked)
                    {
                        CommonObject.Sort<Customers>(ListCustomersSearchResult, CommonObject.CompareCustomerByBirthDateASC);
                    }
                    SelectAllItems<Customers>(ListCustomersSearchResult);
                }
                else if (dataGridViewMagCustomers.Rows.Count <= 0)
                {
                    MessageBox.Show("List Customer IsEmpty cannot Sort!");
                }
            }
        }

        private void SearchDiscountEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Search
            _acctionTypeDiscount = AcctionTypeDiscount.SEARCH;

            if (ListDiscounts.Count <= 0)
            {
                string content = "There are no discount in the list to search for yet!";
                string title = "Notification:";
                MessageBoxInfomationSearch(content, title);
            }
            else
            {
                if (comboBoxMagDiscountsSearchCriteria.SelectedIndex <= -1)
                {
                    string content = "Please select criteria to search!";
                    string title = "Notification:";
                    MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    if ((comboBoxMagDiscountsSearchCriteria.SelectedIndex == 0
                        || comboBoxMagDiscountsSearchCriteria.SelectedIndex == 1
                        || comboBoxMagDiscountsSearchCriteria.SelectedIndex == 2)
                        && String.IsNullOrEmpty(textBoxMagDiscountsContents.Text))
                    {
                        string content = "Please enter your search text!";
                        string title = "Notification:";
                        MessageBoxInfomationSearch(content, title);
                    }
                    else if (comboBoxMagDiscountsSearchCriteria.SelectedIndex == 0)
                    {
                        dataGridViewMagDiscounts.Rows.Clear();
                        string contentSearch = textBoxMagDiscountsContents.Text;
                        ListDiscountsSearchResult = CommonObject.GetListSearch<Discounts, string>(ListDiscounts, CommonObject.IsStartDiscountMatch, contentSearch);
                        if (ListDiscountsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Discounts>(ListDiscountsSearchResult);
                        }
                    }
                    else if (comboBoxMagDiscountsSearchCriteria.SelectedIndex == 1)
                    {
                        dataGridViewMagDiscounts.Rows.Clear();
                        string contentSearch = textBoxMagDiscountsContents.Text;
                        ListDiscountsSearchResult = CommonObject.GetListSearch<Discounts, string>(ListDiscounts, CommonObject.IsEndDiscountMatch, contentSearch);
                        if (ListDiscountsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Discounts>(ListDiscountsSearchResult);
                        }
                    }
                    else if (comboBoxMagDiscountsSearchCriteria.SelectedIndex == 2)
                    {
                        dataGridViewMagDiscounts.Rows.Clear();
                        string contentSearch = textBoxMagDiscountsContents.Text;
                        ListDiscountsSearchResult = CommonObject.GetListSearch<Discounts, string>(ListDiscounts, CommonObject.IsDiscountNameMatch, contentSearch);
                        if (ListDiscountsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<Discounts>(ListDiscountsSearchResult);
                        }
                    }

                }
            }
        }

        // --> Bill
        // Event: Create Bill and BillDetail
        public void AddBillClickEventHandler(object sender, EventArgs e)
        {
            if (buttonAddNewBill.Equals(sender) || sender.Equals(mBillDetail) && ListItems.Count > 0 && ListCustomers.Count > 0)
            {
                AddUpdateBillForm addUpdateBillForm = new AddUpdateBillForm(this);
                addUpdateBillForm.Text = "Add New Bill Form";
                addUpdateBillForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please add an Customer or Item to the list!", "Check: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetBillsClickEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Normal
            _actionTypeBillDetail = AcctionTypeBillDetail.NORMAL;
            CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByIdASC);
            SelectAllItems<BillDetails>(ListsBillDetails);
        }

        private void SeeDetailCenContentClickEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (_actionTypeBillDetail == AcctionTypeBillDetail.NORMAL)
            {
                if (e.ColumnIndex == dataGridViewMagBill.Columns["colDetailBill"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagBill.Rows[e.RowIndex];
                    string idString = row.Cells["colIdBill"].Value.ToString();
                    if (!String.IsNullOrEmpty(idString))
                    {
                        int idBill = int.Parse(idString);
                        int indexBill = CommonObject.GetIndexBillDetailById(ListsBillDetails, idBill);
                        AddUpdateBillForm updateBillForm = new AddUpdateBillForm(this, billDetail: ListsBillDetails[indexBill]);
                        updateBillForm.Text = "Update Bill Form";
                        if (indexBill >= 0)
                        {
                            updateBillForm.UpdateBillinfomation();
                        }
                        updateBillForm.ShowDialog();
                    }
                }
            }
            else if (_actionTypeBillDetail == AcctionTypeBillDetail.SEARCH)
            {
                if (e.ColumnIndex == dataGridViewMagBill.Columns["colDetailBill"].Index && e.RowIndex > -1)
                {
                    DataGridViewRow row = dataGridViewMagBill.Rows[e.RowIndex];
                    string idString = row.Cells["colIdBill"].Value.ToString();
                    if (!String.IsNullOrEmpty(idString))
                    {
                        int idBill = int.Parse(idString);
                        int indexBill = CommonObject.GetIndexBillDetailById(ListsBillDetailsSearchResult, idBill);
                        AddUpdateBillForm updateBillForm = new AddUpdateBillForm(this, billDetail: ListsBillDetailsSearchResult[indexBill]);
                        updateBillForm.Text = "Update Bill Form";
                        if (indexBill >= 0)
                        {
                            updateBillForm.UpdateBillinfomation();
                        }
                        updateBillForm.ShowDialog();
                    }
                }
            }

        }

        private void SaveFileMenuClickEventHandler(object sender, EventArgs e)
        {
            if (IOControllerObject.SaveDataListJson(ListItems, ListCustomers, ListDiscounts, ListsBillDetails))
            {
                string title = "Notification: ";
                string content = "Save data to file successfully!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string title = "Notification: ";
                string content = "Save data to file Failed!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadDataJsonClickEventHandler(object sender, EventArgs e)
        {
            ListItems.Clear();
            ListCustomers.Clear();
            ListDiscounts.Clear();
            ListsBillDetails.Clear();
            IOControllerObject.LoadDataListJson(ListItems, ListCustomers, ListDiscounts, ListsBillDetails);
            UpdateAutoIdObject.UpdateItemsAutoId(ListItems);
            UpdateAutoIdObject.UpdateDiscountsAutoId(ListDiscounts);
            UpdateAutoIdObject.UpdateBillDetailsAutoId(ListsBillDetails);
            CreateListData<Items>(ListItems);
            CreateListData<Customers>(ListCustomers);
            CreateListData<Discounts>(ListDiscounts);
            CreateListData<BillDetails>(ListsBillDetails);
        }


        private void SortBillDetailCheckedEventHandler(object sender, EventArgs e)
        {
            if (_actionTypeBillDetail == AcctionTypeBillDetail.NORMAL)
            {
                if (dataGridViewMagBill.Rows.Count > 0)
                {
                    if (radioButtonSortTotalItemsDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByItemDESC);
                    }
                    else if (radioButtonSortTotalAmountDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailSortByTotalAmountDESC);
                    }
                    else if (radioButtonSortCreateTimeBillASC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByCreateTimeBillASC);
                    }
                    else if (radioButtonSortCreateTimeBillDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByCreateTimeBillDESC);
                    }
                    else if (radioButtonSortNamecustomerASC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByNameCustomerASC);
                    }
                    SelectAllItems<BillDetails>(ListsBillDetails);
                }
                else if (dataGridViewMagBill.Rows.Count <= 0)
                {
                    MessageBox.Show("List BillDetails IsEmpty cannot Sort!");
                }
            }
            else if (_actionTypeBillDetail == AcctionTypeBillDetail.SEARCH)
            {
                if (dataGridViewMagBill.Rows.Count > 0)
                {
                    if (radioButtonSortTotalItemsDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetailsSearchResult, CommonObject.CompareBillDetailByItemDESC);
                    }
                    else if (radioButtonSortTotalAmountDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetailsSearchResult, CommonObject.CompareBillDetailSortByTotalAmountDESC);
                    }
                    else if (radioButtonSortCreateTimeBillASC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetailsSearchResult, CommonObject.CompareBillDetailByCreateTimeBillASC);
                    }
                    else if (radioButtonSortCreateTimeBillDESC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetailsSearchResult, CommonObject.CompareBillDetailByCreateTimeBillDESC);
                    }
                    else if (radioButtonSortNamecustomerASC.Checked)
                    {
                        CommonObject.Sort<BillDetails>(ListsBillDetailsSearchResult, CommonObject.CompareBillDetailByNameCustomerASC);
                    }
                    SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                }
                else if (dataGridViewMagBill.Rows.Count <= 0)
                {
                    MessageBox.Show("List BillDetails IsEmpty cannot Sort!");
                }
            }
        }


        private void SearchBillDetailEventHandler(object sender, EventArgs e)
        {
            // Chuyển trạng thái -> Search
            _actionTypeBillDetail = AcctionTypeBillDetail.SEARCH;

            if (ListsBillDetails.Count <= 0)
            {
                string content = "There are no billDetail in the list to search for yet!";
                string title = "Notification:";
                MessageBoxInfomationSearch(content, title);
            }
            else
            {
                if (comboBoxMagBillSearchCriteria.SelectedIndex <= -1)
                {
                    string content = "Please select criteria to search!";
                    string title = "Notification:";
                    MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    if ((comboBoxMagBillSearchCriteria.SelectedIndex == 0
                        || comboBoxMagBillSearchCriteria.SelectedIndex == 1
                        || comboBoxMagBillSearchCriteria.SelectedIndex == 2
                        || comboBoxMagBillSearchCriteria.SelectedIndex == 3)
                        && String.IsNullOrEmpty(textBoxMagBillSearchContent.Text))
                    {
                        string content = "Please enter your search text!";
                        string title = "Notification:";
                        MessageBoxInfomationSearch(content, title);
                    }
                    else if (comboBoxMagBillSearchCriteria.SelectedIndex == 0)
                    {
                        dataGridViewMagBill.Rows.Clear();
                        string contentSearch = textBoxMagBillSearchContent.Text;
                        ListsBillDetailsSearchResult = CommonObject.GetListSearch<BillDetails, string>(ListsBillDetails, CommonObject.IsBillDetailTimeCreateBillMatch, contentSearch);
                        if (ListsBillDetailsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                        }
                    }
                    else if (comboBoxMagBillSearchCriteria.SelectedIndex == 1)
                    {
                        dataGridViewMagBill.Rows.Clear();
                        string contentSearch = textBoxMagBillSearchContent.Text;
                        ListsBillDetailsSearchResult = CommonObject.GetListSearch<BillDetails, string>(ListsBillDetails, CommonObject.IsBillDetailNameCustomerMatch, contentSearch);
                        if (ListsBillDetailsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                        }
                    }
                    else if (comboBoxMagBillSearchCriteria.SelectedIndex == 2)
                    {
                        dataGridViewMagBill.Rows.Clear();
                        string contentSearch = textBoxMagBillSearchContent.Text;
                        ListsBillDetailsSearchResult = CommonObject.GetListSearch<BillDetails, string>(ListsBillDetails, CommonObject.IsBillDetailStatusMatch, contentSearch);
                        if (ListsBillDetailsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                        }
                    }
                    else if (comboBoxMagBillSearchCriteria.SelectedIndex == 3)
                    {
                        dataGridViewMagBill.Rows.Clear();
                        string contentSearch = textBoxMagBillSearchContent.Text;
                        ListsBillDetailsSearchResult = CommonObject.GetListSearch<BillDetails, string>(ListsBillDetails, CommonObject.IsBillDetailNameStaffMatch, contentSearch);
                        if (ListsBillDetailsSearchResult.Count <= 0)
                        {
                            string content = "No results found!!";
                            string title = "Notification:";
                            MessageBoxInfomationSearch(content, title);
                        }
                        else
                        {
                            SelectAllItems<BillDetails>(ListsBillDetailsSearchResult);
                        }
                    }
                }
            }

        }



        private void StatisticCriteriaIndexChangleEventHandler(object sender, EventArgs e)
        {
            if (ListsBillDetails.Count <= 0)
            {
                MessageBox.Show("Please create a bill for statistics", "Notification: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Thống kê theo sản phẩm được mua nhiều nhất. Sắp xếp giảm dần.
                if (comboBoxMagStatisticsCriteria.SelectedIndex == 0)
                {
                    VisibleViews(0);
                    dataGridViewMagStatistics.Columns.Clear();
                    if (dataGridViewMagStatistics.Columns.Count <= 0)
                    {
                        string[] dataColumnHeaderText = new string[] { "STT", "Name Item", "Total Item", "Total Revenue" };
                        string[] dataColumnName = new string[] { "colStatisticSTT", "colSatisticItemName", "colStatisticTotalItem", "colStatisticTotalRevenue" };
                        AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagStatistics);
                    }
                    List<StatisticModel> listResult = StatisControllerObject.FindBestSellItem(ListsBillDetails);
                    ShowBestSellItemsResult(listResult);
                }
                // Thống kê theo khác hàng mua nhiều nhất. Sắp xếp giảm dần.
                else if (comboBoxMagStatisticsCriteria.SelectedIndex == 1)
                {
                    VisibleViews(1);
                    dataGridViewMagStatistics.Columns.Clear();
                    if (dataGridViewMagStatistics.Columns.Count <= 0)
                    {
                        string[] dataColumnHeaderText = new string[] { "STT", "FullName Customer", "Total Amount Customer" };
                        string[] dataColumnName = new string[] { "colStatisticSTT", "colSatisticCustomerName", "colStatisticTotalAmountCustomer" };
                        AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagStatistics);
                    }

                }
                // Thống theo top 10 ngày trong tháng có doanh thu cao nhất. Sắp xếp giảm dần.
                else if (comboBoxMagStatisticsCriteria.SelectedIndex == 2)
                {
                    VisibleViews(2);
                    dataGridViewMagStatistics.Columns.Clear();
                    if (dataGridViewMagStatistics.Columns.Count <= 0)
                    {
                        string[] dataColumnHeaderText = new string[] { "STT", "Day/Month/Year", "Total Item", "Total Discount", "Total Revenue" };
                        string[] dataColumnName = new string[] { "colStatisticSTT", "colSatisticDayMonthYear", "colStatisticTotalItem", "colStatisticTotalDiscount", "colStatisticTotalRevenue" };
                        AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagStatistics);
                    }
                }
                // Thống kê doanh thu theo tháng của năm cho trước
                else if (comboBoxMagStatisticsCriteria.SelectedIndex == 3)
                {
                    dataGridViewMagStatistics.Columns.Clear();
                    VisibleViews(3);
                    dataGridViewMagStatistics.Columns.Clear();
                    if (dataGridViewMagStatistics.Columns.Count <= 0)
                    {
                        string[] dataColumnHeaderText = new string[] { "STT", "Month/Year", "Total Item", "Total Discount", "Total Revenue" };
                        string[] dataColumnName = new string[] { "colStatisticSTT", "colSatisticDayMonthYear", "colStatisticTotalItem", "colStatisticTotalDiscount", "colStatisticTotalRevenue" };
                        AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagStatistics);
                    }
                }
                // Thống kê doanh thu theo ngày của tháng cho trước
                else if (comboBoxMagStatisticsCriteria.SelectedIndex == 4)
                {
                    dataGridViewMagStatistics.Columns.Clear();
                    VisibleViews(4);
                    dataGridViewMagStatistics.Columns.Clear();
                    if (dataGridViewMagStatistics.Columns.Count <= 0)
                    {
                        string[] dataColumnHeaderText = new string[] { "STT", "Day/Month/Year", "Total Item", "Total Discount", "Total Revenue" };
                        string[] dataColumnName = new string[] { "colStatisticSTT", "colSatisticDayMonthYear", "colStatisticTotalItem", "colStatisticTotalDiscount", "colStatisticTotalRevenue" };
                        AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewMagStatistics);
                    }
                }
            }
        }

        private void VisibleViews(int index)
        {
            if (index == 0)
            {
                dateTimePickerFromDayMagStatistic.Enabled = false;
                dateTimePickerToDayMagStatistic.Enabled = false;
                numericUpDownEnterN.Enabled = false;
                buttonVỉewResutlStatistic.Enabled = false;
            }
            else if (index == 1)
            {
                dateTimePickerFromDayMagStatistic.Enabled = true;
                dateTimePickerToDayMagStatistic.Enabled = true;
                numericUpDownEnterN.Enabled = true;
                buttonVỉewResutlStatistic.Enabled = true;
                dateTimePickerFromDayMagStatistic.CustomFormat = "dd/MM/yyyy";
                dateTimePickerToDayMagStatistic.CustomFormat = "dd/MM/yyyy";

            }
            else if (index == 2)
            {
                dateTimePickerFromDayMagStatistic.Enabled = true;
                dateTimePickerFromDayMagStatistic.CustomFormat = "MM/yyyy";
                labelFromMagStatistic.Text = "Month:";
                dateTimePickerToDayMagStatistic.Enabled = false;
                numericUpDownEnterN.Enabled = false;
                buttonVỉewResutlStatistic.Enabled = false;
            }
            else if (index == 3)
            {
                dateTimePickerFromDayMagStatistic.Enabled = true;
                dateTimePickerFromDayMagStatistic.CustomFormat = "yyyy";
                labelFromMagStatistic.Text = "Year:";
                dateTimePickerToDayMagStatistic.Enabled = false;
                numericUpDownEnterN.Enabled = false;
                buttonVỉewResutlStatistic.Enabled = false;
            }
            else if (index == 4)
            {
                dateTimePickerFromDayMagStatistic.Enabled = true;
                dateTimePickerFromDayMagStatistic.CustomFormat = "MM/yyyy";
                labelFromMagStatistic.Text = "Month:";
                dateTimePickerToDayMagStatistic.Enabled = false;
                numericUpDownEnterN.Enabled = false;
                buttonVỉewResutlStatistic.Enabled = false;

            }
        }

        private void ShowBestSellItemsResult(List<StatisticModel> listResult)
        {
            foreach (StatisticModel item in listResult)
            {
                dataGridViewMagStatistics.Rows.Add(item.ArrayToObject());
            }
        }
        private void ViewStatisticClickEventHandler(object sender, EventArgs e)
        {
            if (numericUpDownEnterN.Value > 0)
            {
                int numberOfCustomer = (int)numericUpDownEnterN.Value;
                DateTime startTime = dateTimePickerFromDayMagStatistic.Value;
                DateTime endTime = dateTimePickerToDayMagStatistic.Value;
                List<StatisticCustomer> resultListCustomer = StatisControllerObject.FindMostBounghtCustomer(ListsBillDetails, numberOfCustomer, startTime, endTime);
                ShowBestBuyCustomer(resultListCustomer);
            }
            else
            {
                MessageBox.Show("Please enter the number of customers you want to display", "Enter Customer: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ShowBestBuyCustomer(List<StatisticCustomer> listCustomer)
        {
            dataGridViewMagStatistics.Rows.Clear();
            foreach (StatisticCustomer customer in listCustomer)
            {
                dataGridViewMagStatistics.Rows.Add(customer.ArrayToObject());
            }
        }

        private void RevenueDateTimeEventHandler(object sender, EventArgs e)
        {
            if(comboBoxMagStatisticsCriteria.SelectedIndex == 2)
            {
                string dateStr = dateTimePickerFromDayMagStatistic.Value.ToString("MM/yyyy");
                List<StatisticRevenue> resultListDay = StatisControllerObject.FindBestSellDays(ListsBillDetails,dateStr);
                ShowDateTopDayStatistic(resultListDay);
            }else if (comboBoxMagStatisticsCriteria.SelectedIndex == 3)
            {
                string dateStr = dateTimePickerFromDayMagStatistic.Value.ToString("yyyy");
                List<StatisticRevenue> resultListDay = StatisControllerObject.FindMonthlyRevenue(ListsBillDetails, dateStr);
                ShowDateMonthStatistic(resultListDay);
            }
            else if (comboBoxMagStatisticsCriteria.SelectedIndex == 4)
            {
                string dateStr = dateTimePickerFromDayMagStatistic.Value.ToString("MM/yyyy");
                List<StatisticRevenue> resultListDay = StatisControllerObject.FindDaylyRevenue(ListsBillDetails, dateStr);
                ShowDateDayStatistic(resultListDay);
            }
        }

        

        private void ShowDateTopDayStatistic(List<StatisticRevenue> resultListDay)
        {
            dataGridViewMagStatistics.Rows.Clear();
            foreach (StatisticRevenue revenuew in resultListDay)
            {
                dataGridViewMagStatistics.Rows.Add(revenuew.ArrayToObjectDayTop());
            }
        }

        private void ShowDateMonthStatistic(List<StatisticRevenue> resultListDay)
        {
            dataGridViewMagStatistics.Rows.Clear();
            foreach (StatisticRevenue revenuew in resultListDay)
            {
                dataGridViewMagStatistics.Rows.Add(revenuew.ArrayToObjectMonth());
            }
        }
        private void ShowDateDayStatistic(List<StatisticRevenue> resultListDay)
        {
            dataGridViewMagStatistics.Rows.Clear();
            foreach (StatisticRevenue revenuew in resultListDay)
            {
                dataGridViewMagStatistics.Rows.Add(revenuew.ArrayToObjectDay());
            }
        }

        private void MenuItemExitClickEventHandler(object sender, EventArgs e)
        {
            string content = "            Are you sure you want to exit the app?\n" +
                             "Note you must save data before exiting the application!";
            string title = "exit confirmation:";
            DialogResult rs = MessageBox.Show(content,title,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void ResetMenuClickEventHandler(object sender, EventArgs e)
        {
            _acctionType = AcctionType.NORMAL;
            _acctionTypeCustomer = AcctionTypeCustomer.NORMAL;
            _acctionTypeDiscount = AcctionTypeDiscount.NORMAL;
            _actionTypeBillDetail = AcctionTypeBillDetail.NORMAL;
            CommonObject.Sort<Items>(ListItems, CommonObject.CompareByIdASC);
            CommonObject.Sort<Customers>(ListCustomers, CommonObject.CompareCustomerByIdASC);
            CommonObject.Sort<Discounts>(ListDiscounts, CommonObject.CompareDiscountByIdASC);
            CommonObject.Sort<BillDetails>(ListsBillDetails, CommonObject.CompareBillDetailByIdASC);
            SelectAllItems<Items>(ListItems);
            SelectAllItems<Customers>(ListCustomers);
            SelectAllItems<Discounts>(ListDiscounts);
            SelectAllItems<BillDetails>(ListsBillDetails);
        }

        private void MenuItemTabClickEventHandler(object sender, EventArgs e)
        {
            if (sender.Equals(mItemTab))
            {
                tabControlManagersSuperMall.SelectedIndex = 0;
            }
            else if (sender.Equals(mCustomerTab))
            {
                tabControlManagersSuperMall.SelectedIndex = 1;
            }
            else if (sender.Equals(mDiscountTab))
            {
                tabControlManagersSuperMall.SelectedIndex = 2;
            }
            else if (sender.Equals(mBillDetailTab))
            {
                tabControlManagersSuperMall.SelectedIndex = 3;
            }
            else if (sender.Equals(mStatisticTab))
            {
                tabControlManagersSuperMall.SelectedIndex = 4;
            }
        }

    }
    //class Run
    //{
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        HomeForm homeForm = new HomeForm();
    //        Application.Run(homeForm);
    //    }
    //}
}
