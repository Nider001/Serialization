using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Pract24
{
    public partial class MainForm : Form
    {
        //global variables
        string OKButtonAction = "";
        Database Corporation;
        InfoBuffer Info = new InfoBuffer();
        Label LabelString = new Label();
        BinaryFormatter formatter = new BinaryFormatter();        
        XmlSerializer xmlformatter = new XmlSerializer(typeof(InfoBuffer));
        DataContractJsonSerializer jsonserializer = new DataContractJsonSerializer(typeof(Label));
        List<Employee> ListToPrint;
        Department temp;

        public MainForm()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("DataFile.bin", FileMode.OpenOrCreate))
            {
                try
                {
                    try
                    {
                        using (FileStream fs2 = new FileStream("Label.json", FileMode.OpenOrCreate))
                        {
                            LabelString = (Label)jsonserializer.ReadObject(fs2);
                            this.Text = LabelString.LabelName;
                        }
                    }
                    catch
                    {
                        LabelString.LabelName = "База данных";
                        this.Text = LabelString.LabelName;
                    }

                    Corporation = (Database)formatter.Deserialize(fs);

                    using (FileStream fs3 = new FileStream("InfoBuffer.xml", FileMode.OpenOrCreate))
                    {
                        Info = (InfoBuffer)xmlformatter.Deserialize(fs3);
                        CounterLabel.Text = "Число отделов: " + Info.DepartmentCount
                        + ". Число сотрудников: " + Info.EmployeeCount + ".";
                    }
                }
                catch
                {
                    Corporation = new Database();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fs = new FileStream("DataFile.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Corporation);
            }

            using (FileStream fs2 = new FileStream("Label.json", FileMode.OpenOrCreate))
            {
                jsonserializer.WriteObject(fs2, LabelString);
            }

            using (FileStream fs3 = new FileStream("InfoBuffer.xml", FileMode.OpenOrCreate))
            {
                Info.DepartmentCount = Corporation.GetDepartmentCount();
                Info.EmployeeCount = Corporation.GetEmployeeCount();

                xmlformatter.Serialize(fs3, Info);
            }
        }

        private void SwitchMode()
        {
            if ((OKButton.Visible == false) && (ShowAll.Enabled == true))
            {
                MainTextBox.ReadOnly = false;
                MainTextBox.ResetText();

                AddDep.Enabled = false;
                RemoveDep.Enabled = false;
                EditDep.Enabled = false;
                AddEmp.Enabled = false;
                RemoveEmp.Enabled = false;
                TransferEmp.Enabled = false;
                MainSearch.Enabled = false;
                LoadButton.Enabled = false;
                SaveButton.Enabled = false;

                OKButton.Visible = true;
                CancelButton.Visible = true;
            }
            else if (ShowAll.Enabled == false)
            {
                MainTextBox.ReadOnly = true;

                ShowAll.Enabled = true;
                NameSearch.Enabled = true;
                PosSearch.Enabled = true;
                NameDepSearch.Enabled = true;
                PosDepSearch.Enabled = true;

                ShowAll.Visible = false;
                NameSearch.Visible = false;
                PosSearch.Visible = false;
                NameDepSearch.Visible = false;
                PosDepSearch.Visible = false;
                OKButton.Visible = false;
                CancelButton.Visible = false;

                AddDep.Visible = true;
                RemoveDep.Visible = true;
                EditDep.Visible = true;
                AddEmp.Visible = true;
                RemoveEmp.Visible = true;
                TransferEmp.Visible = true;
                MainSearch.Visible = true;
                LoadButton.Visible = true;
                SaveButton.Visible = true;
            }
            else
            {
                CounterLabel.Text = "Число отделов: " + Corporation.GetDepartmentCount()
                        + ". Число сотрудников: " + Corporation.GetEmployeeCount() + ".";

                MainTextBox.ReadOnly = true;
                MainTextBox.ResetText();

                AddDep.Enabled = true;
                RemoveDep.Enabled = true;
                EditDep.Enabled = true;
                AddEmp.Enabled = true;
                RemoveEmp.Enabled = true;
                TransferEmp.Enabled = true;
                MainSearch.Enabled = true;
                LoadButton.Enabled = true;
                SaveButton.Enabled = true;

                OKButton.Visible = false;
                CancelButton.Visible = false;
            }
        }

        private void SwitchSearch()
        {
            if (MainSearch.Visible == true)
            {
                AddDep.Visible = false;
                RemoveDep.Visible = false;
                EditDep.Visible = false;
                AddEmp.Visible = false;
                RemoveEmp.Visible = false;
                TransferEmp.Visible = false;
                MainSearch.Visible = false;
                LoadButton.Visible = false;
                SaveButton.Visible = false;

                ShowAll.Visible = true;
                NameSearch.Visible = true;
                PosSearch.Visible = true;
                NameDepSearch.Visible = true;
                PosDepSearch.Visible = true;
                CancelButton.Visible = true;
            }
            else
            {
                AddDep.Visible = true;
                RemoveDep.Visible = true;
                EditDep.Visible = true;
                AddEmp.Visible = true;
                RemoveEmp.Visible = true;
                TransferEmp.Visible = true;
                MainSearch.Visible = true;
                LoadButton.Visible = true;
                SaveButton.Visible = true;

                ShowAll.Visible = false;
                NameSearch.Visible = false;
                PosSearch.Visible = false;
                NameDepSearch.Visible = false;
                PosDepSearch.Visible = false;
                CancelButton.Visible = false;
            }
        }

        private void SwitchSearchAction()
        {
            if (OKButton.Visible == false)
            {
                MainTextBox.ReadOnly = false;
                MainTextBox.ResetText();

                ShowAll.Enabled = false;
                NameSearch.Enabled = false;
                PosSearch.Enabled = false;
                NameDepSearch.Enabled = false;
                PosDepSearch.Enabled = false;

                OKButton.Visible = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string filename = SaveFileDialog.FileName;

            using (StreamWriter outputfile = new StreamWriter(filename, false, Encoding.GetEncoding(1251)))
            {
                List<Department> DepartmentsToCheck = new List<Department>(Corporation.GetAllDepartents());
                foreach (Department item in DepartmentsToCheck)
                {
                    if (item.info != "")
                    {
                        outputfile.WriteLine("[Отдел]:");
                        outputfile.WriteLine(item.name);
                        outputfile.WriteLine(item.info);
                        outputfile.WriteLine(item.GetValue().ToString());
                        outputfile.WriteLine();
                    }
                    else
                    {
                        outputfile.WriteLine("[Отдел]:");
                        outputfile.WriteLine(item.name);
                        outputfile.WriteLine();
                        outputfile.WriteLine(item.GetValue().ToString());
                        outputfile.WriteLine();
                    }

                    ListToPrint = Corporation.GetAllEmployees().Where(n => (n.department == item)).ToList<Employee>();
                    foreach (Employee item2 in ListToPrint)
                    {
                        outputfile.WriteLine(item2.firstName);
                        outputfile.WriteLine(item2.secondName);
                        outputfile.WriteLine(item2.position);
                        outputfile.WriteLine(item2.bio);
                        outputfile.WriteLine();
                    }
                }

                outputfile.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            MainTextBox.ResetText();

            string filename = OpenFileDialog.FileName;

            using (StreamReader inputfile = new StreamReader(filename, Encoding.GetEncoding(1251)))
            {

                while (!inputfile.EndOfStream)
                {
                    inputfile.ReadLine();
                    string temp1 = inputfile.ReadLine();
                    string temp2 = inputfile.ReadLine();
                    string temp3 = inputfile.ReadLine();
                    uint temp3u = 0;

                    if (uint.TryParse(temp3, out temp3u))
                    {
                        temp = new Facility(temp1, temp2, temp3u);
                    }
                    else
                    {
                        temp = new WorkPlace(temp1, temp2, temp3);
                    }

                    if (temp.name != "")
                    {
                        Corporation.AddDepartment(temp);
                        inputfile.ReadLine();

                        while ((inputfile.Peek() != '[') && (!inputfile.EndOfStream))
                        {
                            Corporation.AddEmployee(new Employee(inputfile.ReadLine(), inputfile.ReadLine(),
                                temp, inputfile.ReadLine(), inputfile.ReadLine()));
                            if (!inputfile.EndOfStream)
                            {
                                inputfile.ReadLine();
                            }
                        }
                    }
                    else break;
                }

                CounterLabel.Text = "Число отделов: " + Corporation.GetDepartmentCount()
                        + ". Число сотрудников: " + Corporation.GetEmployeeCount() + ".";

                inputfile.Close();
            }
        }

        private void AddDep_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "AddDep";

            MessageBox.Show("Введите название, описание отдела, а также стоимость содержания (для объектов) или производимую продукцию (для рабочих мест) (через Enter).");
        }

        private void RemoveDep_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "RemoveDep";

            MessageBox.Show("Введите название удаляемого отдела (по нему осуществится поиск).");
        }

        private void EditDep_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "EditDep";

            MessageBox.Show("Введите название отдела и новое описание (через Enter).");
        }

        private void AddEmp_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "AddEmp";

            MessageBox.Show("Введите имя, фамилию, отдел, должность и биографию нового сотрудника (через Enter).");
        }

        private void RemoveEmp_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "RemoveEmp";

            MessageBox.Show("Введите имя, фамилию и название отдела удаляемого сотрудника (по ним осуществится поиск).");
        }

        private void TransferEmp_Click(object sender, EventArgs e)
        {
            SwitchMode();
            OKButtonAction = "TransferEmp";

            MessageBox.Show("Введите имя и фамилию сотрудника, затем название нового отдела (через Enter).");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            StringReader text = new StringReader(MainTextBox.Text);
            string TextToAdd = "";
            try
            {
                switch (OKButtonAction)
                {
                    case "AddDep":
                        string temp1 = text.ReadLine();
                        string temp2 = text.ReadLine();
                        string temp3 = text.ReadLine();
                        uint temp3u = 0;

                        if (uint.TryParse(temp3, out temp3u))
                        {
                            Corporation.AddDepartment(new Facility(temp1, temp2, temp3u));
                        }
                        else
                        {
                            Corporation.AddDepartment(new WorkPlace(temp1, temp2, temp3));
                        }
                        break;

                    case "RemoveDep":
                        Corporation.RemoveDepartment(text.ReadLine());
                        break;

                    case "EditDep":
                        Corporation.EditDepartmentDescription(text.ReadLine(), text.ReadLine());
                        break;

                    case "AddEmp":
                        Corporation.AddEmployee(text.ReadLine(), text.ReadLine(), text.ReadLine(), text.ReadLine(), text.ReadLine());
                        break;

                    case "RemoveEmp":
                        Corporation.RemoveEmployee(text.ReadLine(), text.ReadLine(), text.ReadLine());
                        break;

                    case "TransferEmp":
                        Corporation.MoveEmployeeToDepartment(text.ReadLine(), text.ReadLine(), text.ReadLine());
                        break;

                    case "NameSearch":
                        TextToAdd = "";
                        ListToPrint = new List<Employee>(Corporation.FindBySecondName(text.ReadLine()));

                        if (ListToPrint.Count == 0)
                        {
                            MainTextBox.ResetText();
                            MessageBox.Show("Сотрудники не найдены.");
                        }

                        foreach (Employee item2 in ListToPrint)
                        {
                            TextToAdd += "\n" + item2.firstName + "\n";
                            TextToAdd += item2.secondName + "\n";
                            TextToAdd += item2.position + " (" + item2.department.name + ")\n";
                            TextToAdd += item2.bio + "\n";
                        }
                        MainTextBox.Text = TextToAdd;
                        break;

                    case "PosSearch":
                        TextToAdd = "";
                        ListToPrint = new List<Employee>(Corporation.FindByPosition(text.ReadLine()));

                        if (ListToPrint.Count == 0)
                        {
                            MainTextBox.ResetText();
                            MessageBox.Show("Сотрудники не найдены.");
                        }

                        foreach (Employee item2 in ListToPrint)
                        {
                            TextToAdd += "\n" + item2.firstName + "\n";
                            TextToAdd += item2.secondName + "\n";
                            TextToAdd += item2.position + " (" + item2.department.name + ")\n";
                            TextToAdd += item2.bio + "\n";
                        }
                        MainTextBox.Text = TextToAdd;
                        break;

                    case "NameDepSearch":
                        TextToAdd = "";
                        ListToPrint = new List<Employee>(Corporation.FindBySecondNameAndDepartment(text.ReadLine(), text.ReadLine()));

                        if (ListToPrint.Count == 0)
                        {
                            MainTextBox.ResetText();
                            MessageBox.Show("Сотрудники не найдены.");
                        }

                        foreach (Employee item2 in ListToPrint)
                        {
                            TextToAdd += "\n" + item2.firstName + "\n";
                            TextToAdd += item2.secondName + "\n";
                            TextToAdd += item2.position + " (" + item2.department.name + ")\n";
                            TextToAdd += item2.bio + "\n";
                        }
                        MainTextBox.Text = TextToAdd;
                        break;

                    case "PosDepSearch":
                        TextToAdd = "";
                        ListToPrint = new List<Employee>(Corporation.FindByPositionAndDepartment(text.ReadLine(), text.ReadLine()));

                        if (ListToPrint.Count == 0)
                        {
                            MainTextBox.ResetText();
                            MessageBox.Show("Сотрудники не найдены.");
                        }

                        foreach (Employee item2 in ListToPrint)
                        {
                            TextToAdd += "\n" + item2.firstName + "\n";
                            TextToAdd += item2.secondName + "\n";
                            TextToAdd += item2.position + " (" + item2.department.name + ")\n";
                            TextToAdd += item2.bio + "\n";
                        }
                        MainTextBox.Text = TextToAdd;
                        break;
                }

                SwitchMode();
            }
            catch (NullReferenceException)
            {
                SwitchMode();
                MessageBox.Show("Неверный формат данных.");
                return;
            }
            catch (OverflowException)
            {
                SwitchMode();
                MessageBox.Show("Неверный формат данных.");
                return;
            }
            catch (FormatException)
            {
                SwitchMode();
                MessageBox.Show("Неверный формат данных.");
                return;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (OKButton.Visible == true)
            {
                SwitchMode();
                MessageBox.Show("Действие отменено.");
                return;
            }
            else
            {
                SwitchSearch();
                return;
            }
        }

        private void MainSearch_Click(object sender, EventArgs e)
        {
            SwitchSearch();
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            string text = "";

            List<Department> DepartmentsToCheck = new List<Department>(Corporation.GetAllDepartents());
            foreach (Department item in DepartmentsToCheck)
            {
                if (item.info != "")
                {
                    text += "[Отдел]:\n" + item.name + "\n" + item.info + "\n" + item.GetValue().ToString() + "\n\n";
                }
                else
                {
                    text += "[Отдел]:\n" + item.name + "\n" + item.GetValue().ToString() + "\n\n\n";
                }

                ListToPrint = Corporation.GetAllEmployees().Where(n => (n.department == item)).ToList<Employee>();
                foreach (Employee item2 in ListToPrint)
                {
                    text += item2.firstName + "\n";
                    text += item2.secondName + "\n";
                    text += item2.position + "\n";
                    text += item2.bio + "\n\n";
                }
            }

            MainTextBox.Text = text;
            SwitchSearch();
        }

        private void NameSearch_Click(object sender, EventArgs e)
        {
            SwitchSearchAction();
            OKButtonAction = "NameSearch";

            MessageBox.Show("Введите фамилию.");
        }

        private void PosSearch_Click(object sender, EventArgs e)
        {
            SwitchSearchAction();
            OKButtonAction = "PosSearch";

            MessageBox.Show("Введите должность.");
        }

        private void NameDepSearch_Click(object sender, EventArgs e)
        {
            SwitchSearchAction();
            OKButtonAction = "NameDepSearch";

            MessageBox.Show("Введите фамилию и название отдела (через Enter).");
        }

        private void PosDepSearch_Click(object sender, EventArgs e)
        {
            SwitchSearchAction();
            OKButtonAction = "PosDepSearch";

            MessageBox.Show("Введите должность и название отдела (через Enter).");
        }
    }
}
