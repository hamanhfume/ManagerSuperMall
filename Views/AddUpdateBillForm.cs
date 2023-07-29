using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMallManagerMVC
{
    public partial class AddUpdateBillForm : Form
    {
        private HomeForm _objectHomeForm;
        private List<Customers> _listCustomerBill;
        private List<Items> _listItemsBill;
        public BillDetails _billDetails;
        private DateTime _timeCreateBillDetail;
        private string _statusBill = "Processing";
        private string _isEditting = string.Empty;
        private int _indexItemSelected = -1;
        private bool _customerInfo = false;
        private bool _staffInfo = false;

        public AddUpdateBillForm()
        {
            InitializeComponent();
            CenterToParent();
            _listCustomerBill = new List<Customers>();
            _listItemsBill = new List<Items>();
        }


        // 1 Bill -> Sẽ Tự động tạo ra 1 BillDetail.
        public AddUpdateBillForm(HomeForm objectHomeForm, BillDetails billDetail = null) : this()
        {
            _objectHomeForm = objectHomeForm;
            if (billDetail != null)
            {
                _billDetails = billDetail;
            }
            else
            {
                _timeCreateBillDetail = DateTime.Now;
                _billDetails = new BillDetails(0);
                _billDetails.CreateTimeBill = _timeCreateBillDetail;
                labelCreateTimeBill.Text = "Time Create Bill: " + _billDetails.CreateTimeBill.ToString("HH:mm:ss dd/MM/yyyy");
            }

        }
        // -> Payments
        private void btnPaymentClickEventHandler(object sender, EventArgs e)
        {
            if (buttonPaymentBill.Equals(sender))
            {
                if (_staffInfo && _customerInfo)
                {
                    if (_billDetails.CartBill.SelectedItemCart.Count > 0)
                    {
                        PaymentForm paymentView = new PaymentForm(this);
                        paymentView.Text = "Payment Form";
                        paymentView.ShowDialog();
                    }
                    else
                    {
                        string title = "Error Input: ";
                        string content = "Please check the selected item on the Bill-Detail, make sure it is not empty!";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string title = "Error Info Staff or Customer: ";
                    string content = "Please check staff or customer name!";
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Event Cancel Bill
        private void btnCancelAddBillEventClickHandler(object sender, EventArgs e)
        {
            if (_staffInfo && _customerInfo)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Cancel Add Bill?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _billDetails.StatusBill = "Cancelled";
                    CreateBill(_billDetails);
                }
            }
            else
            {
                string title = "Error Info Staff or Customer: ";
                string content = "Please check staff or customer name!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event: Remove
        private void btnRemoveClickEventHandler(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Remove Add Bill?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_billDetails.CartBill.SelectedItemCart.Count > 0)
                {
                    _objectHomeForm.BillController.UpdateQuantityBillDetailItemsStock(_billDetails, _objectHomeForm.ListItems);
                }
                this.Close();
            }
        }

        private void ShowItemUpdateDataGridView<T>(T data)
        {
            if (data.GetType() == typeof(Items))
            {
                if (dataGridViewInfomationItemAddBillForm.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Item", "Name Item", "Quantity Item", "Select" };
                    string[] dataColumnName = new string[] { "colIdItem", "colNameItem", "colQuantityItem", "colSelect" };
                    _objectHomeForm.AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewInfomationItemAddBillForm);
                }
                dataGridViewInfomationItemAddBillForm.Rows.Clear();
                Items newItem = data as Items;
                dataGridViewInfomationItemAddBillForm.Rows.Add(newItem.ObjectToArrayAddBill());
            }
            else if (data.GetType() == typeof(SelectedItems))
            {
                if (dataGridViewInfomationItemAddBillForm.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Item", "Name Item", "Quantity Item", "Select" };
                    string[] dataColumnName = new string[] { "colIdItem", "colNameItem", "colQuantityItem", "colSelect" };
                    _objectHomeForm.AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewInfomationItemAddBillForm);
                }
                dataGridViewInfomationItemAddBillForm.Rows.Clear();
                SelectedItems newSelectedItem = data as SelectedItems;
                dataGridViewInfomationItemAddBillForm.Rows.Add(newSelectedItem.ObjectToArrayAddBill());
            }

        }


        // Method: Đẩy dữ liệu lên dataGridView
        private void SelectAllDataGridViewAddBill<T>(List<T> listData)
        {
            if (listData.GetType() == typeof(List<Customers>))
            {
                if (dataGridViewInfomationCustomerAddBillForm.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Customer", "Full Name", "Select" };
                    string[] dataColumnName = new string[] { "colIdCustomer", "colFullNameCustomer", "colSelect" };
                    _objectHomeForm.AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewInfomationCustomerAddBillForm);
                }
                dataGridViewInfomationCustomerAddBillForm.Rows.Clear();
                List<Customers> newListCustomer = listData as List<Customers>;
                foreach (Customers customer in newListCustomer)
                {
                    dataGridViewInfomationCustomerAddBillForm.Rows.Add(customer.ObjectCustomerToArrayAddBill());
                }
            }
            else if (listData.GetType() == typeof(List<Items>))
            {
                if (dataGridViewInfomationItemAddBillForm.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Item", "Name Item", "Quantity Item", "Select" };
                    string[] dataColumnName = new string[] { "colIdItem", "colNameItem", "colQuantityItem", "colSelect" };
                    _objectHomeForm.AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewInfomationItemAddBillForm);
                }
                dataGridViewInfomationItemAddBillForm.Rows.Clear();
                List<Items> newListItems = listData as List<Items>;
                foreach (Items item in newListItems)
                {
                    dataGridViewInfomationItemAddBillForm.Rows.Add(item.ObjectToArrayAddBill());
                }
            }
            else if (listData.GetType() == typeof(List<SelectedItems>))
            {
                if (dataGridViewItemsDetailsInBill.Columns.Count <= 0)
                {
                    string[] dataColumnHeaderText = new string[] { "Id Bill", "Id Item", "Name Item", "Quantity ItemSelected", "Price Item", "Price After Discount", "Total Amount Item", "Update", "Delete" };
                    string[] dataColumnName = new string[] { "colIdBill", "colIdItemSelected", "colNameItem", "colQuantityItemSelected", "colPriceItem", "colPriceAfterDiscount", "colTotalAmountItem", "colUpdate", "colDelete" };
                    _objectHomeForm.AddColumnsDataGridView(dataColumnName, dataColumnHeaderText, dataGridViewItemsDetailsInBill);
                }
                dataGridViewItemsDetailsInBill.Rows.Clear();
                List<SelectedItems> newListSelectedItems = listData as List<SelectedItems>;
                foreach (SelectedItems itemSelected in newListSelectedItems)
                {
                    dataGridViewItemsDetailsInBill.Rows.Add(itemSelected.ObjectToArraySelectItem(_billDetails));
                }
            }
        }
        // Event: Search Customer in ListCustomers -> Event: CellClick: Chọn Customers -> Save ở Cart.Customer
        private void btnSearchCustomerBillEventHandler(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSearchCustomerBill.Text))
            {
                string title = "Search Error: ";
                string content = "Please enter Customer name before searching!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string searchContentCustomer = textBoxSearchCustomerBill.Text;
                _listCustomerBill = _objectHomeForm.CommonObject.GetListSearch<Customers, string>
                    (_objectHomeForm.ListCustomers, _objectHomeForm.CommonObject.IsCustomerNameMatch, searchContentCustomer);
                if (_listCustomerBill.Count <= 0)
                {
                    string content = "No results found!!";
                    string title = "Notification:";
                    _objectHomeForm.MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    SelectAllDataGridViewAddBill<Customers>(_listCustomerBill);
                }
            }
        }

        // Event: Search Item in ListItems -> Event: CellClick: Chọn Items -> Chuyển thành SelectedItems -> Save ở Cart.ListSelectedItems
        private void btnSearchItemsClickEventHandler(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSearchItemBill.Text))
            {
                string title = "Search Error: ";
                string content = "Please enter Items name before searching!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string _contentSearchItem = textBoxSearchItemBill.Text;
                _listItemsBill = _objectHomeForm.CommonObject.GetListSearch<Items, string>
                    (_objectHomeForm.ListItems, _objectHomeForm.CommonObject.IsItemNameMatch, _contentSearchItem);
                if (_listItemsBill.Count <= 0)
                {
                    string content = "No results found!!";
                    string title = "Notification:";
                    _objectHomeForm.MessageBoxInfomationSearch(content, title);
                }
                else
                {
                    SelectAllDataGridViewAddBill<Items>(_listItemsBill);
                }
            }
        }

        // Method: Show Infomation BillDetail 
        private void ShowInfomationBillDetail()
        {
            labelStaffBillAdd.Text = $"Staff: {_billDetails.StaffNameBillDetails}";
            labelCustomerName.Text = $"Customer Name: {_billDetails.CartBill.CustomerCart?.FullNamePerson.ToString()}";
            labelTotalItems.Text = $"Total Items Bill: {_billDetails.TotalItemBill:N0}Sp";
            labelTotalAmountBill.Text = $"Total Amount Bill: {_billDetails.TotalAmountBill:N0}đ";
            labelTotalDiscount.Text = $"Total Discount Bill: {_billDetails.TotalDiscountBill:N0}đ";
            labelCreateTimeBill.Text = "Time Create Bill: " + _billDetails.CreateTimeBill.ToString("HH:mm:ss dd/MM/yyyy");
        }


        // Event: Select Customer in List -> Save BillDetail.Cart.Customert
        private void SelectCustomerAddBillCentCilckHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInfomationCustomerAddBillForm.Columns["colSelect"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewInfomationCustomerAddBillForm.Rows[e.RowIndex];
                string idCustomerString = row.Cells["colIdCustomer"].Value.ToString();
                int indexCustomer = _objectHomeForm.CommonObject.GetCustomerById(_listCustomerBill, idCustomerString);
                //-> Select Customer -> Save Cart -> Save BillDetail
                _billDetails.CartBill.CustomerCart = _listCustomerBill[indexCustomer];
                ShowInfomationBillDetail();
                _customerInfo = true;

            }
        }

        private void SaveStaffClickEventHandler(object sender, EventArgs e)
        {
            string inputNameStaff = textBoxSearchStaffBill.Text;
            if (_objectHomeForm.FilterObject.IsFullNameCustomerValid(inputNameStaff) && !String.IsNullOrEmpty(inputNameStaff))
            {
                _billDetails.StaffNameBillDetails = inputNameStaff;
                _staffInfo = true;
                ShowInfomationBillDetail();
            }
            else
            {
                string title = "Staff Invalid:";
                string content = "Please enter staff name and correct format!\n" +
                                 "Example valid: Hà Văn Mạnh...!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Event: Select SelectedItems in List -> Save BillDetail.Cart.List<SelectedItems>
        private void SelectItemsAddBillCentCilckHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInfomationItemAddBillForm.Columns["colSelect"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewInfomationItemAddBillForm.Rows[e.RowIndex];
                string idItemsString = row.Cells["colIdItem"].Value.ToString();
                if (!String.IsNullOrEmpty(idItemsString))
                {
                    int idItems = int.Parse(idItemsString);
                    int quantityWantSelect = (int)numericUpDownQuantityBill.Value;
                    int indexItems = _objectHomeForm.CommonObject.GetItemsById(_listItemsBill, idItems);
                    SelectedItems itemSelected = new SelectedItems(_listItemsBill[indexItems]);
                    itemSelected.NumberOfSelectedItem = quantityWantSelect;

                    bool checkIsExisted = _objectHomeForm.BillController.IsExistedSelectedItemInBillDetail(_billDetails, itemSelected);
                    if (checkIsExisted)
                    {
                        string title = "Warning SelectItem: ";
                        string content = "The selected Item already exists in the billdetail, please update the number of selected Item in the bill";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (itemSelected.NumberOfSelectedItem > 0 && quantityWantSelect <= itemSelected.QuantityItem)
                        {
                            _listItemsBill[indexItems].QuantityItem -= quantityWantSelect;
                            SelectAllDataGridViewAddBill(_listItemsBill);
                            //Reset Value Quantity
                            numericUpDownQuantityBill.Value = 0;
                            //Save and Update BillDetail.
                            _objectHomeForm.BillController.UpdateBillBillDetail(_billDetails, itemSelected);
                            //Hiển thị DataGridView and BillDetail
                            SelectAllDataGridViewAddBill(_billDetails.CartBill.SelectedItemCart);
                            ShowInfomationBillDetail();
                        }
                        else
                        {
                            ShowErrorQuantitySelected();
                        }
                    }
                }
            }
        }

        private void ShowErrorQuantitySelected()
        {
            string title = "Error Input: ";
            string content = "Please choose a itemSelected quantity greater than 0 " +
                             "\n and less than the number of Item in stock!";
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Event: Chọn sản phẩm để update
        private void UpdateItemDetailInBillCellCilckEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewItemsDetailsInBill.Columns["colUpdate"].Index && e.RowIndex > -1)
            {
                _isEditting = "updateQuantity";
                DataGridViewRow row = dataGridViewItemsDetailsInBill.Rows[e.RowIndex];
                string idItemSelectedString = row.Cells["colIdItemSelected"].Value.ToString();
                if (!String.IsNullOrEmpty(idItemSelectedString))
                {
                    int idSelected = int.Parse(idItemSelectedString);
                    List<SelectedItems> listSelectedItems = _billDetails.CartBill.SelectedItemCart;
                    int indexItemSelected = _objectHomeForm.CommonObject.GetIndexSelectedItemById(listSelectedItems, idSelected);
                    int indexItem = _objectHomeForm.CommonObject.GetItemsById(_objectHomeForm.ListItems, idSelected);
                    if (indexItemSelected != -1)
                    {
                        numericUpDownQuantityBill.Value = 0;
                        _indexItemSelected = indexItemSelected;
                        ShowItemUpdateDataGridView(_objectHomeForm.ListItems[indexItem]);
                    }
                }
            }
        }

        //Event: Xác nhận Update
        private void UpdateQuantityClickEventHandler(object sender, EventArgs e)
        {
            if (sender.Equals(buttonUpdateItemInItemDetailsInBill))
            {
                if (_isEditting.CompareTo("updateQuantity") == 0 && _indexItemSelected > -1)
                {
                    SelectedItems selectedItem = _billDetails.CartBill.SelectedItemCart[_indexItemSelected];
                    int quantityWaintUpdate = (int)numericUpDownQuantityBill.Value;
                    int indexItem = _objectHomeForm.CommonObject.GetItemsById(_objectHomeForm.ListItems, selectedItem.IdItem);
                    if (_objectHomeForm.ListItems[indexItem].QuantityItem == 0)
                    {
                        string title = "Infomation: ";
                        string content = $"The number of Item in stock has run out!";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _isEditting = "";
                        _indexItemSelected = -1;
                    }
                    else if (quantityWaintUpdate > 0 && quantityWaintUpdate <= _objectHomeForm.ListItems[indexItem].QuantityItem)
                    {
                        _objectHomeForm.ListItems[indexItem].QuantityItem -= quantityWaintUpdate;
                        ShowItemUpdateDataGridView(_objectHomeForm.ListItems[indexItem]);
                        selectedItem.NumberOfSelectedItem += quantityWaintUpdate;
                        _objectHomeForm.BillController.UpdateBillBillDetail(_billDetails, selectedItem);
                        _objectHomeForm.SelectAllItems<Items>(_objectHomeForm.ListItems);
                        SelectAllDataGridViewAddBill(_billDetails.CartBill.SelectedItemCart);
                        ShowInfomationBillDetail();
                        numericUpDownQuantityBill.Value = 0;
                        string title = "Update Successful";
                        string content = $"Item Selected: {selectedItem.FullNameItem} has been successfully updated!" +
                                         $"\n With an additional quantity of: {quantityWaintUpdate}";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _isEditting = "";
                        _indexItemSelected = -1;
                    }
                    else
                    {
                        ShowErrorQuantitySelected();
                    }
                }
                else
                {
                    string title = "Infomation: ";
                    string content = $"Please select a Items in Bill-Detail to update!!";
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Event: Delete
        private void DeleteItemDetailInBillEventHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewItemsDetailsInBill.Columns["colDelete"].Index && e.RowIndex > -1)
            {
                SelectedItems itemSelected = _billDetails.CartBill.SelectedItemCart[e.RowIndex];
                int indexListItem = _objectHomeForm.CommonObject.GetItemsById(_objectHomeForm.ListItems, itemSelected.IdItem);
                string title = "Confirm Delete: ";
                string content = $"Are you sure you want to delete this item: {itemSelected.FullNameItem} " +
                                 $"\n with quantity selected: {itemSelected.NumberOfSelectedItem}?";
                DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (e.RowIndex < _billDetails.CartBill.SelectedItemCart.Count)
                    {
                        _objectHomeForm.ListItems[indexListItem].QuantityItem += itemSelected.NumberOfSelectedItem;
                        ShowItemUpdateDataGridView<Items>(_objectHomeForm.ListItems[indexListItem]);
                        _objectHomeForm.BillController.RemoveBillBillDetail(_billDetails, itemSelected);
                        SelectAllDataGridViewAddBill(_billDetails.CartBill.SelectedItemCart);
                        ShowInfomationBillDetail();
                        _objectHomeForm.SelectAllItems<Items>(_objectHomeForm.ListItems);
                    }
                }
            }
        }

        public void CreateBill(BillDetails billDetail)
        {
            if (_billDetails != null)
            {
                _objectHomeForm.SelectAllItems<Items>(_objectHomeForm.ListItems);
                _objectHomeForm.CreateItems<BillDetails>(_billDetails);
                this.Close();
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (_billDetails != null)
            {
                if (_staffInfo && _customerInfo)
                {
                    string title = "Confirm Save Bill-Detail";
                    string content = "Do you want to save this bill-detail or not?";
                    DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _billDetails.CreateTimeBill = DateTime.Now;
                        _billDetails.StatusBill = _statusBill;
                        CreateBill(_billDetails);
                    }
                }
                else
                {
                    string title = "Error Info Staff or Customer: ";
                    string content = "Please check staff or customer name!";
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter information for bill", "Infomation: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void UpdateBill(BillDetails billDetail)
        {
            if (_billDetails != null)
            {
                _objectHomeForm.UpdateItems<BillDetails>(_billDetails);
                Dispose();
                _objectHomeForm.SelectAllItems<Items>(_objectHomeForm.ListItems);
            }
        }
        public void DeleteBill(BillDetails billDetail)
        {
            if (_billDetails != null)
            {
                _objectHomeForm.DeleteItems<BillDetails>(_objectHomeForm.ListsBillDetails, _billDetails);
                Dispose();
                _objectHomeForm.SelectAllItems<Items>(_objectHomeForm.ListItems);
            }
        }

        public void UpdateBillinfomation()
        {
            ShowInfomationBillDetail();
            textBoxSearchCustomerBill.Text = _billDetails.CartBill.CustomerCart.FullNamePerson.ToString();
            textBoxSearchStaffBill.Text = _billDetails.StaffNameBillDetails;
            _customerInfo = true;
            _staffInfo = true;
            SelectAllDataGridViewAddBill<SelectedItems>(_billDetails.CartBill.SelectedItemCart);

            this.buttonSaveBill.Click -= new System.EventHandler(this.BtnSaveClick);
            this.buttonPaymentBill.Click -= new System.EventHandler(this.btnPaymentClickEventHandler);
            this.buttonCancelBillDetail.Click -= new System.EventHandler(this.btnCancelAddBillEventClickHandler);
            this.buttonRemoveBill.Click -= new System.EventHandler(this.btnRemoveClickEventHandler);

            this.buttonSaveBill.Click += new System.EventHandler(this.BtnSaveUpdateClick);
            this.buttonPaymentBill.Click += new System.EventHandler(this.btnPaymentUpdateClickEventHandler);
            this.buttonCancelBillDetail.Click += new System.EventHandler(this.btnCancelUpdateBillEventClickHandler);
            this.buttonRemoveBill.Click += new System.EventHandler(this.btnRemoveUpdateClickEventHandler);
        }

        private void BtnSaveUpdateClick(object sender, EventArgs e)
        {
            if (_billDetails != null)
            {
                if (_staffInfo && _customerInfo)
                {
                    if (_billDetails.CartBill.SelectedItemCart.Count > 0)
                    {
                        string title = "Confirm Save Bill-Detail";
                        string content = "Do you want to save this bill-detail or not?";
                        DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            _billDetails.CreateTimeBill = DateTime.Now;
                            _billDetails.StatusBill = _statusBill;
                            UpdateBill(_billDetails);
                        }
                    }
                    else
                    {
                        string title = "Error Info Staff or Customer: ";
                        string content = "Please check staff or customer name!";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string title = "Error Info Staff or Customer: ";
                    string content = "Please check staff or customer name!";
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter information for bill", "Infomation: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentUpdateClickEventHandler(object sender, EventArgs e)
        {
            if (buttonPaymentBill.Equals(sender))
            {
                if (_staffInfo && _customerInfo)
                {
                    if (_billDetails.CartBill.SelectedItemCart.Count > 0)
                    {
                        PaymentForm paymentView = new PaymentForm(this);
                        paymentView.ViewDetail();
                        paymentView.Text = "Payment Form";
                        paymentView.ShowDialog();
                    }
                    else
                    {
                        string title = "Error Input: ";
                        string content = "Please check the selected item on the Bill-Detail, make sure it is not empty!";
                        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string title = "Error Info Staff or Customer: ";
                    string content = "Please check staff or customer name!";
                    MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelUpdateBillEventClickHandler(object sender, EventArgs e)
        {
            if (_staffInfo && _customerInfo)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _billDetails.StatusBill = "Cancelled";
                    UpdateBill(_billDetails);
                }
            }
            else
            {
                string title = "Error Info Staff or Customer: ";
                string content = "Please check staff or customer name!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveUpdateClickEventHandler(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Remove Add Bill?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_billDetails.StatusBill.CompareTo("Finish payment") == 0)
                {
                    double point = _billDetails.TotalAmountBill * 0.001;
                    _billDetails.CartBill.CustomerCart.PointCustomer += (int)point;
                    _objectHomeForm.SelectAllItems<Customers>(_objectHomeForm.ListCustomers);
                    DeleteBill(_billDetails);
                    Dispose();
                }
                else if (_billDetails.StatusBill.CompareTo("Processing") == 0 ||
                         _billDetails.StatusBill.CompareTo("Cancelled") == 0)
                {
                    if (_billDetails.CartBill.SelectedItemCart.Count > 0)
                    {
                        _objectHomeForm.BillController.UpdateQuantityBillDetailItemsStock(_billDetails, _objectHomeForm.ListItems);
                    }
                    DeleteBill(_billDetails);
                    Dispose();
                }
            }
        }
    }
}
