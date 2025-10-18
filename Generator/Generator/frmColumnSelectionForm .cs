using BusinessLayer;
using Generator;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateCode
{
    public partial class frmColumnSelectionForm : Form
    {
        private List<clsRecordDetails> _allColumns;
        string _SelectedTable;
        string _SelectedDataBase;
        
        public frmColumnSelectionForm(string SelectedDataBase,string SelectedTable)//List<clsRecordDetails> columns)
        {
            InitializeComponent();
            clsDataBaseBusiness.LoadColomnInfoDetails(SelectedDataBase, SelectedTable);
            _allColumns = clsGlobalClass._ColumnDetails;
            _SelectedTable = SelectedTable;
            _SelectedTable = SelectedTable;
            LoadColumns();
        }

        private void LoadColumns()
        {
            flpColumns.Controls.Clear();

            foreach (var column in _allColumns)
            {
                var checkBox = new CheckBox
                {
                    Text = $"{column.Name} ({column.DataType})",
                    Tag = column.Name,
                    Checked = column.YouWantToFindBy,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F),
                    Margin = new Padding(5)
                };

                flpColumns.Controls.Add(checkBox);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in flpColumns.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            var primaryKeyNames = _allColumns
                .Where(n => n.IsPrimaryKey)
                .Select(n => n.Name)
                .ToList();

            foreach (Control control in flpColumns.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Tag is string columnName)
                {
                    // Check if this column is NOT a primary key
                    if (!primaryKeyNames.Contains(columnName))
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            // Add primary keys
            var primaryKeyNames = _allColumns
                .Where(n => n.IsPrimaryKey)
                .Select(n => n.Name)
                .ToList();

            list.AddRange(primaryKeyNames);

            // Only add non-primary key checkboxes
            foreach (Control control in flpColumns.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked && checkBox.Enabled)
                {
                    string columnName = checkBox.Tag.ToString();
                    // Only add if it's not a primary key (shouldn't happen since they're disabled)
                    if (!primaryKeyNames.Contains(columnName))
                    {
                        list.Add(columnName);
                    }
                }
            }

            if (list.Count == 0)
            {
                clsGlobalClass._ColumnPositionYouWantToFindBy.Remove(_SelectedTable);
            }
            else
            {
                clsGlobalClass._ColumnPositionYouWantToFindBy[_SelectedTable] = list;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void flpColumns_Paint(object sender, PaintEventArgs e)
        {

        }
        private void frmColumnSelectionForm_Load(object sender, EventArgs e)
        {
            // Get the columns that should be pre-checked for this table
            List<string> ColumnWantToFindBy = clsGlobalClass._ColumnPositionYouWantToFindBy
                .Where(n => n.Key == _SelectedTable)
                .Select(n => n.Value)
                .FirstOrDefault() ?? new List<string>();

            // Get primary key column name(s)
            var primaryKeyNames = _allColumns
                .Where(n => n.IsPrimaryKey)
                .Select(n => n.Name)
                .ToList();

            // Loop through all controls in the flow layout panel
            foreach (Control control in flpColumns.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Tag is string ColumnName)
                {
                    bool isPrimaryKey = primaryKeyNames.Contains(ColumnName);

                    if (isPrimaryKey)
                    {
                        // Primary key is always checked and disabled
                        checkBox.Checked = true;
                        checkBox.Enabled = false;
                        checkBox.ForeColor = Color.DarkBlue;
                        checkBox.Font = new Font(checkBox.Font, FontStyle.Bold);
                    }
                    else
                    {
                        // Regular column - check if it was previously selected
                        checkBox.Checked = ColumnWantToFindBy.Contains(ColumnName);
                    }
                }
            }
        }

        /*  private void frmColumnSelectionForm_Load(object sender, EventArgs e)
          { 
              // Get the columns that should be pre-checked for this table
              List<string> ColumnWantToFindBy = clsGlobalClass._ColumnPositionYouWantToFindBy
                  .Where(n => n.Key == _SelectedTable)
                  .Select(n => n.Value)
                  .FirstOrDefault() ?? new List<string>(); // Handle null case

              // Loop through all controls in the flow layout panel
              foreach (Control control in flpColumns.Controls)
              {
                  // Check if it's a CheckBox and if its Tag contains a clsRecordDetails object
                  if (control is CheckBox checkBox && checkBox.Tag is string ColumnName)
                  {
                      if(_allColumns.Where(n => n.IsPrimaryKey).Select(n => n.Name).ToString() == ColumnName)
                          checkBox.Checked = true;

                      // Check if this column is in our pre-selected list
                      checkBox.Checked = ColumnWantToFindBy.Contains(ColumnName);

                  }

              }
          }*/

    }
    
}
//FindByColumn?.Contains(column.Name) == true