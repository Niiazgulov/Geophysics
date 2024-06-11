using System.Data;

namespace Geophysics
{
    public partial class Form1 : Form
    {
        int stepCount = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void FillTable()
        {
            DataTable dt = new DataTable();
            var tableSize = Convert.ToInt32(txtL.Text);
            
            Random rand = new Random();

            for (int i = 1; i <= tableSize; i++)
            {
                dt.Columns.Add(i.ToString(), typeof(int));
                dt.Rows.Add();
            }

            foreach (DataRow dr in dt.Rows)
                foreach (DataColumn dtc in dt.Columns)
                {
                    int chance = rand.Next(1, 101);
                    if (chance <= 30)
                    {
                        dr[dtc.ToString()] = 0;
                    }
                    else
                    {
                        dr[dtc.ToString()] = 1;
                    }
                }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
              foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToInt32(Convert.ToInt32(row.Cells[col.Index].Value)) == 1)
                   dataGridView1.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.LightGreen;
        }

        private DataGridViewCell? findFirstNode()
        {
            int colIndex = 0;
            int rowindex = 0;

            var startNode = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[colIndex].Value);
            DataGridViewCell? firstNodeCell = dataGridView1.Rows[rowindex].Cells[colIndex];
            if (startNode == 1)
                return firstNodeCell;
            
            firstNodeCell = null;
            while (startNode != 1)
            {
                colIndex++;
                if (colIndex < dataGridView1.Columns.Count)
                {
                    startNode = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[colIndex].Value);
                    if (startNode == 1)
                        firstNodeCell = dataGridView1.Rows[rowindex].Cells[colIndex];
                }
                else
                {
                    colIndex = 0;
                    rowindex++;
                    if (rowindex < dataGridView1.Rows.Count)
                    {
                        startNode = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[colIndex].Value);
                        if (startNode == 1)
                            firstNodeCell = dataGridView1.Rows[rowindex].Cells[colIndex];
                    }
                    else
                        break;
                }
            } 

            return firstNodeCell;
        }

        private void DFSAlgorithm(int stepCount)
        {
            var firstNode = findFirstNode();
            if (firstNode != null)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                        dataGridView1.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.Empty;

                List<DataGridViewCell> visited = new List<DataGridViewCell>();
                Stack<DataGridViewCell> reachable = new Stack<DataGridViewCell>();
                reachable.Push(firstNode);

                while (reachable.Count > 0)
                {
                    var current = reachable.Pop();
                    current.Style.BackColor = Color.LightGreen;
                    visited.Add(current);

                    var neighbours = GenerateNeighbours(current);

                    if (neighbours.Count == 0)
                    {
                        current.Value = stepCount;
                        break;
                    }

                    foreach (var neighbour in neighbours)
                    {
                        if (!visited.Contains(neighbour))
                        {
                            reachable.Push(neighbour);
                            neighbour.Value = stepCount;
                            current.Value = stepCount;
                        }
                    }
                }
            }
        }

        private List<DataGridViewCell> GenerateNeighbours(DataGridViewCell currentNode)
        {
            List<DataGridViewCell> neighbours = new List<DataGridViewCell>();

            if (currentNode.ColumnIndex + 1 < dataGridView1.Columns.Count)
            {
                var neighbourRight = dataGridView1.Rows[currentNode.RowIndex].Cells[currentNode.ColumnIndex + 1];
                if (Convert.ToInt32(neighbourRight.Value) != 0)
                   neighbours.Add(neighbourRight);
            }
            if (currentNode.ColumnIndex - 1 >= 0)
            {
                var neighbourLeft = dataGridView1.Rows[currentNode.RowIndex].Cells[currentNode.ColumnIndex - 1];
                if (Convert.ToInt32(neighbourLeft.Value) != 0)
                    neighbours.Add(neighbourLeft);
            }
            if (currentNode.RowIndex + 1 < dataGridView1.Rows.Count)
            {
                var neighbourDown = dataGridView1.Rows[currentNode.RowIndex + 1].Cells[currentNode.ColumnIndex];
                if (Convert.ToInt32(neighbourDown.Value) != 0)
                    neighbours.Add(neighbourDown);
            }
            if (currentNode.RowIndex - 1 >= 0)
            {
                var neighbourUp = dataGridView1.Rows[currentNode.RowIndex - 1].Cells[currentNode.ColumnIndex];
                if (Convert.ToInt32(neighbourUp.Value) != 0)
                    neighbours.Add(neighbourUp); 
            }

            return neighbours;
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            stepCount = 1;
            if (txtL.Text == "")
               MessageBox.Show("¬ведите число от 2 до 256!");
            else
            {
                var tableSize = Convert.ToInt32(txtL.Text);
                if (tableSize > 256 || tableSize < 2)
                    MessageBox.Show("¬ведите число от 2 до 256!");
                else
                    FillTable();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                stepCount++;
                DFSAlgorithm(stepCount);
            }
        }

        private void txtL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
